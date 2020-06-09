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

        public Semestre Read(KeyValuePair<int, string> vals)
        {
            Semestre semestre = new Semestre();
            int numSemestre = vals.Key;
            string siglaCurso = vals.Value;
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT * FROM Semestre WHERE numSemestre = @numSemestre AND @siglaCurso = siglaCurso";
                SqlParameter p1 = new SqlParameter("@semestre", numSemestre);
                cmd.Parameters.Add(p1);
                SqlParameter p2 = new SqlParameter("@siglaCurso", siglaCurso);
                cmd.Parameters.Add(p2);
                cmd.ExecuteNonQuery();

                if (p1.Value is System.DBNull)
                    throw new Exception("Não existe Semestre com a combinação semestre/siglaCurso " + numSemestre + " " + siglaCurso);

                semestre.NumSemestre = numSemestre;
                semestre.SiglaCurso = siglaCurso;

                ts.Complete();
            }

            return semestre;
        }

        public void Update(Semestre entity)
        {
            throw new NotImplementedException();
        }
    }
}
