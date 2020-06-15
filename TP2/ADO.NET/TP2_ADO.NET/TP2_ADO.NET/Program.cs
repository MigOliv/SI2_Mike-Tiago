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
        private enum Option
        {
            Unknown = -1,
            Exit
        }

        private Option DisplayMenu()
        {
            Option option = Option.Unknown;

            return option;

        }
        static void Main(string[] args)
        {








            //TESTES

            UnidadeCurricular uc = new UnidadeCurricular();
            uc.Sigla = "TEST";
            uc.Descricao = "Teste do ADO.NET";
            uc.NumCreditos = 10;

            UnidadeCurricular test = new UnidadeCurricular();
            test.Sigla = "TEST";
            test.Descricao = "Uma nova descricao";
            test.NumCreditos = 10;

            IMapperUnidadeCurricular map = new MapperUnidadeCurricular();

            //map.Create(uc);
            //map.Delete(uc);

            map.Update(test);






            /*
            Departamento dep = new Departamento();
            dep.Sigla = "TEST";
            dep.Descricao = "Teste do ADO.NET";

            Departamento test = new Departamento();
            test.Sigla = "TEST";
            test.Descricao = "Uma nova descricao";

            IMapperDepartamento map = new MapperDepartamento();
            */
            //map.Create(dep);
            //map.Update(test);
            //Departamento test = map.Read("YAAA");
            //map.Delete(test);
            //test.Sigla = "YAAA";
            //map.Create(test);
            //map.Delete(dep);

        }
    }
}
