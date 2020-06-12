using Entidades;
using Mappers_Interface;
using Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_ADO.NET
{
    class Program
    {
        static void Main(string[] args)
        {
            Departamento dep = new Departamento();
            dep.Sigla = "TEST";
            dep.Descricao = "Teste do ADO.NET";

            IMapperDepartamento map = new MapperDepartamento();

            map.Create(dep);

        }
    }
}
