using EF;
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

        public override void deleteDepartamento(string sigla)   //Alinea d
        {
            using (var context = new TP1Entities())
            {
                context.remove_Departamento(sigla);
            }
        }

        public override void deleteUC(string sigla)         //Alinea f
        {
            using (var context = new TP1Entities())
            {
                context.remove_UC(sigla);
            }
        }

        public override void estruturaCurso(string sigla, string siglaDepartamento, string descricao)   //Alinea g
        {
            using (var context = new TP1Entities())
            {
                context.estruturaCurso(siglaDepartamento, sigla, descricao);
            }
        }

        public override void inscrever_Aluno_UC(int nrAluno, string siglaUC, int ano)       //Alinea j
        {
            using (var context = new TP1Entities())
            {
                context.inscrever_Aluno_UC(nrAluno, siglaUC, ano);  // TESTAR
            }
        }

        public override void insertDepartamento(string sigla, string descricao)     //Alinea d
        {
            using (var context = new TP1Entities())
            {
                context.insert_Departamento(sigla, descricao);
            }
        }

        public override void insertSeccao(string sigla, string siglaDepartamento, string descricao)     //Alinea e
        {
            using (var context = new TP1Entities())
            {
                context.insert_Seccao(sigla, siglaDepartamento, descricao);
            }
        }

        public override void insertUC(string sigla, string descricao, int nrCreditos)       //Alinea f
        {
            using (var context = new TP1Entities())
            {
                context.insert_UC(sigla, descricao, nrCreditos);
            }
        }

        public override void insert_Aluno_Curso(int nrAluno, string siglaCurso, int ano)        // Alinea i
        {
            using (var context = new TP1Entities())
            {
                context.insert_Aluno_Curso(nrAluno, siglaCurso, ano);       // TESTAR
            }
        }

        public override void insert_nota(int nrAluno, string siglaUC, decimal nota, int ano)    //Alinea k
        {
            using (var context = new TP1Entities())
            {
                context.insert_nota(nrAluno, siglaUC, nota, ano);       // TESTAR
            }
        }

        public override void insert_UC_Curso(string siglaCurso, string siglaUC, int ano, int nrSemestre)    //Alinea h
        {
            using (var context = new TP1Entities())
            {
                context.insert_UC_Curso(nrSemestre, siglaCurso, siglaUC, ano);      // TESTAR
            }
        }

        public override void listMatriculas(int anoLetivo)
        {
            throw new NotImplementedException();
        }

        public override void removeSeccao(string sigla, string siglaDepartamento)   //Alinea e
        {
            using (var context = new TP1Entities())
            {
                context.remove_Seccao(sigla, siglaDepartamento);
            }
        }

        public override void remove_UC_Curso(string siglaCurso, string siglaUC, int ano, int nrSemestre)    //Alinea h
        {
            using (var context = new TP1Entities())
            {
                context.remove_UC_Curso(siglaCurso, siglaUC, ano);      // TESTAR e verificar porquê o parametro nrSemestre?
            }
        }

        public override void updateDepartamento(string sigla, string new_descricao)     //Alinea d
        {
            using (var context = new TP1Entities())
            {
                context.update_Departamento(sigla, new_descricao);
            }
        }

        public override void updateSeccao(string sigla, string siglaDepartamento, string new_descricao) //Alinea e
        {
            using (var context = new TP1Entities())
            {
                context.update_Seccao(sigla, siglaDepartamento, new_descricao);
            }
        }

        public override void updateUC(string sigla, string new_descricao, int new_NrCreditos)   //Alinea f
        {
            using (var context = new TP1Entities())
            {
                context.update_UC(sigla, new_descricao, new_NrCreditos);
            }
        }
    }
}
