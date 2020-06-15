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
    public class G
    {
        public void estruturaCurso(Curso cur)
        {
            IMapperCurso map1 = new MapperCurso();
            map1.Create(cur); 
        }

    }
}
