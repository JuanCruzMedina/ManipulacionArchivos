using MetodosExtension.Model.AbstractClass;
using MetodosExtension.Model.Interface;
using MetodosExtension.Model.StaticClass;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosExtension.Model.Class.ExporterPart
{
    public class FormatRedLink : Format
    {
        private readonly string separator = Environment.NewLine;

        public FormatRedLink(IParameter parameter) : base(parameter) => InitializeFormat();

        private void InitializeFormat()
        {
            LstExtensions = new List<string>() { "txt", "xls", "xlsx" };
        }

        private string FormatFile(List<string> content) => string.Join(separator, content.ToArray());

        public override IResponse FormatFile(List<string> content, out string result) => Control.RunMethod<List<string>, string>(FormatFile, content, out result);
    }
}
