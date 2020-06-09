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
            cs = ConfigurationManager.ConnectionStrings["SI2 Database"].ConnectionString;
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

        public Ano Read(int anoLetivo)
        {
            Ano ano = new Ano();
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Ano WHERE anoLetivo = @anoLetivo";
               
                SqlParameter p1 = new SqlParameter("@anoLetivo", anoLetivo);
                cmd.Parameters.Add(p1);
                cmd.ExecuteNonQuery();
              
                ano.AnoLetivo = anoLetivo;
               
                ts.Complete();
            }

            return ano;
        }

        public void Update(Ano entity)
        {
            throw new NotImplementedException();
        }
    }
}
