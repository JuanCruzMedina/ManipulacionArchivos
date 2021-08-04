using MetodosExtension.Model.Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MetodosExtension.Model.AbstractClass
{
    public abstract class Body : Part
    {
        #region Properties

        public int ColumnsCount { get; set; }
        public int ColumnsLength { get; set; }
        public int RowsCount { get; set; }
        public int RowsLength { get; set; }
        public List<IExportable> LstObjects { get; set; }
        public List<string> LstProperties { get; set; }
        private string Prefix { get; set; }
        private string Suffix { get; set; }
        #endregion

        #region Contructor

        public Body(IParameter parameter) : base(parameter) { }
        public Body() : base() { }

        #endregion

        #region Protected Methods
        protected void SetBodyProperties(IBodyParameter parameter)
        {
            RowsCount = parameter.GetRowsCount();
            RowsLength = parameter.GetRowsLength();
            ColumnsCount = parameter.GetColumnsCount();
            ColumnsLength = parameter.GetColumnsLength();
            LstObjects = parameter.GetObjects();
            LstProperties = parameter.GetProperties();
            Prefix = parameter.GetPrefix();
            Suffix = parameter.GetSuffix();
        }

        protected List<string> GetProperties<T>(T obj) => obj.GetType().GetProperties().Select(x => x.Name).ToList();

        protected private Dictionary<string, string> GetPropertiesAndValues<T>(T obj)
        {
            var dictionary = new Dictionary<string, string>();
            foreach (System.Reflection.PropertyInfo propertyInfo in obj.GetType().GetProperties())
                dictionary.Add(propertyInfo.Name, propertyInfo.GetValue(obj, null).ToString());
            return dictionary;
        }

        protected string GenerateLine<T>(T obj, List<string> lstProperties = null, string separator = null)
        {
            StringBuilder stringBuilder = new StringBuilder();
            var lstValues = new List<string>();
            var objProperties = GetPropertiesAndValues<T>(obj);
            var lstPropertiesToAdd = lstProperties ?? GetProperties(obj);

            foreach (string name in lstPropertiesToAdd)
            {
                if (objProperties.TryGetValue(name, out string value))
                    lstValues.Add(value);
                else
                    throw new Exception("No se encontro la propiedad especificada.");
            }

            int columnLength = ColumnsLength is 0 ? lstValues.Select(x => x.Length).Max() : ColumnsLength;
            lstValues = lstValues.Select(x => x.Length > columnLength ? x.Substring(0, columnLength - 1) : x.PadRight(columnLength)).ToList();
            stringBuilder.Append(Prefix ?? string.Empty);
            stringBuilder.Append(string.Join(separator ?? string.Empty, lstValues));
            stringBuilder.Append(Suffix ?? string.Empty);

            return stringBuilder.ToString();
        }

        #endregion
    }
}
