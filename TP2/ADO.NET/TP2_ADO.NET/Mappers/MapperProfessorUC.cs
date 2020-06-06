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
    public class MapperProfessorUC : IMapperProfessorUC
    {
        private string cs;

        public MapperProfessorUC()
        {
            cs = ConfigurationManager.ConnectionStrings["TP1"].ConnectionString;
        }


        public void Create(ProfessorUC a)
        {
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO ProfessorUC (ccProfessor,siglaUC,ano) VALUES(@ccProfessor,@siglaUC,@ano)";
                SqlParameter p1 = new SqlParameter("@ccProfessor", a.ccProfessor);
                SqlParameter p2 = new SqlParameter("@siglaUC", a.siglaUC);
                SqlParameter p3 = new SqlParameter("@ano", a.ano);
               
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


        public void Delete(ProfessorUC entity)
        {
            throw new NotImplementedException();
        }

        public ProfessorUC Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ProfessorUC entity)
        {
            throw new NotImplementedException();
        }
    }
}
