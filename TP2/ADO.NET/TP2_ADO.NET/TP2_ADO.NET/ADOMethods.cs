using Entidades;
using Mappers;
using Mappers_Interface;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_ADO.NET
{
    class ADOMethods : Methods
    {
        public override void insertDepartamento(String sigla, String descricao) 
        {
            
                Departamento dep = new Departamento();
                dep.Sigla = sigla;
                dep.Descricao = descricao;

                IMapperDepartamento map = new MapperDepartamento();

                map.Create(dep);
            
        }

        public override void deleteDepartamento(String sigla)
        { 
                Departamento dep = new Departamento();
                dep.Sigla = sigla;

                IMapperDepartamento map = new MapperDepartamento();

                map.Delete(dep);
            
        }

        public override void updateDepartamento(String sigla, String new_descricao)
        {
                Departamento dep = new Departamento();
                dep.Sigla = sigla;
                dep.Descricao = new_descricao;

                IMapperDepartamento map = new MapperDepartamento();

                map.Update(dep);
            
        }

        public override void insertSeccao(String sigla, String siglaDepartamento, String descricao)
        {
                Seccao seccao = new Seccao();
                seccao.Sigla = sigla;
                seccao.SiglaDepartamento = siglaDepartamento;
                seccao.Descricao = descricao;

                IMapperSeccao map = new MapperSeccao();

                map.Create(seccao);
            
        }

        public override void removeSeccao(String sigla, String siglaDepartamento)
        {
                Seccao seccao = new Seccao();
                seccao.Sigla = sigla;
                seccao.SiglaDepartamento = siglaDepartamento;

                IMapperSeccao map = new MapperSeccao();

                map.Delete(seccao);
            
        }

        public override void updateSeccao(String sigla, String siglaDepartamento, String new_descricao)
        {
                Seccao seccao = new Seccao();
                seccao.Sigla = sigla;
                seccao.SiglaDepartamento = siglaDepartamento;
                seccao.Descricao = new_descricao;

                IMapperSeccao map = new MapperSeccao();

                map.Update(seccao);
            
        }

        public override void insertUC(String sigla, String descricao, int nrCreditos)
        {
                UnidadeCurricular uc = new UnidadeCurricular();
                uc.Sigla = sigla;
                uc.Descricao = descricao;
                uc.NumCreditos = nrCreditos;

                IMapperUnidadeCurricular map = new MapperUnidadeCurricular();

                map.Create(uc);
            

        }
        public override void deleteUC(String sigla)
        {
                UnidadeCurricular uc = new UnidadeCurricular();
                uc.Sigla = sigla;
                IMapperUnidadeCurricular map = new MapperUnidadeCurricular();
                map.Delete(uc);
            
        }

        public override void updateUC(String sigla, String new_descricao, int new_NrCreditos)
        {
                UnidadeCurricular uc = new UnidadeCurricular();
                uc.Sigla = sigla;
                uc.Descricao = new_descricao;
                uc.NumCreditos = new_NrCreditos;

                IMapperUnidadeCurricular map = new MapperUnidadeCurricular();

                map.Update(uc);
            
        }

        public override void estruturaCurso(String sigla, String siglaDepartamento, String descricao)
        {
                Curso curs = new Curso();
                curs.SiglaDepartamento = siglaDepartamento;
                curs.Sigla = sigla;
                curs.Descricao = descricao;


                IMapperCurso map = new MapperCurso();
                map.Create(curs);
            
        }

        public override void insert_UC_Curso(String siglaCurso, String siglaUC, int ano, int nrSemestre)
        {
                UC_Semestre uc_sem = new UC_Semestre();
                uc_sem.numSemestre = nrSemestre;
                uc_sem.siglaCurso = siglaCurso;
                uc_sem.siglaUC = siglaUC;
                uc_sem.ano = ano;

                IMapperUC_Semestre map = new MapperUC_Semestre();

                map.Create(uc_sem);
            
        }

        public override void remove_UC_Curso(String siglaCurso, String siglaUC, int ano, int nrSemestre)
        {
                UC_Semestre uc_sem = new UC_Semestre();
                uc_sem.numSemestre = nrSemestre;
                uc_sem.siglaCurso = siglaCurso;
                uc_sem.siglaUC = siglaUC;
                uc_sem.ano = ano;

                IMapperUC_Semestre map = new MapperUC_Semestre();

                map.Delete(uc_sem);
            
        }

        public override void insert_Aluno_Curso(int nrAluno, String siglaCurso, int ano)
        {
                Matricula matr = new Matricula();
                matr.numAluno = nrAluno;
                matr.siglaCurso = siglaCurso;
                matr.ano = ano;

                IMapperMatricula map = new MapperMatricula();
                map.Create(matr);
            
        }

        public override void inscrever_Aluno_UC(int nrAluno, String siglaUC, int ano)
        {
                Inscricao inscr = new Inscricao();
                inscr.numAluno = nrAluno;
                inscr.siglaUC = siglaUC;
                inscr.ano = ano;

                IMapperInscricao map = new MapperInscricao();
                map.Create(inscr);
            

        }

        public override void insert_nota(int nrAluno, String siglaUC, decimal nota, int ano)
        {
                Inscricao inscr2 = new Inscricao();
                inscr2.numAluno = nrAluno;
                inscr2.siglaUC = siglaUC;
                inscr2.nota = nota;
                inscr2.ano = ano;

                IMapperInscricao map = new MapperInscricao();
                map.Update(inscr2);
            
        }

        public override void listMatriculas(int anoLetivo)
        {
                var total = new Dictionary<string, int>();

                IMapperInscricao map = new MapperInscricao();

                List<string> test = map.ReadByYear(anoLetivo);

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


        public override void deleteAluno(int nrAluno)
        {
            IMapperAluno map = new MapperAluno();
            Aluno a = map.Read(nrAluno);
            map.Delete(a); 
        }
    }
}
