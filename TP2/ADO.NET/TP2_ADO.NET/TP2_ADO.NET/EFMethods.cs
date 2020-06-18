using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_ADO.NET
{
    class EFMethods : Methods
    {
        public override void deleteAluno(int nrAluno)
        {
            throw new NotImplementedException();
        }

        public override void deleteDepartamento(string sigla)
        {
            throw new NotImplementedException();
        }

        public override void deleteUC(string sigla)
        {
            throw new NotImplementedException();
        }

        public override void estruturaCurso(string sigla, string siglaDepartamento, string descricao)
        {
            throw new NotImplementedException();
        }

        public override void inscrever_Aluno_UC(int nrAluno, string siglaUC, int ano)
        {
            throw new NotImplementedException();
        }

        public override void insertDepartamento(string sigla, string descricao)
        {
            throw new NotImplementedException();
        }

        public override void insertSeccao(string sigla, string siglaDepartamento, string descricao)
        {
            throw new NotImplementedException();
        }

        public override void insertUC(string sigla, string descricao, int nrCreditos)
        {
            throw new NotImplementedException();
        }

        public override void insert_Aluno_Curso(int nrAluno, string siglaCurso, int ano)
        {
            throw new NotImplementedException();
        }

        public override void insert_nota(int nrAluno, string siglaUC, double nota, int ano)
        {
            throw new NotImplementedException();
        }

        public override void insert_UC_Curso(string siglaCurso, string siglaUC, int ano, int nrSemestre)
        {
            throw new NotImplementedException();
        }

        public override void listMatriculas(int anoLetivo)
        {
            throw new NotImplementedException();
        }

        public override void removeSeccao(string sigla, string siglaDepartamento)
        {
            throw new NotImplementedException();
        }

        public override void remove_UC_Curso(string siglaCurso, string siglaUC, int ano, int nrSemestre)
        {
            throw new NotImplementedException();
        }

        public override void updateDepartamento(string sigla, string new_descricao)
        {
            throw new NotImplementedException();
        }

        public override void updateSeccao(string sigla, string siglaDepartamento, string new_descricao)
        {
            throw new NotImplementedException();
        }

        public override void updateUC(string sigla, string new_descricao, int new_NrCreditos)
        {
            throw new NotImplementedException();
        }
    }
}
