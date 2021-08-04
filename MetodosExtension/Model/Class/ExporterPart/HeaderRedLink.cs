using MetodosExtension.Model.AbstractClass;
using MetodosExtension.Model.Interface;
using MetodosExtension.Model.StaticClass;
using System;

namespace MetodosExtension.Model.Class.ExporterPart
{
    public class HeaderRedLink : Header
    {
        public HeaderRedLink(IParameter parameter) : base(parameter)
        {
            InitializePart();
        }
        
        public override IResponse Generate() => Control.RunMethod(CreateHeader);

        private void CreateHeader()
        {
            AddInLastLine("HEADER_RedLink_File _" + DateTime.Today.ToString("dd-MM-yyyy hh:mm:ss"));
        }
    }
}
