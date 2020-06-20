using Entidades;
using Mappers;
using Mappers_Interface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TP2_ADO.NET
{
    class ADOMethods : Methods
    {
        public override void insertDepartamento(String sigla, String descricao) 
        {
            try
            {
                Departamento dep = new Departamento();
                dep.Sigla = sigla;
                dep.Descricao = descricao;

                IMapperDepartamento map = new MapperDepartamento();

                map.Create(dep);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Erro na inserção");
            }
        }

        public override void deleteDepartamento(String sigla)
        { 
            try
            {
                Departamento dep = new Departamento();
                dep.Sigla = sigla;

                IMapperDepartamento map = new MapperDepartamento();

                map.Delete(dep);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Departamento nao pode ser removido ou nao existe");

            }
        }

        public override void updateDepartamento(String sigla, String new_descricao)
        {
            try
            {
                Departamento dep = new Departamento();
                dep.Sigla = sigla;
                dep.Descricao = new_descricao;

                IMapperDepartamento map = new MapperDepartamento();

                map.Update(dep);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Departamento nao pode ser atualizado ou nao existe");
            }
        }

        public override void insertSeccao(String sigla, String siglaDepartamento, String descricao)
        {
            try
            {
                Seccao seccao = new Seccao();
                seccao.Sigla = sigla;
                seccao.SiglaDepartamento = siglaDepartamento;
                seccao.Descricao = descricao;

                IMapperSeccao map = new MapperSeccao();

                map.Create(seccao);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Erro de inserção");
            }
        }

        public override void removeSeccao(String sigla, String siglaDepartamento)
        {
            try
            {
                Seccao seccao = new Seccao();
                seccao.Sigla = sigla;
                seccao.SiglaDepartamento = siglaDepartamento;

                IMapperSeccao map = new MapperSeccao();

                map.Delete(seccao);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Secção nao pode ser removida ou nao existe");
            }
        }

        public override void updateSeccao(String sigla, String siglaDepartamento, String new_descricao)
        {
            try
            {
                Seccao seccao = new Seccao();
                seccao.Sigla = sigla;
                seccao.SiglaDepartamento = siglaDepartamento;
                seccao.Descricao = new_descricao;

                IMapperSeccao map = new MapperSeccao();

                map.Update(seccao);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Secção nao pode ser atualizada ou nao existe");
            }
        }

        public override void insertUC(String sigla, String descricao, int nrCreditos)
        {
            try
            {
                UnidadeCurricular uc = new UnidadeCurricular();
                uc.Sigla = sigla;
                uc.Descricao = descricao;
                uc.NumCreditos = nrCreditos;

                IMapperUnidadeCurricular map = new MapperUnidadeCurricular();

                map.Create(uc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Erro de inserção");
            }

        }
        public override void deleteUC(String sigla)
        {
            try
            {
                UnidadeCurricular uc = new UnidadeCurricular();
                uc.Sigla = sigla;
                IMapperUnidadeCurricular map = new MapperUnidadeCurricular();
                map.Delete(uc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("UC não pode ser removida ou não existe");
            }
        }

        public override void updateUC(String sigla, String new_descricao, int new_NrCreditos)
        {
            try
            {
                UnidadeCurricular uc = new UnidadeCurricular();
                uc.Sigla = sigla;
                uc.Descricao = new_descricao;
                uc.NumCreditos = new_NrCreditos;

                IMapperUnidadeCurricular map = new MapperUnidadeCurricular();

                map.Update(uc);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("UC não pode ser atualizada ou não existe");
            }
        }

        public override void estruturaCurso(String sigla, String siglaDepartamento, String descricao)
        {
            try
            {
                Curso curs = new Curso();
                curs.SiglaDepartamento = siglaDepartamento;
                curs.Sigla = sigla;
                curs.Descricao = descricao;


                IMapperCurso map = new MapperCurso();
                map.Create(curs);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Erro de inserção");
            }
        }

        public override void insert_UC_Curso(String siglaCurso, String siglaUC, int ano, int nrSemestre)
        {
            try
            {
                UC_Semestre uc_sem = new UC_Semestre();
                uc_sem.numSemestre = nrSemestre;
                uc_sem.siglaCurso = siglaCurso;
                uc_sem.siglaUC = siglaUC;
                uc_sem.ano = ano;

                IMapperUC_Semestre map = new MapperUC_Semestre();

                map.Create(uc_sem);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Erro de inserção");
            }
        }

        public override void remove_UC_Curso(String siglaCurso, String siglaUC, int ano, int nrSemestre)
        {
            try
            {
                UC_Semestre uc_sem = new UC_Semestre();
                uc_sem.numSemestre = nrSemestre;
                uc_sem.siglaCurso = siglaCurso;
                uc_sem.siglaUC = siglaUC;
                uc_sem.ano = ano;

                IMapperUC_Semestre map = new MapperUC_Semestre();

                map.Delete(uc_sem);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Erro de inserção");
            }
        }

        public override void insert_Aluno_Curso(int nrAluno, String siglaCurso, int ano)
        {
            try
            {
                Matricula matr = new Matricula();
                matr.numAluno = nrAluno;
                matr.siglaCurso = siglaCurso;
                matr.ano = ano;

                IMapperMatricula map = new MapperMatricula();
                map.Create(matr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Erro de inserção");
            }
        }

        public override void inscrever_Aluno_UC(int nrAluno, String siglaUC, int ano)
        {
            try
            {
                Inscricao inscr = new Inscricao();
                inscr.numAluno = nrAluno;
                inscr.siglaUC = siglaUC;
                inscr.ano = ano;

                IMapperInscricao map = new MapperInscricao();
                map.Create(inscr);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Erro de inserção");
            }

        }

        public override void insert_nota(int nrAluno, String siglaUC, decimal nota, int ano)
        {
            try
            {
                Inscricao inscr2 = new Inscricao();
                inscr2.numAluno = nrAluno;
                inscr2.siglaUC = siglaUC;
                inscr2.nota = nota;
                inscr2.ano = ano;

                IMapperInscricao map = new MapperInscricao();
                map.Update(inscr2);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Erro de inserção");
            }
        }

        public override void listMatriculas(int anoLetivo)
        {
            try
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
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Erro de inserção");
            }
        }


        public override void deleteAluno(int nrAluno)
        {
            try
            {
                IMapperAluno map = new MapperAluno();
                Aluno a = map.Read(nrAluno);
                map.Delete(a);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.WriteLine("Aluno não pode ser removido ou não existe");
            }
        }


    }
}
