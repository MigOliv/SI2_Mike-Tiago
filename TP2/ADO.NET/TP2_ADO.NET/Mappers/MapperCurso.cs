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
    public class MapperCurso : IMapperCurso
    {
        private string cs;

        public MapperCurso()
        {
            cs = ConfigurationManager.ConnectionStrings["SI2 Database"].ConnectionString;
        }


        public void Create(Curso a)
        {
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {

                SqlCommand cmd = new SqlCommand("estruturaCurso");
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@siglaDepartamento", a.SiglaDepartamento);
                p1.Direction = ParameterDirection.Input;
                SqlParameter p2 = new SqlParameter("@siglaCurso", a.Sigla);
                p2.Direction = ParameterDirection.Input;
                SqlParameter p3 = new SqlParameter("@descricaoCurso", a.Descricao);
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


        public void Delete(Curso entity)
        {
            throw new NotImplementedException();
        }

        public Curso Read(String sigla)
        {
            Curso curso = new Curso();
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT @descricao = descricao, @siglaDepartamento = siglaDepartamento, @totalCreditos = totalCreditos FROM Curso where sigla = @sigla";
                SqlParameter p1 = new SqlParameter("@descr", System.Data.SqlDbType.VarChar, 255);
                p1.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p2 = new SqlParameter("@siglaDepartamento", System.Data.SqlDbType.VarChar,255);
                p2.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p3 = new SqlParameter("@totalCreditos", System.Data.SqlDbType.Float);
                p3.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p4 = new SqlParameter("@sigla", sigla);
                cmd.Parameters.Add(p4);
                cmd.ExecuteNonQuery();
                if (p1.Value is System.DBNull)
                    throw new Exception("Não existe Curso com a sigla " + sigla);

                curso.Sigla = sigla;
                curso.Descricao = (string)p1.Value;
                curso.SiglaDepartamento = (string)p2.Value;
                curso.TotalCreditos = (int)p3.Value;

                ts.Complete();
            }

            return curso;
        }

        public void Update(Curso entity)
        {
            throw new NotImplementedException();
        }
    }
}
