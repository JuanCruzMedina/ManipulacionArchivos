using MetodosExtension.Model.Interface;
using MetodosExtension.Model.StaticClass;
using System.Collections.Generic;

namespace MetodosExtension.Model.AbstractClass
{
    public abstract class File : IFile
    {
        #region Properties & Objects

        private Subprocess _subprocess;

        private string content;

        private List<string> LstLines { get; set; }
        public Format Format { get; set; }
        public Header Header { get; set; }
        public Body Body { get; set; }
        public Footer Footer { get; set; }
        public IFileParameter FileParameter { get; set; }
        public string Content { get => content; set => content = value; }


        #endregion

        #region Constructors
        public File()
        {

        }
        public File(IFileParameter fileParameter) => this.FileParameter = fileParameter;

        #endregion

        #region Delegates

        private delegate void generationFunction();

        #endregion

        #region Public Methods

        public List<string> GetAllLines() => JoinParts();
        public virtual IResponse Generate() => Control.RunMethod(Generation);

        #endregion

        #region Private Methods
        private void SetContent(string value) => Content = value;
        private List<string> JoinParts()
        {
            LstLines = Header.Join(Body, Footer);
            return this.LstLines;
        }

        private Subprocess GetSubprocess() => _subprocess;

        private void SetSubprocess(Subprocess value) => _subprocess = value;

        private IResponse Generation()
        {
            IResponse response = new Class.Response();
            this.SetSubprocess(Subprocess.Header);
            bool IsOK;
            do
            {
                switch (GetSubprocess())
                {
                    case Subprocess.Header:
                        response = Header.Generate();
                        SetSubprocess(Subprocess.Body);
                        break;
                    case Subprocess.Body:
                        response = Body.Generate();
                        SetSubprocess(Subprocess.Footer);
                        break;
                    case Subprocess.Footer:
                        response = Footer.Generate();
                        SetSubprocess(Subprocess.Format);
                        break;
                    case Subprocess.Format:
                        response = Format.FormatFile(GetAllLines(), out string result);
                        SetContent(result);
                        response.SetResult<string>(result);
                        SetSubprocess(Subprocess.End);
                        break;
                }
                IsOK = response.GetSuccess();
            } while (IsOK && !this.GetSubprocess().Equals(Subprocess.End));
            if (response.GetSuccess())
                response.SetOk("File Generated!");
            return response;
        }

        #endregion

        #region Enumerators

        protected enum Subprocess
        {
            Header,
            Body,
            Footer,
            Format,
            End
        }

        #endregion
    }
}
