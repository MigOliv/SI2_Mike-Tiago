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
    public class MapperDepartamento : IMapperDepartamento
    {
        private string cs;

        public MapperDepartamento()
        {
            cs = ConfigurationManager.ConnectionStrings["SI2 Database"].ConnectionString;
        }


        public void Create(Departamento a)
        {
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO Departamento (sigla,descricao) VALUES(@sigla,@descricao)";
                SqlParameter p1 = new SqlParameter("@sigla", a.Sigla);
                SqlParameter p2 = new SqlParameter("@descricao", a.Descricao);
             

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


        public void Delete(Departamento entity)
        {
            throw new NotImplementedException();
        }

        public Departamento Read(String sigla)
        {
            Departamento dep = new Departamento();
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT @descricao = descricao FROM Departament where sigla = @sigla";
                SqlParameter p1 = new SqlParameter("@descr", System.Data.SqlDbType.VarChar, 255);
                p1.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p2 = new SqlParameter("@sigla", sigla);
                cmd.Parameters.Add(p2);
                cmd.ExecuteNonQuery();
                if (p1.Value is System.DBNull)
                    throw new Exception("Não existe Departamento com a sigla " + sigla);

                dep.Sigla = sigla;
                dep.Descricao = (string)p1.Value;
              
                ts.Complete();
            }

            return dep;
        }

        public void Update(Departamento entity)
        {
            throw new NotImplementedException();
        }
    }
}
