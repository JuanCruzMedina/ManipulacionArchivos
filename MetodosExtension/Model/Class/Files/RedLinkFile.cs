using MetodosExtension.Model.AbstractClass;
using MetodosExtension.Model.Class.ExporterPart;
using MetodosExtension.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosExtension.Model.Class
{
    public class RedLinkFile : File
    {
        public RedLinkFile(IFileParameter fileParameter)
        {
            FileParameter = fileParameter as FileParameter;
            Initialize();
        }
        private void Initialize()
        {
            Header = new HeaderRedLink(FileParameter);
            Body = new BodyRedLink(FileParameter);
            Footer = new FooterRedLink(FileParameter);
            Format = new FormatRedLink(FileParameter);
        }
    }
}
