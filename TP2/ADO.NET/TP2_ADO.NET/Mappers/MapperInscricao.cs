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
    public class MapperInscricao : IMapperInscricao
    {
        private string cs;

        public MapperInscricao()
        {
            cs = ConfigurationManager.ConnectionStrings["TP1"].ConnectionString;
        }


        public void Create(Inscricao a)
        {
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Inscricao (numAluno,siglaCurso,siglaSemestreLetivo,ano,siglaUC,nota) VALUES(@numAluno,@siglaCurso,@siglaSemestreLetivo,@ano,@siglaUC,@nota)";
                SqlParameter p1 = new SqlParameter("@numAluno", a.numAluno);
                SqlParameter p2 = new SqlParameter("@siglaCurso", a.siglaCurso);
                SqlParameter p3 = new SqlParameter("@siglaSemestreLetivo", a.siglaSemestreLetivo);
                SqlParameter p4 = new SqlParameter("@ano", a.ano);
                SqlParameter p5 = new SqlParameter("@siglaUC", a.siglaUC);
                SqlParameter p6 = new SqlParameter("@nota", a.nota);

                cmd.Parameters.Add(p1);
                cmd.Parameters.Add(p2);
                cmd.Parameters.Add(p3);
                cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);
                cmd.Parameters.Add(p6);

                using (var cn = new SqlConnection(cs))
                {

                    cmd.Connection = cn;
                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
                ts.Complete();
            }
        }


        public void Delete(Inscricao entity)
        {
            throw new NotImplementedException();
        }

        public Inscricao Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Inscricao entity)
        {
            throw new NotImplementedException();
        }
    }
}
