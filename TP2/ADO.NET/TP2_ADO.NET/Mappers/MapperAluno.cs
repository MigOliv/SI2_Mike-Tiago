using Entidades;
using IMappers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Configuration;
using System.Transactions;
using System.Data.SqlClient;

namespace Mappers
{
    public class MapperAluno : IMapperAluno
    {
        private string cs;

        public MapperAluno()
        {
            cs = ConfigurationManager.ConnectionStrings["TP1"].ConnectionString;
        }


        public void Create(Aluno a)
        {
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO ALUNOS (num,cc,nome,rua,n,andar,codPostal,dataNascimento) VALUES(@num,@cc,@nome,@rua,@n,@andar,@codPostal,@dataNascimento)";
                SqlParameter p1 = new SqlParameter("@num", a.Num);                           SqlParameter p2 = new SqlParameter("@cc", a.Cc);
                SqlParameter p3 = new SqlParameter("@nome", a.Nome);                         SqlParameter p4 = new SqlParameter("@rua", a.Rua);
                SqlParameter p5 = new SqlParameter("@n", a.NumeroRua);                       SqlParameter p6 = new SqlParameter("@andar", a.Andar);
                SqlParameter p7 = new SqlParameter("@codPostal", a.CodigoPostal);   
                SqlParameter p8 = new SqlParameter("@dataNascimento", a.DataNascimento);
             
                cmd.Parameters.Add(p1);     cmd.Parameters.Add(p2);     cmd.Parameters.Add(p3);     cmd.Parameters.Add(p4);
                cmd.Parameters.Add(p5);     cmd.Parameters.Add(p6);     cmd.Parameters.Add(p7);     cmd.Parameters.Add(p8);

                using (var cn = new SqlConnection(cs))
                {

                    cmd.Connection = cn;
                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
                ts.Complete();
            }
        }


        public void Delete(Aluno entity)
        {
            throw new NotImplementedException();
        }

        public Aluno Read(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(Aluno entity)
        {
            throw new NotImplementedException();
        }
    }
}
