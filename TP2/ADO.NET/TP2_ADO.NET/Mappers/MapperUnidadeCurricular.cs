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
    public class MapperUnidadeCurricular : IMapperUnidadeCurricular
    {
        private string cs;

        public MapperUnidadeCurricular()
        {
            cs = ConfigurationManager.ConnectionStrings["SI2 Database"].ConnectionString;
        }


        public void Create(UnidadeCurricular uc)
        {
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO UnidadeCurricular (sigla,descricao,numCreditos) VALUES(@sigla,@descricao,@numCreditos)";
                SqlParameter p1 = new SqlParameter("@sigla", uc.Sigla);
                SqlParameter p2 = new SqlParameter("@descricao", uc.Descricao);
                SqlParameter p3 = new SqlParameter("@numCreditos", uc.NumCreditos);
              
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


        public void Delete(UnidadeCurricular uc)
        {          
            throw new NotImplementedException();
        }

        public UnidadeCurricular Read(string sigla)
        {
            UnidadeCurricular uc = new UnidadeCurricular();
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT @descr = descr, @numCreditos = numCreditos FROM UnidadeCurricular where sigla = @sigla";
                SqlParameter p1 = new SqlParameter("@descr", System.Data.SqlDbType.VarChar, 255);
                p1.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p2 = new SqlParameter("@numCreditos", System.Data.SqlDbType.Float);
                p2.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p3 = new SqlParameter("@sigla", sigla);
                cmd.Parameters.Add(p3);
                cmd.ExecuteNonQuery();
                if (p1.Value is System.DBNull)
                    throw new Exception("Não existe Unidade Curricular com a sigla " + sigla);
                
                uc.Sigla = sigla;
                uc.Descricao = (string)p2.Value;
                uc.NumCreditos = (float)p3.Value;

                ts.Complete();
            }

            return uc;
        }

        public void Update(UnidadeCurricular uc)
        {
            throw new NotImplementedException();
        }
    }
}
