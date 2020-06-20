using EF;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_ADO.NET
{
    public abstract class Methods
    {
        public abstract void insertDepartamento(String sigla, String descricao);
        public abstract void deleteDepartamento(String sigla);
        public abstract void updateDepartamento(String sigla, String new_descricao);

        public abstract void insertSeccao(String sigla, String siglaDepartamento, String descricao);
        public abstract void removeSeccao(String sigla, String siglaDepartamento);
        public abstract void updateSeccao(String sigla, String siglaDepartamento, String new_descricao);

        public abstract void insertUC(String sigla, String descricao, int nrCreditos);
        public abstract void deleteUC(String sigla);
        public abstract void updateUC(String sigla, String new_descricao, int new_NrCreditos);

        public abstract void estruturaCurso(String sigla, String siglaDepartamento, String descricao);
        public abstract void insert_UC_Curso(String siglaCurso, String siglaUC, int ano, int nrSemestre);
        public abstract void remove_UC_Curso(String siglaCurso, String siglaUC, int ano, int nrSemestre);

        public abstract void insert_Aluno_Curso(int nrAluno, String siglaCurso, int ano);
        public abstract void inscrever_Aluno_UC(int nrAluno, String siglaUC, int ano);
        public abstract void insert_nota(int nrAluno, String siglaUC, decimal nota, int ano);
        public abstract void listMatriculas(int anoLetivo);
        public abstract void deleteAluno(int nrAluno);

        //public abstract void updateNumCreditos(DbContext context, string sigla1, string sigla2);
    }
}
