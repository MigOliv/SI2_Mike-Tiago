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
    public class MapperConclusaoCurso : IMapperConclusaoCurso
    {
        private string cs;

        public MapperConclusaoCurso()
        {
            cs = ConfigurationManager.ConnectionStrings["SI2 Database"].ConnectionString;
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


        public ConclusaoCurso Read(KeyValuePair<int, string> id)
        {
            ConclusaoCurso conclusao = new ConclusaoCurso();
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT @notaFinal = notaFinal, @ano = ano FROM ConclusaoCurso where numAluno = @numAluno AND siglaCurso = @siglaCurso";
                SqlParameter p1 = new SqlParameter("@notaFinal", System.Data.SqlDbType.Float);
                p1.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p2 = new SqlParameter("@ano", System.Data.SqlDbType.Int);
                p2.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p3 = new SqlParameter("@numAluno", id.Key);
                cmd.Parameters.Add(p3);
                SqlParameter p4 = new SqlParameter("@siglaCurso", id.Value);
                cmd.Parameters.Add(p4);
                cmd.ExecuteNonQuery();
                if (p1.Value is System.DBNull)
                    throw new Exception("Não existe ConclusaoCurso com a combinacao numAluno/siglaCurso: " + id.Key + "/" + id.Value);

                conclusao.notaFinal = (float)p1.Value;
                conclusao.ano = (int)p2.Value;
                conclusao.numAluno = id.Key;
                conclusao.siglaCurso = id.Value;

                ts.Complete();
            }

            return conclusao;
        }

        public void Update(ConclusaoCurso entity)
        {
            throw new NotImplementedException();
        }
    }
}
