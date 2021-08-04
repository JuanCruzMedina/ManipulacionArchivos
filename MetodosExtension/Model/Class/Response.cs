using MetodosExtension.Model.Interface;
using MetodosExtension.Model.StaticClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosExtension.Model.Class
{
    public class Response : IResponse
    {
        #region Properties

        private bool Success { get; set; }
        private List<string> ListMessages { get; set; }
        private object Result { get; set; }

        #endregion

        #region Constructor

        public Response() => InitializeResponse();

        #endregion

        #region Private Methods

        private void InitializeResponse()
        {
            this.Success = true;
            this.ListMessages = new List<string>();
        }

        #endregion

        #region Public Methods

        public void SetError(string message)
        {
            this.ListMessages.Add(message);
            this.Success = false;
        }
        public void SetOk(string message)
        {
            this.ListMessages.Add(message);
            this.Success = true;
        }

        private string GetAllMessages(MessageFormat messageFormat = MessageFormat.List)
        {
            (string msg, string title) = Success ? ("OK", "Sucessful Result.") : ("Error", "Error Found:");

            switch (messageFormat)
            {
                case MessageFormat.List:
                    return ListMessages.Count.Equals(0) ? msg : string.Format("{0}{1}{2}", title, Environment.NewLine, string.Join("\n", this.ListMessages.ToArray()));
                default:
                    return ListMessages.Count.Equals(0) ? msg : string.Format("{0}", string.Join("\n", this.ListMessages.ToArray()));
            }
        }

        public string GetMessage() => GetAllMessages();
        public bool GetSuccess() => this.Success;
        public T GetResult<T>() => (T)Result;
        public void SetResult<T>(T value) => Result = value;

        #endregion

        #region Enumerators

        public enum MessageFormat
        {
            Simple,
            List
        }

        #endregion
    }
}
