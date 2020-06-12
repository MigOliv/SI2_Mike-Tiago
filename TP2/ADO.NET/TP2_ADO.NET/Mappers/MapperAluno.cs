using Entidades;
using Mappers_Interface;

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
            cs = ConfigurationManager.ConnectionStrings["SI2 Database"].ConnectionString;
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


        public void Delete(Aluno a)
        {
            throw new NotImplementedException();
        }

        public Aluno Read(int id)
        {
            Aluno a = new Aluno();
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT @cc = cc, @nome = nome, @rua = rua, @n = n, @andar = andar, @codPostal = codPostal, @dataNascimento = dataNascimento" +
                    " FROM Aluno where id = @num";
                SqlParameter p1 = new SqlParameter("@cc", System.Data.SqlDbType.Int);
                p1.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p2 = new SqlParameter("@nome", System.Data.SqlDbType.VarChar, 255);
                p2.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p3 = new SqlParameter("@rua", System.Data.SqlDbType.VarChar, 255);
                p3.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p4 = new SqlParameter("@n", System.Data.SqlDbType.VarChar, 10);
                p4.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p5 = new SqlParameter("@andar", System.Data.SqlDbType.VarChar, 10);
                p5.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p6 = new SqlParameter("@codPostal", System.Data.SqlDbType.Char, 8);
                p6.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p7 = new SqlParameter("@dataNascimento", System.Data.SqlDbType.Date);
                p7.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p8 = new SqlParameter("@num", id);
                cmd.Parameters.Add(p8);
                cmd.ExecuteNonQuery();
                if (p1.Value is System.DBNull)
                    throw new Exception("Não existe Aluno com o numero " + id);

                a.Num = id;
                a.Cc = (int)p1.Value;
                a.Nome = (string)p2.Value;
                a.Rua = (string)p3.Value;
                a.NumeroRua = (string)p4.Value;
                a.Andar = (string)p5.Value;
                a.CodigoPostal = (string)p6.Value;
                a.DataNascimento = (DateTime)p7.Value;

                ts.Complete();
            }
            return a;
        }

        public void Update(Aluno a)
        {
            throw new NotImplementedException();
        }
    }
}
