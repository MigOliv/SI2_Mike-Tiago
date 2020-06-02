using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    class Aluno
    {
        public int Num { get; set; }
        public int Cc { get; set; }
        public string Nome { get; set; }
        public string Rua { get; set; }
        public int NumeroRua { get; set; }
        public string Andar { get; set; }
        public string CodigoPostal { get; set; }
        public DateTime DataNascimento { get; set; }
    }
}
