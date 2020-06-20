using Entidades;
using Mappers_Interface;
using Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_ADO.NET.Ex1.b;
using EF;
using System.Configuration;
using System.Diagnostics;

namespace TP2_ADO.NET
{
    class Program
    {
        private static bool ADOnEF = false;
        private static Methods methods;
        private static bool isExit = false;
        private static string database = "TP1";

        public static string[] commands =
        {"Inserir um Departamento","Eliminar um Departamento","Atualizar um Departamento","Inserir uma Seccção","Eliminar uma Secção",
            "Atualizar uma Secção","Inserir uma UC","Eliminar uma UC","Atualizar uma UC","Criar uma estrutura de um curso",
            "Inserir uma UC num Semestre","Remover uma UC num Semestre","Matricular um Aluno num Curso","Inscrever um Aluno numa UC num Ano","Atribuir nota",
            "Listar o Total de Matriculas","Eliminar um Aluno", "Trocar o numero de Creditos entre duas UCs","Sair"      
        };

   
        static void Main(string[] args)
        {
            while (!isExit)
            {
                int i = 0;
                foreach (string s in commands)
                {
                    i++;
                    Console.WriteLine(i + " - " + s);
                }

                Console.WriteLine("Insira o número: ");

                string input = Console.ReadLine();
                int n;
                while (!int.TryParse(input, out n) || (n < 0 || n > commands.Length))
                {
                    Console.WriteLine("Tente um número entre 1 e " + commands.Length);
                    input = Console.ReadLine();
                }

                if (ADOnEF) methods = new ADOMethods();
                else methods = new EFMethods();


                RouteCommand(n);

               
            }

              //TESTES
            /*
            using (var context = new TP1Entities())
            {
                var query = context.Alunoes.Where(s => s.num == 39156).FirstOrDefault<EF.Aluno>();

                Console.WriteLine(query.nome);
            }
            */

            /*
            ListMatriculas lm = new ListMatriculas();
            Entidades.Ano anoCurrente = new Entidades.Ano();
            anoCurrente.AnoLetivo = 1920;
            lm.listMatriculas(anoCurrente);
            */
            /*
            //ALINEA K
            Inscricao inscr2 = new Inscricao();
            inscr2.numAluno = 39156;
            inscr2.siglaUC = "SI2";
            inscr2.nota = 20.0;
            inscr2.ano = 1920;

            IMapperInscricao map = new MapperInscricao();
            map.Update(inscr2);
            */


            /*
            // ALINEA J
            Inscricao inscr = new Inscricao();
            inscr.numAluno = 40623;
            inscr.siglaUC = "AVE";
            inscr.ano = 1920;

            IMapperInscricao map = new MapperInscricao();
            map.Create(inscr);
            */


            // ALINEA I
            /*
            Matricula matr = new Matricula();
            matr.numAluno = 39156;
            matr.siglaCurso = "LEC";
            matr.ano = 1819;

            IMapperMatricula map = new MapperMatricula();
            map.Create(matr);
            */


            /*// ALINEA H
            UC_Semestre uc_sem = new UC_Semestre();
            uc_sem.numSemestre = 3;
            uc_sem.siglaCurso = "LEIC";
            uc_sem.siglaUC = "PC";
            uc_sem.ano = 1920;

            IMapperUC_Semestre map = new MapperUC_Semestre();

            //map.Create(uc_sem);
            map.Delete(uc_sem);
            */

            /*
            //ALINEA G
            Curso curs = new Curso();
            curs.SiglaDepartamento = "ADEETC";
            curs.Sigla = "SIP";
            curs.Descricao = "Seguranca de Informação Partilhada";


            IMapperCurso map = new MapperCurso();
            map.Create(curs);
            */


            /*// ALINEA E
            Seccao seccao = new Seccao();
            seccao.Sigla = "TEST";
            seccao.SiglaDepartamento = "ADEC";
            seccao.Descricao = "Teste .net";

            Seccao test = new Seccao();
            test.Sigla = "TEST";
            test.SiglaDepartamento = "ADEC";
            test.Descricao = "Nova Descr";

            IMapperSeccao map = new MapperSeccao();

            //map.Create(seccao);
            //map.Delete(test);
            //map.Update(test);
            */


            /*  ALINEA F
            UnidadeCurricular uc = new UnidadeCurricular();
            uc.Sigla = "TEST";
            uc.Descricao = "Teste do ADO.NET";
            uc.NumCreditos = 10;

            UnidadeCurricular test = new UnidadeCurricular();
            test.Sigla = "TEST";
            test.Descricao = "Uma nova descricao";
            test.NumCreditos = 10;

            IMapperUnidadeCurricular map = new MapperUnidadeCurricular();

            //map.Create(uc);
            //map.Delete(uc);
            //map.Update(test);
            */


            /* // ALINEA 1.c

            IMapperAluno map = new MapperAluno();
            Aluno a = map.Read(39156);
            map.Delete(a);
            */

        }

