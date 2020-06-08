using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Entidades;
using IMappers;

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

        public Professor Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Professor entity)
        {
            throw new NotImplementedException();
        }
    }
}
