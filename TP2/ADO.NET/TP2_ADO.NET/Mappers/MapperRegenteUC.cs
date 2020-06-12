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
    public class MapperRegenteUC : IMapperRegenteUC
    {
        private string cs;

        public MapperRegenteUC()
        {
            cs = ConfigurationManager.ConnectionStrings["SI2 Database"].ConnectionString;
        }


        public void Create(RegenteUC a)
        {
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO RegenteUC (ccProfessor,siglaUC,ano) VALUES(@ccProfessor,@siglaUC,@ano)";
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


        public void Delete(RegenteUC entity)
        {
            throw new NotImplementedException();
        }

      
        public RegenteUC Read(KeyValuePair<string, int> id)
        {
            RegenteUC regente = new RegenteUC();
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT @ccProfessor = ccProfessor FROM RegenteUC where siglaUC = @siglaUC AND ano = @ano";
                SqlParameter p1 = new SqlParameter("@ccProfessor", System.Data.SqlDbType.Int);
                p1.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p2 = new SqlParameter("@siglaUC", id.Key);
                cmd.Parameters.Add(p2);
                SqlParameter p3 = new SqlParameter("@ano", id.Value);
                cmd.Parameters.Add(p3);
                cmd.ExecuteNonQuery();
                if (p1.Value is System.DBNull)
                    throw new Exception("Não existe RegenteUC com a combinacao siglaUC/ano: " + id.Key + "/" + id.Value);

                regente.ccProfessor = (int)p1.Value;
                regente.siglaUC = id.Key;
                regente.ano = id.Value;

                ts.Complete();
            }

            return regente;
        }

        public void Update(RegenteUC entity)
        {
            throw new NotImplementedException();
        }
    }
}
