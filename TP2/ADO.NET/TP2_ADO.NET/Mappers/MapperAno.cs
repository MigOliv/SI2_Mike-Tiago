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
    public class MapperAno : IMapperAno
    {
        private string cs;

        public MapperAno()
        {
            cs = ConfigurationManager.ConnectionStrings["TP1"].ConnectionString;
        }

        public void Create(Ano a)
        {
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO ANO (ANO) VALUES(@ano)";
                SqlParameter p1 = new SqlParameter("@ano", a.AnoLetivo);
    
                cmd.Parameters.Add(p1); 

                using (var cn = new SqlConnection(cs))
                {

                    cmd.Connection = cn;
                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
                ts.Complete();
            }
        }


        public void Delete(Ano entity)
        {
            throw new NotImplementedException();
        }

        public Ano Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Ano entity)
        {
            throw new NotImplementedException();
        }
    }
}
