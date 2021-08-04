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
    public class FooterRedLink : Footer
    {
        public FooterRedLink(IParameter parameter) : base(parameter)
        {

        }

        public override IResponse Generate() => Control.RunMethod(CreateFooter);

        private void CreateFooter()
        {
            AddInLastLine("FOOTER");
        }
    }
}
