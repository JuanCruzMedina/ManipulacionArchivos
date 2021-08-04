using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosExtension.Model.Interface
{
    public interface IFile
    {
        IResponse Generate();
        List<string> GetAllLines();
    }
}
