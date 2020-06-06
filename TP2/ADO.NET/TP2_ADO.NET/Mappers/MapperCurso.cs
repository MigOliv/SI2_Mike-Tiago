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
    public class MapperCurso : IMapperCurso
    {
        private string cs;

        public MapperCurso()
        {
            cs = ConfigurationManager.ConnectionStrings["TP1"].ConnectionString;
        }


        public void Create(Curso a)
        {
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Curso (sigla,descricao,siglaDepartamento,totalCreditos) VALUES(@sigla,@descricao,@siglaDepartamento,@totalCreditos)";
                SqlParameter p1 = new SqlParameter("@sigla", a.Sigla);
                SqlParameter p2 = new SqlParameter("@descricao", a.Descricao);
                SqlParameter p3 = new SqlParameter("@siglaDepartamento", a.SiglaDepartamento);
                SqlParameter p4 = new SqlParameter("@totalCreditos", a.TotalCreditos);


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


        public void Delete(Curso entity)
        {
            throw new NotImplementedException();
        }

        public Curso Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Curso entity)
        {
            throw new NotImplementedException();
        }
    }
}
