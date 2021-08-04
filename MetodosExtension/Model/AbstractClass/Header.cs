using MetodosExtension.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosExtension.Model.AbstractClass
{
    public abstract class Header : Part
    {
        public Header() : base ()
        {

        }

        public Header(IParameter parameter) : base (parameter)
        {

        }
    }
}
