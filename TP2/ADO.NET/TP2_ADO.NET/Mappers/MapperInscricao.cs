using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Entidades;
using Mappers_Interface;

namespace Mappers
{
    public class MapperInscricao : IMapperInscricao
    {
        private string cs;

        public MapperInscricao()
        {
            cs = ConfigurationManager.ConnectionStrings["SI2 Database"].ConnectionString;
        }


        public void Create(Inscricao a)
        {
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {

                SqlCommand cmd = new SqlCommand("inscrever_Aluno_UC");
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@numAluno", a.numAluno);
                p1.Direction = ParameterDirection.Input;
                SqlParameter p2 = new SqlParameter("@siglaUC", a.siglaUC);
                p2.Direction = ParameterDirection.Input;
                SqlParameter p3 = new SqlParameter("@ano", a.ano);
                p3.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);

                using (var cn = new SqlConnection(cs))
                {

                    cmd.Connection = cn;
                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
                ts.Complete();
            }
        }


        public void Delete(Inscricao entity)
        {
            throw new NotImplementedException();
        }

        public Inscricao Read(int numAluno, String siglaCurso, String siglaSemestreLetivo, int ano, String siglaUC)
        {
            /*
            Inscricao inscricao = new Inscricao();
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT @nota = nota FROM Inscricao where numAluno = @numAluno AND siglaCurso = @siglaCurso AND siglaSemestreLetivo = @siglaSemestreLetivo AND ano = @ano AND siglaUC = @siglaUC";
                SqlParameter p1 = new SqlParameter("@nota", System.Data.SqlDbType.Float);
                p1.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p2 = new SqlParameter("@numAluno", numAluno);
                cmd.Parameters.Add(p2);
                SqlParameter p3 = new SqlParameter("@siglaCurso", siglaCurso);
                cmd.Parameters.Add(p3);
                SqlParameter p4 = new SqlParameter("@siglaSemestreLetivo", siglaSemestreLetivo);
                cmd.Parameters.Add(p4);
                SqlParameter p5 = new SqlParameter("@ano", ano);
                cmd.Parameters.Add(p5);
                SqlParameter p6 = new SqlParameter("@siglaUC", siglaUC);
                cmd.Parameters.Add(p6);
                cmd.ExecuteNonQuery();
                if (p1.Value is System.DBNull)
                    throw new Exception("Não existe Inscricao com a chave fornecida: " + numAluno + "/" + siglaCurso + "/" + siglaSemestreLetivo +"/"+ano+"/"+siglaUC);

                inscricao.nota = (float)p1.Value;
                inscricao.numAluno = numAluno;
                inscricao.siglaCurso = siglaCurso;
                inscricao.siglaSemestreLetivo = siglaSemestreLetivo;
                inscricao.ano = ano;
                inscricao.siglaUC = siglaUC;

                ts.Complete();
            }

            return inscricao;
            */
            throw new NotImplementedException();
        }

        public Inscricao Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Inscricao entity)
        {
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {

                SqlCommand cmd = new SqlCommand("insert_nota");
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@numAluno", entity.numAluno);
                p1.Direction = ParameterDirection.Input;
                SqlParameter p2 = new SqlParameter("@siglaUC", entity.siglaUC);
                p2.Direction = ParameterDirection.Input;
                SqlParameter p3 = new SqlParameter("@nota", entity.nota);
                p3.Direction = ParameterDirection.Input;
                SqlParameter p4 = new SqlParameter("@ano", entity.ano);
                p4.Direction = ParameterDirection.Input;


                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);

                using (var cn = new SqlConnection(cs))
                {
                    cmd.Connection = cn;
                    cn.Open();

                    cmd.ExecuteNonQuery();
                }

                ts.Complete();
            }
        }
    }
}
