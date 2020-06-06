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
    public class MapperUC_Semestre : IMapperUC_Semestre
    {
        private string cs;

        public MapperUC_Semestre()
        {
            cs = ConfigurationManager.ConnectionStrings["TP1"].ConnectionString;
        }


        public void Create(UC_Semestre a)
        {
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO UC_Semestre (numSemestre,siglaCurso,siglaUC,ano) VALUES(@numSemestre,@siglaCurso,@siglaUC,@ano)";
                SqlParameter p1 = new SqlParameter("@numSemestre", a.numSemestre);
                SqlParameter p2 = new SqlParameter("@siglaCurso", a.siglaCurso);
                SqlParameter p3 = new SqlParameter("@siglaUC", a.siglaUC);
                SqlParameter p4 = new SqlParameter("@ano", a.ano);

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);

                using (var cn = new SqlConnection(cs))
                {

                    cmd.Connection = cn;
                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
                ts.Complete();
            }
        }


        public void Delete(UC_Semestre entity)
        {
            throw new NotImplementedException();
        }

        public UC_Semestre Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(UC_Semestre entity)
        {
            throw new NotImplementedException();
        }
    }
}
