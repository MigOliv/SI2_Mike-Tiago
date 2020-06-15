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
    public class d
    {
        public void insertDepartamento(Departamento dep)
        {
            IMapperDepartamento map = new MapperDepartamento();
            map.Create(dep);
        }

        public void deleteDepartamento(Departamento dep)
        {
            IMapperDepartamento map = new MapperDepartamento();
            map.Delete(dep);
        }

        public void updateDepartamento(Departamento dep)
        {
            IMapperDepartamento map = new MapperDepartamento();
            map.Update(dep);
        }
    }
}
