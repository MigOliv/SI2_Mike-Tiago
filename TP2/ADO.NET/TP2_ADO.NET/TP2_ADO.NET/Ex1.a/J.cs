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
    public class J
    {
        public void inscrever_Aluno_UC(Inscricao inscr)
        {
            IMapperInscricao map = new MapperInscricao();
            map.Create(inscr);
        }
    }
}
