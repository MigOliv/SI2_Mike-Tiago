using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EF
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new TP1Entities())
            {
                var query = context.Alunoes.Where(s => s.num == 39156).FirstOrDefault<Aluno>();

                Console.WriteLine(query.nome);
            }
        }
    }
}
