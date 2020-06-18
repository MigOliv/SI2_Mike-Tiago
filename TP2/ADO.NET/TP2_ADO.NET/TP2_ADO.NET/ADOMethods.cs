using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_ADO.NET
{
    class ADOMethods : Methods
    {
        public override void insertDepartamento(String sigla, String descricao) { 
            
        }
        public override void deleteDepartamento(String sigla)
        {

        }
        public override void updateDepartamento(String sigla, String new_descricao)
        {

        }

        public override void insertSeccao(String sigla, String siglaDepartamento, String descricao)
        {

        }
        public override void removeSeccao(String sigla, String siglaDepartamento)
        {

        }
        public override void updateSeccao(String sigla, String siglaDepartamento, String new_descricao)
        {

        }

        public override void insertUC(String sigla, String descricao, int nrCreditos)
        {

        }
        public override void deleteUC(String sigla)
        {

        }
        public override void updateUC(String sigla, String new_descricao, int new_NrCreditos)
        {

        }

        public override void estruturaCurso(String sigla, String siglaDepartamento, String descricao)
        {

        }
        public override void insert_UC_Curso(String siglaCurso, String siglaUC, int ano, int nrSemestre)
        {

        }
        public override void remove_UC_Curso(String siglaCurso, String siglaUC, int ano, int nrSemestre)
        {

        }

        public override void insert_Aluno_Curso(int nrAluno, String siglaCurso, int ano)
        {

        }
        public override void inscrever_Aluno_UC(int nrAluno, String siglaUC, int ano)
        {

        }
        public override void insert_nota(int nrAluno, String siglaUC, double nota, int ano)
        {

        }
        public override void listMatriculas(int anoLetivo)
        {

        }
        public override void deleteAluno(int nrAluno)
        {

        }


    }
}
