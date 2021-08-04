using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosExtension.Model.Interface
{
    public interface IFormat
    {
        IResponse FormatFile(List<string> content, out string result);
        string GetExtensions();
    }
}