        private static void RouteCommand(int n)
        {
           try
            {/*
                IDisposable context;
                if (ADOnEF)
                {
                    string conString = ConfigurationManager.ConnectionStrings[database].ConnectionString;
                    context = new Context(conString);
                }
                else context = new Entities();
                */
               
                    Console.Clear();
                    switch (commands[n - 1])
                    {
                        case "Inserir um Departamento": insertDepartamento(); break;
                        case "Eliminar um Departamento": deleteDepartamento(); break;
                        case "Atualizar um Departamento": updateDepartamento(); break;
                        case "Inserir uma Seccção": insertSeccao(); break;
                        case "Eliminar uma Secção": removeSeccao(); break;
                        case "Atualizar uma Secção": updateSeccao(); break;
                        case "Inserir uma UC": insertUC(); break;
                        case "Eliminar uma UC": deleteUC(); break;
                        case "Atualizar uma UC": updateUC(); break;
                        case "Criar uma estrutura de um curso": estruturaCurso(); break;
                        case "Inserir uma UC num Semestre": insert_UC_Curso(); break;
                        case "Remover uma UC num Semestre": remove_UC_Curso(); break;
                        case "Matricular um Aluno num Curso": insert_Aluno_Curso(); break;
                        case "Inscrever um Aluno numa UC num Ano": inscrever_Aluno_UC(); break;
                        case "Atribuir nota": insert_nota(); break;
                        case "Listar o Total de Matriculas": listMatriculas(); break;
                        case "Eliminar um Aluno": deleteAluno(); break;
                        case "Trocar o numero de Creditos entre duas UCs": updateNumCreditos(); break;
                        case "Sair": isExit = true; break;

                    }
            }
            
            catch (Exception e)
            {
                ErrorHandler(e);
            }

            Console.WriteLine("\n");
        }

        private static void updateNumCreditos()
        {
            TP1Entities context1 = new TP1Entities();

            Console.WriteLine("Insira a sigla da primeira UC: ");
            string siglaUC1 = Console.ReadLine();
            Console.WriteLine("Insira a sigla da segunda UC: ");
            string siglaUC2 = Console.ReadLine();
            //methods = new EFMethods();
           
            EFMethods.updateNumCreditos(context1,siglaUC1, siglaUC2);
        }

        private static void deleteAluno()
        {
            int nrAluno = (int)GetNumber(1, "Insira o numero de Aluno: ");
            methods.deleteAluno(nrAluno);

        }

