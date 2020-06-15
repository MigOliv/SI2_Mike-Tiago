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
    public class MapperMatricula : IMapperMatricula
    {
        private string cs;

        public MapperMatricula()
        {
            cs = ConfigurationManager.ConnectionStrings["SI2 Database"].ConnectionString;
        }


        public void Create(Matricula a)
        {
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {

                SqlCommand cmd = new SqlCommand("insert_Aluno_Curso");
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@numAluno", a.numAluno);
                p1.Direction = ParameterDirection.Input;
                SqlParameter p2 = new SqlParameter("@siglaCurso", a.siglaCurso);
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


        public void Delete(Matricula entity)
        {
            throw new NotImplementedException();
        }


        public Matricula Read(KeyValuePair<int, int> id)
        {
            Matricula matricula = new Matricula();
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT @siglaCurso = siglaCurso FROM Matricula where numAluno = @numAluno AND ano = @ano";
                SqlParameter p1 = new SqlParameter("@siglaCurso", System.Data.SqlDbType.VarChar, 6);
                p1.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p2 = new SqlParameter("@numAluno", id.Key);
                cmd.Parameters.Add(p2);
                SqlParameter p3 = new SqlParameter("@ano", id.Value);
                cmd.Parameters.Add(p3);
                cmd.ExecuteNonQuery();
                if (p1.Value is System.DBNull)
                    throw new Exception("Não existe Matricula com a combinacao numAluno/ano: " + id.Key + "/" + id.Value);

                matricula.siglaCurso = (string)p1.Value;
                matricula.numAluno = id.Key;
                matricula.ano = id.Value;

                ts.Complete();
            }

            return matricula;
        }

        public void Update(Matricula entity)
        {
            throw new NotImplementedException();
        }
    }
}
