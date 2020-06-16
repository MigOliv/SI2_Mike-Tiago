using Entidades;
using Mappers;
using Mappers_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_ADO.NET.Ex1.c
{
    public class DeleteAluno
    {
        public void deleteAluno(Aluno a) 
        {
            IMapperAluno map = new MapperAluno();
            map.Delete(a);
        }
    }
}
