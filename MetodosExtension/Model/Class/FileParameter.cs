using MetodosExtension.Model.AbstractClass;
using MetodosExtension.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosExtension.Model.Class
{
    public class FileParameter : Parameter, IFileParameter, IBodyParameter
    {
        #region Constructors
        public FileParameter(string prefix, string suffix, int rowsCount, int rowsLength, int columnsCount, int columnLength, List<IExportable> lstObjects)
        {
            Prefix = prefix;
            Suffix = suffix;
            RowsCount = rowsCount;
            RowsLength = rowsLength;
            ColumnsCount = columnsCount;
            ColumnLength = columnLength;
            LstObjects = lstObjects;
        }
        public FileParameter()
        {

        }
        #endregion

        #region Properties
        public string Prefix { get; set; }
        public string Suffix { get; set; }
        public int RowsCount { get; set; }
        public int RowsLength { get; set; }
        public int ColumnsCount { get; set; }
        public int ColumnLength { get; set; }
        public List<IExportable> LstObjects { get; set; }
        public List<string> LstProperties { get; set; }


        #endregion

        #region Public Methods

        public int GetColumnsCount() => RowsCount;

        public List<IExportable> GetObjects() => LstObjects;

        public List<string> GetProperties() => LstProperties;

        public int GetRowsCount() => ColumnsCount;

        public int GetColumnsLength() => ColumnLength;

        public int GetRowsLength() => RowsLength;

        public string GetPrefix() => Prefix;

        public string GetSuffix() => Suffix;

        #endregion
    }
}
