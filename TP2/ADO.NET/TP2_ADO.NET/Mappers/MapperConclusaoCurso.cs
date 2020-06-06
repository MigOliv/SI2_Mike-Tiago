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
    public class MapperConclusaoCurso : IMapperConclusaoCurso
    {
        private string cs;

        public MapperConclusaoCurso()
        {
            cs = ConfigurationManager.ConnectionStrings["TP1"].ConnectionString;
        }


        public void Create(ConclusaoCurso a)
        {
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO ConclusaoCurso (numAluno,siglaCurso,notaFinal,ano) VALUES(@numAluno,@siglaCurso,@notaFinal,@ano)";
                SqlParameter p1 = new SqlParameter("@numAluno", a.numAluno); 
                SqlParameter p2 = new SqlParameter("@siglaCurso", a.siglaCurso);
                SqlParameter p3 = new SqlParameter("@notaFinal", a.notaFinal);
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


        public void Delete(ConclusaoCurso entity)
        {
            throw new NotImplementedException();
        }

        public ConclusaoCurso Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(ConclusaoCurso entity)
        {
            throw new NotImplementedException();
        }
    }
}
