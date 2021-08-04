using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosExtension.Model.Interface
{
    public interface IBodyParameter : IParameter
    {
        int GetColumnsCount();
        int GetColumnsLength();
        int GetRowsCount();
        int GetRowsLength();
        string GetPrefix();
        string GetSuffix();
        List<IExportable> GetObjects();
        List<string> GetProperties();
    }
}
