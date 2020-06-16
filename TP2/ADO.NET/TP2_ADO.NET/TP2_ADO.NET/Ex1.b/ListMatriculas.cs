using Entidades;
using Mappers;
using Mappers_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_ADO.NET.Ex1.b
{
    public class ListMatriculas
    {
        public void listMatriculas(Ano anoCurrente)
        {
            var total = new Dictionary<string, int>();

            IMapperInscricao map = new MapperInscricao();
    
            List<string> test = map.ReadByYear(anoCurrente);

            foreach (string s in test)
            {
                if (total.ContainsKey(s))
                {
                    total[s] += 1;
                }
                else
                {
                    total.Add(s, 1);
                }

            }

            foreach (KeyValuePair<string, int> kvp in total)
            {
                Console.WriteLine("Unidade Curricular = {0}, Inscrições = {1}", kvp.Key, kvp.Value);
            }
        }
    }
}
