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
    public class MapperCoordenadorSeccao : IMapperCoordenadorSeccao
    {
        private string cs;

        public MapperCoordenadorSeccao()
        {
            cs = ConfigurationManager.ConnectionStrings["SI2 Database"].ConnectionString;
        }


        public void Create(CoordenadorSeccao a)
        {
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO CoordenadorSeccao (siglaSeccao,ccProfessor,siglaDepartamento) VALUES(@siglaSeccao,@ccProfessor,@siglaDepartamento)";
                SqlParameter p1 = new SqlParameter("@siglaSeccao", a.SiglaSeccao);
                SqlParameter p2 = new SqlParameter("@ccProfessor", a.CcProfessor);
                SqlParameter p3 = new SqlParameter("@siglaDepartamento", a.SiglaDepartamento);
               

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


        public void Delete(CoordenadorSeccao entity)
        {
            throw new NotImplementedException();
        }

        public CoordenadorSeccao Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(CoordenadorSeccao entity)
        {
            throw new NotImplementedException();
        }
    }
}
