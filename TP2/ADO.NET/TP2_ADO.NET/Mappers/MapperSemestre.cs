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
    public class MapperSemestre : IMapperSemestre
    {
        private string cs;

        public MapperSemestre()
        {
            cs = ConfigurationManager.ConnectionStrings["SI2 Database"].ConnectionString;
        }


        public void Create(Semestre a)
        {
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Semestre (numSemestre,siglaCurso) VALUES(@numSemestre,@siglaCurso)";
                SqlParameter p1 = new SqlParameter("@numSemestre", a.NumSemestre);
                SqlParameter p2 = new SqlParameter("@siglaCurso", a.SiglaCurso);
              
                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
              
                using (var cn = new SqlConnection(cs))
                {

                    cmd.Connection = cn;
                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
                ts.Complete();
            }
        }


        public void Delete(Semestre entity)
        {
            throw new NotImplementedException();
        }

        public Semestre Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Semestre entity)
        {
            throw new NotImplementedException();
        }
    }
}
