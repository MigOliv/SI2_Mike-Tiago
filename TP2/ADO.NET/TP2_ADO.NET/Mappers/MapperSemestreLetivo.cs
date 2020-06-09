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

        public SemestreLetivo Read(String sigla, int ano)
        {
            SemestreLetivo semLetivo = new SemestreLetivo();
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT @descricao = descricao FROM SemestreLetivo where sigla = @sigla AND ano = @ano";
                SqlParameter p1 = new SqlParameter("@descricao", System.Data.SqlDbType.VarChar, 6);
                p1.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p2 = new SqlParameter("@sigla", sigla);
                cmd.Parameters.Add(p2);
                SqlParameter p3 = new SqlParameter("@ano", ano);
                cmd.Parameters.Add(p3);
                cmd.ExecuteNonQuery();
                if (p1.Value is System.DBNull)
                    throw new Exception("Não existe SemestreLetivo com a combinacao sigla/ano: " + sigla + "/" + ano);

                semLetivo.descricao = (string)p1.Value;
                semLetivo.sigla = sigla;
                semLetivo.ano = ano;

                ts.Complete();
            }

            return semLetivo;
        }

        public void Update(SemestreLetivo entity)
        {
            throw new NotImplementedException();
        }
    }
}
