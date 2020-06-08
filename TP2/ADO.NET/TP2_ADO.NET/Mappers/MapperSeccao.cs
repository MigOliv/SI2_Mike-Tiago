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

        public Seccao Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Seccao entity)
        {
            throw new NotImplementedException();
        }
    }
}
