using MetodosExtension.Model.AbstractClass;
using MetodosExtension.Model.Class;
using MetodosExtension.Model.Interface;
using System;
using System.Collections.Generic;

namespace MetodosExtension
{
    public class Program
    {
        static void Main()
        {
            List<IExportable> lstClientes = new List<IExportable>()
            {
                new Cliente("Juan","Perez",DateTime.Today,60000m),
                new Cliente("Tito","Martinez",DateTime.Today,1321400m),
                new Cliente("Estefano","Dominguez",DateTime.Today,6523400m)
            };

            IFileParameter parametro = new FileParameter()
            {
                Prefix = "Inicio de Linea - ",
                Suffix = " - Fin de Linea",
                ColumnLength = 15,
                LstObjects = lstClientes,
                LstProperties = new List<string>() { "Nombre", "Apellido","FechaNacimiento","Saldo"}
            };

            File archivoRedLink = new RedLinkFile(parametro);
            IResponse resultado = archivoRedLink.Generate();

            Console.WriteLine("Success: " + resultado.GetSuccess());
            Console.WriteLine();
            Console.WriteLine("Message: ");
            Console.WriteLine(resultado.GetMessage());
            Console.WriteLine();
            Console.WriteLine("Result: " + Environment.NewLine);
            Console.WriteLine(resultado.GetResult<string>());

            Console.Read();
        }
        class Cliente : IExportable
        {
            public Cliente(string nombre, string apellido, DateTime fechaNacimiento, decimal saldo)
            {
                Nombre = nombre;
                Apellido = apellido;
                FechaNacimiento = fechaNacimiento;
                Saldo = saldo;
            }

            public string Nombre { get; set; }
            public string Apellido { get; set; }
            public DateTime FechaNacimiento { get; set; }
            public decimal Saldo { get; set; }
        }
    }
}
