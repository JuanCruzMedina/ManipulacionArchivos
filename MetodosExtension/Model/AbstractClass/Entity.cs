using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MetodosExtension.Model;
using MetodosExtension.Model.Interface;

namespace MetodosExtension.Model.AbstractClass
{
    public abstract class Entity
    {
        public abstract IResponse Export(IParameter exporterParameter);
        public abstract IResponse Import(IParameter importParameter);
    }
}
