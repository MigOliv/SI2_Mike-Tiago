using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mappers_Interface
{
    public interface IMapperInscricao : IMapper<Inscricao, int>
    {
        List<string> ReadByYear(int anoCurrente);
    }
}