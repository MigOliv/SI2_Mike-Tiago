using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Entidades;
using Mappers_Interface;

namespace Mappers
{
    public class MapperProfessor : IMapperProfessor
    {
        private string cs;

        public MapperProfessor()
        {
            cs = ConfigurationManager.ConnectionStrings["SI2 Database"].ConnectionString;
        }


        public void Create(Professor a)
        {
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Professor (cc,nome,areaEspecializacao,categoria,siglaDepartamento,siglaSeccao) VALUES(@cc,@nome,@areaEspecializacao,@categoria,@siglaDepartamento,@siglaSeccao)";
                SqlParameter p1 = new SqlParameter("@cc", a.Cc);
                SqlParameter p2 = new SqlParameter("@nome", a.Nome);
                SqlParameter p3 = new SqlParameter("@areaEspecializacao", a.AreaEspecializacao);
                SqlParameter p4 = new SqlParameter("@categoria", a.Categoria);
                SqlParameter p5 = new SqlParameter("@siglaDepartamento", a.SiglaDepartamento);
                SqlParameter p6 = new SqlParameter("@siglaSeccao", a.SiglaSeccao);

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);

                using (var cn = new SqlConnection(cs))
                {
                    cmd.Connection = cn;
                    cn.Open();
                    cmd.ExecuteNonQuery();
                }
                ts.Complete();
            }
        }


        public void Delete(Professor entity)
        {
            throw new NotImplementedException();
        }

        public Professor Read(int cc)
        {
            Professor prof = new Professor();
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT @nome = nome, @areaEspecializacao = areaEspecializacao, @categoria = categoria, @siglaDepartamento = siglaDepartamento, @siglaSeccao = siglaSeccao FROM Professor where cc = @cc";
                SqlParameter p1 = new SqlParameter("@nome", System.Data.SqlDbType.VarChar, 255);
                p1.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p2 = new SqlParameter("@areaEspecializacao", System.Data.SqlDbType.VarChar, 255);
                p2.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p3 = new SqlParameter("@categoria", System.Data.SqlDbType.Float);
                p3.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p4 = new SqlParameter("@siglaDepartamento", System.Data.SqlDbType.VarChar, 6);
                p3.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p5 = new SqlParameter("@siglaSeccao", System.Data.SqlDbType.VarChar, 6);
                p3.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p6 = new SqlParameter("@cc", cc);
                cmd.Parameters.Add(p6);
                cmd.ExecuteNonQuery();
                if (p1.Value is System.DBNull)
                    throw new Exception("Não existe Professor com o cc " + cc);

                prof.Cc = cc;
                prof.Nome = (string)p1.Value;
                prof.AreaEspecializacao = (string)p2.Value;
                prof.Categoria = (string)p3.Value;
                prof.SiglaDepartamento = (string)p3.Value;
                prof.SiglaSeccao = (string)p3.Value;

                ts.Complete();
            }

            return prof;
        }

        public void Update(Professor entity)
        {
            throw new NotImplementedException();
        }
    }
}
