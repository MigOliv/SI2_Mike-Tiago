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
    public class MapperMatricula : IMapperMatricula
    {
        private string cs;

        public MapperMatricula()
        {
            cs = ConfigurationManager.ConnectionStrings["TP1"].ConnectionString;
        }


        public void Create(Matricula a)
        {
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Matricula (numAluno,siglaCurso,ano) VALUES(@numAluno,@siglaCurso,@ano)";
                SqlParameter p1 = new SqlParameter("@numAluno", a.numAluno);
                SqlParameter p2 = new SqlParameter("@siglaCurso", a.siglaCurso);
                SqlParameter p3 = new SqlParameter("@ano", a.ano);


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


        public void Delete(Matricula entity)
        {
            throw new NotImplementedException();
        }

        public Matricula Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Matricula entity)
        {
            throw new NotImplementedException();
        }
    }
}
