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
    public class H
    {
        public void insert_UC_Curso(UC_Semestre uc_sem)
        {
            IMapperUC_Semestre map = new MapperUC_Semestre();
            map.Create(uc_sem);
        }

        public void remove_UC_Curso(UC_Semestre uc_sem)
        {
            IMapperUC_Semestre map = new MapperUC_Semestre();
            map.Delete(uc_sem);
        }
    }
}
