using Entidades;
using Mappers;
using Mappers_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_ADO.NET.Ex1.a
{
    public class f
    {
        public void insertUC(UnidadeCurricular uc)
        {
            IMapperUnidadeCurricular map = new MapperUnidadeCurricular();
            map.Create(uc);
        }

        public void deleteUC(UnidadeCurricular uc)
        {
            IMapperUnidadeCurricular map = new MapperUnidadeCurricular();
            map.Delete(uc);
        }

        public void updateDepartamento(UnidadeCurricular uc)
        {
            IMapperUnidadeCurricular map = new MapperUnidadeCurricular();
            map.Update(uc);
        }

    }
}