        private static void listMatriculas()
        {
            int ano = (int)GetNumber(1, "Insira o ano Letivo: ");

            var watch = new Stopwatch();
            watch.Start();

            methods.listMatriculas(ano);

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        private static void insert_nota()
        { 
            int nrAluno = (int)GetNumber(1, "Insira o numero de Aluno: ");
            int ano = (int)GetNumber(1, "Insira o ano: ");

            Console.WriteLine("Insira a sigla da UC: ");
            string siglaUC = Console.ReadLine();
            
            decimal nota = (decimal)GetNumber(1, "Insira a nota: ");

            methods.insert_nota(nrAluno, siglaUC, nota, ano);

        }

        private static void inscrever_Aluno_UC()
        {
            int nrAluno = (int)GetNumber(1, "Insira o numero de Aluno: ");
            int ano = (int)GetNumber(1, "Insira o ano: ");

            Console.WriteLine("Insira a sigla da UC: ");
            string siglaUC = Console.ReadLine();

            methods.inscrever_Aluno_UC(nrAluno, siglaUC, ano);
        }

        private static void insert_Aluno_Curso()
        {
            int nrAluno = (int)GetNumber(1, "Insira o numero de Aluno: ");
            int ano = (int)GetNumber(1, "Insira o ano: ");

            Console.WriteLine("Insira a sigla do Curso: ");
            string siglaCurso = Console.ReadLine();

            methods.insert_Aluno_Curso(nrAluno, siglaCurso, ano);

        }

        private static void remove_UC_Curso()
        {
            Console.WriteLine("Insira a sigla do Curso: ");
            string siglaCurso = Console.ReadLine();
            Console.WriteLine("Insira a sigla da UC: ");
            string siglaUC = Console.ReadLine();
            
            int ano = (int)GetNumber(1, "Insira o ano: ");
            int nrSemestre = (int)GetNumber(1, "Insira o numero do Semestre: ");

            methods.remove_UC_Curso(siglaCurso, siglaUC, ano, nrSemestre);
        }

        private static void insert_UC_Curso()
        {
            Console.WriteLine("Insira a sigla do Curso: ");
            string siglaCurso = Console.ReadLine();
            Console.WriteLine("Insira a sigla da UC: ");
            string siglaUC = Console.ReadLine();

            int ano = (int)GetNumber(1, "Insira o ano: ");
            int nrSemestre = (int)GetNumber(1, "Insira o numero do Semestre: ");

            var watch = new Stopwatch();
            watch.Start();

            methods.insert_UC_Curso(siglaCurso, siglaUC, ano, nrSemestre);

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        private static void estruturaCurso()
        {
            Console.WriteLine("Insira a sigla do Departamento: ");
            string siglaDepartamento = Console.ReadLine();
            Console.WriteLine("Insira a sigla do Curso: ");
            string siglaCurso = Console.ReadLine();
            Console.WriteLine("Insira a descricao: ");
            string descricao = Console.ReadLine();

            methods.estruturaCurso(siglaCurso, siglaDepartamento, descricao);
        }

        private static void updateUC()
        {
            Console.WriteLine("Insira a sigla da UC: ");
            string siglaUC = Console.ReadLine();
            Console.WriteLine("Insira a nova descricao: ");
            string new_descricao = Console.ReadLine();

            int new_nrCreditos = (int)GetNumber(1, "Insira o numero de creditos: ");

            methods.updateUC(siglaUC, new_descricao, new_nrCreditos);
        }

        private static void deleteUC()
        {

            TP1Entities context1 = new TP1Entities();

            Console.WriteLine("Insira a sigla da UC: ");
            string siglaUC = Console.ReadLine();
            //methods.deleteUC(siglaUC);

            EFMethods.deleteUC(context1, siglaUC);
        }

        private static void insertUC()
        {
            Console.WriteLine("Insira a sigla da UC: ");
            string siglaUC = Console.ReadLine();
            Console.WriteLine("Insira a nova descricao: ");
            string descricao = Console.ReadLine();

            int nrCreditos = (int)GetNumber(1, "Insira o numero de creditos: ");

            methods.insertUC(siglaUC, descricao, nrCreditos);
        }

        private static void updateSeccao()
        {

            Console.WriteLine("Insira a sigla do Departamento: ");
            string siglaDepartamento = Console.ReadLine();
            Console.WriteLine("Insira a sigla da Seccao: ");
            string siglaSeccao = Console.ReadLine();
            Console.WriteLine("Insira a nova descricao: ");
            string new_descricao = Console.ReadLine();

            methods.updateSeccao(siglaSeccao, siglaDepartamento, new_descricao);
        }

        private static void removeSeccao()
        {
            Console.WriteLine("Insira a sigla do Departamento: ");
            string siglaDepartamento = Console.ReadLine();
            Console.WriteLine("Insira a sigla da Seccao: ");
            string siglaSeccao = Console.ReadLine();

            methods.removeSeccao(siglaSeccao, siglaDepartamento);
        }

        private static void insertSeccao()
        {

            Console.WriteLine("Insira a sigla do Departamento: ");
            string siglaDepartamento = Console.ReadLine();
            Console.WriteLine("Insira a sigla da Seccao: ");
            string siglaSeccao = Console.ReadLine();
            Console.WriteLine("Insira a descricao: ");
            string descricao = Console.ReadLine();

            methods.insertSeccao(siglaSeccao, siglaDepartamento, descricao);
        }

        private static void updateDepartamento()
        {
            Console.WriteLine("Insira a sigla do Departamento: ");
            string siglaDepartamento = Console.ReadLine();
            Console.WriteLine("Insira a nova descricao: ");
            string descricao = Console.ReadLine();

            var watch = new Stopwatch();
            watch.Start();

            methods.updateDepartamento(siglaDepartamento, descricao);

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }

        private static void deleteDepartamento()
        {
            Console.WriteLine("Insira a sigla do Departamento: ");
            string siglaDepartamento = Console.ReadLine();

            var watch = new Stopwatch();
            watch.Start();

            methods.deleteDepartamento(siglaDepartamento);

            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }


        private static void insertDepartamento()
        {
            Console.WriteLine("Insira a sigla do Departamento: ");
            string siglaDepartamento = Console.ReadLine();
            Console.WriteLine("Insira a descricao: ");
            string descricao = Console.ReadLine();

            var watch = new Stopwatch();
            watch.Start();

            methods.insertDepartamento(siglaDepartamento, descricao);
            
            watch.Stop();
            Console.WriteLine($"Execution Time: {watch.ElapsedMilliseconds} ms");
        }



        public static double GetNumber(double min, string request)
        {
            double number = min - 1;
            while (number == min - 1)
            {
                Console.WriteLine(request);
                string snumber = Console.ReadLine();
                if (!double.TryParse(snumber, out number))
                {
                    Console.WriteLine("Valor Inválido");
                }
                else if (number <= min - 1)
                {
                    number = min - 1;
                    Console.WriteLine("Valor Inválido");
                }
            }
            return number;
        }

        public static void WaitForEnter()
        {
            Console.WriteLine("Carregue em algo para continuar.");
            Console.ReadKey();
            Console.Clear();
        }

        private static void ErrorHandler(Exception e)
        {
            Console.WriteLine(e.Message);
            WaitForEnter();
            Console.Clear();
        }
    }



}
