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
    public class I
    {
        public void insert_Aluno_Curso(Matricula matr_aluno)
        {
            IMapperMatricula map = new MapperMatricula();
            map.Create(matr_aluno);
        }
    }
}
