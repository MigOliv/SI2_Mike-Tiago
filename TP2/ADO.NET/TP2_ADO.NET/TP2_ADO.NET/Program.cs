using Entidades;
using Mappers_Interface;
using Mappers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TP2_ADO.NET.Ex1.b;

namespace TP2_ADO.NET
{
    class Program
    {
        private enum Option
        {
            Unknown = -1,
            Exit
        }

        private Option DisplayMenu()
        {
            Option option = Option.Unknown;

            return option;

        }
        static void Main(string[] args)
        {








            //TESTES

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

            ListMatriculas lm = new ListMatriculas();
            Ano anoCurrente = new Ano();
            anoCurrente.AnoLetivo = 1920;
            lm.listMatriculas(anoCurrente);
        }
    }
}
