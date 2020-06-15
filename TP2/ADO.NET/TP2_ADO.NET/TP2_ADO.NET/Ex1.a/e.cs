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
    public class e
    {
        public void insertSeccao(Seccao seccao)
        {
            IMapperSeccao map = new MapperSeccao();
            map.Create(seccao);
        }

        public void removeSeccao(Seccao seccao)
        {
            IMapperSeccao map = new MapperSeccao();
            map.Delete(seccao);
        }

        public void updateSeccao(Seccao seccao)
        {
            IMapperSeccao map = new MapperSeccao();
            map.Update(seccao);
        }
    }
}
