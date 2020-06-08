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
    public class MapperSemestreLetivo : IMapperSemestreLetivo
    {
        private string cs;

        public MapperSemestreLetivo()
        {
            cs = ConfigurationManager.ConnectionStrings["SI2 Database"].ConnectionString;
        }


        public void Create(SemestreLetivo a)
        {
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO SemestreLetivo (sigla,ano,descricao) VALUES(@sigla,@ano,@descricao)";
                SqlParameter p1 = new SqlParameter("@sigla", a.sigla);
                SqlParameter p2 = new SqlParameter("@ano", a.ano);
                SqlParameter p3 = new SqlParameter("@descricao", a.descricao);

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


        public void Delete(SemestreLetivo entity)
        {
            throw new NotImplementedException();
        }

        public SemestreLetivo Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(SemestreLetivo entity)
        {
            throw new NotImplementedException();
        }
    }
}
