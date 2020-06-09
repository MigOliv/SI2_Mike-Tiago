using Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IMappers
{
    public interface IMapperProfessorUC : IMapper<ProfessorUC, int>
    {
        ProfessorUC Read(int ccProfessor, string siglaUC, int ano);
    }
}
