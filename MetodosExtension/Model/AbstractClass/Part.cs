using MetodosExtension.Model.Interface;
using MetodosExtension.Model.StaticClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosExtension.Model.AbstractClass
{
    public abstract class Part : IPart
    {
        #region Properties

        protected private List<string> Content { get; set; }
        protected private IParameter Parameter { get; set; }
        protected private Control.voidFunctionWithParam<IParameter> GenerationMethod { get; set; }

        #endregion

        #region Constructor

        protected Part(IParameter parameter)
        {
            Parameter = parameter;
            InitializePart();
        }

        protected Part()
        {
            InitializePart();
        }

        #endregion

        #region Private Methods
        private protected void InitializePart()
        {
            Content = new List<string>();
        }
        protected private void AddInLastLine(string newLine, bool replace = false)
        {
            if (Content.Count == 0 && replace)
                Content = Content.Take((Content.Count - 1)).ToList();
            Content.Add(newLine);
        }
        protected private int GetLinesCount() => Content.Count();
        protected private int GetCharsCount() => Content.Sum(x => x.Length);
        protected private int GetMaxLineLength() => Content.Max(x => x.Length);
        protected private int GetMinLineLength() => Content.Min(x => x.Length);
        protected private bool IsEqualLineLength() => GetMaxLineLength() == GetMinLineLength();

        #endregion

        #region Public Methods

        public List<string> GetContent() => Content;
        public List<string> Join(params Part[] parts)
        {
            List<string> newContent = Content;
            foreach (Part part in parts)
                newContent.AddRange(part.GetContent());
            return Content;
        }

        #endregion

        #region Interface implementations

        public abstract IResponse Generate();

        #endregion
    }
}
