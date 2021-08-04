using MetodosExtension.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosExtension.Model.AbstractClass
{
    public abstract class Format : IFormat
    {
        #region Properties

        protected private List<string> LstExtensions { get; set; }
        private protected IParameter Parameter { get; set; }

        #endregion

        #region Constructor

        protected Format(IParameter parameter) => Parameter = parameter;

        #endregion

        #region Public Methods

        public string GetExtensions() => string.Join(",", LstExtensions);
        public abstract IResponse FormatFile(List<string> content, out string result);

        #endregion

        #region Enumerators
        
        public enum Extensions
        {
            txt,
            xls,
            xlsx,
            odt,
        }

        #endregion
    }
}
