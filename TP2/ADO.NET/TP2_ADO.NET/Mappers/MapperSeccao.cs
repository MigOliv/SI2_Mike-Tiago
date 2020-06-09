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
    public class MapperSeccao : IMapperSeccao
    {
        private string cs;

        public MapperSeccao()
        {
            cs = ConfigurationManager.ConnectionStrings["SI2 Database"].ConnectionString;
        }


        public void Create(Seccao a)
        {
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Seccao (sigla,siglaDepartamento,descricao) VALUES(@sigla,@siglaDepartamento,@descricao)";
                SqlParameter p1 = new SqlParameter("@sigla", a.Sigla);
                SqlParameter p2 = new SqlParameter("@siglaDepartamento", a.SiglaDepartamento);
                SqlParameter p3 = new SqlParameter("@descricao", a.Descricao);

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


        public void Delete(Seccao entity)
        {
            throw new NotImplementedException();
        }

        public Seccao Read(String sigla)
        {
            Seccao seccao = new Seccao();
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT @siglaDepartamento = siglaDepartamento, @descricao = descricao FROM Seccao WHERE sigla = @sigla";
                SqlParameter p1 = new SqlParameter("@siglaDepartamento", System.Data.SqlDbType.Char);
                p1.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p2 = new SqlParameter("@descr", System.Data.SqlDbType.VarChar, 255);
                p2.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p3 = new SqlParameter("@sigla", sigla);
                cmd.Parameters.Add(p3);
              
                cmd.ExecuteNonQuery();
                if (p1.Value is System.DBNull)
                    throw new Exception("Não existe Seccao com a combinação siglaDepartamento/sigla " + siglaDepartamento +" "+sigla);

                seccao.Sigla = sigla;
                seccao.SiglaDepartamento = (string)p1.Value;
                seccao.Descricao = (string)p2.Value;

                ts.Complete();
            }

            return seccao;
        }

        public void Update(Seccao entity)
        {
            throw new NotImplementedException();
        }
    }
}
