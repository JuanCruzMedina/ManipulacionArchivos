using MetodosExtension.Model.AbstractClass;
using MetodosExtension.Model.Interface;
using MetodosExtension.Model.StaticClass;
using System.Text;

namespace MetodosExtension.Model.Class.ExporterPart
{
    public class BodyRedLink : Body
    {
        public BodyRedLink(IParameter parameter) : base(parameter)
        {
            InitializeBody();
        }
        private void InitializeBody()
        {
            GenerationMethod = CreateBody;
        }

        private void CreateBody<T>(T parameter) where T : IParameter
        {
            if (parameter == null)
                StandardBody();
            else if (parameter is IBodyParameter)
                FullBody<IBodyParameter>(parameter as IBodyParameter);
        }
        private void StandardBody()
        {
            for (int i = 0; i < 15; i++)
                AddInLastLine(string.Format("BODY-LINE {0} - COL1 - COL2 - COL3", i));
        }

        private void FullBody<T>(T parameter) where T : IBodyParameter
        {
            SetBodyProperties(parameter);
            if (LstObjects != null)
            {
                foreach (var item in LstObjects)
                    AddInLastLine(GenerateLine(item, LstProperties));
            }
            else
            {
                for (int i = 1; i < ColumnsCount + 1; i++)
                {
                    StringBuilder newLine = new StringBuilder("Line - " + i + " - ");
                    for (int j = 1; j < RowsCount + 1; j++)
                        newLine.Append("Column " + j + " ");
                    AddInLastLine(newLine.ToString());
                }
            }
        }

        public override IResponse Generate() => Control.RunMethod<IParameter>(GenerationMethod, Parameter);
    }
}
