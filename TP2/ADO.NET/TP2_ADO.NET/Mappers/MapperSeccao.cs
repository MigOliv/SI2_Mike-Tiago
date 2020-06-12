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


        public Seccao Read(KeyValuePair<string, string> id)
        {
            Seccao seccao = new Seccao();
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT @descricao = descricao FROM Seccao WHERE siglaDepartamento = @siglaDepartamento AND sigla = @sigla";
                SqlParameter p1 = new SqlParameter("@descr", System.Data.SqlDbType.VarChar, 255);
                p1.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p3 = new SqlParameter("@siglaDepartamento", id.Key);
                cmd.Parameters.Add(p3);
                SqlParameter p4 = new SqlParameter("@sigla", id.Value);
                cmd.Parameters.Add(p4);

                cmd.ExecuteNonQuery();
                if (p1.Value is System.DBNull)
                    throw new Exception("Não existe Seccao com a combinação siglaDepartamento/sigla " + id.Key + " " + id.Key);

                seccao.Sigla = id.Key;
                seccao.SiglaDepartamento = id.Value;
                seccao.Descricao = (string)p1.Value;

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
