using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Entidades;
using Mappers_Interface;

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

                SqlCommand cmd = new SqlCommand("insert_Departamento");
                cmd.CommandType = CommandType.StoredProcedure;
                
                SqlParameter p1 = new SqlParameter("@new_sigla", a.Sigla);
                p1.Direction = ParameterDirection.Input;
                SqlParameter p2 = new SqlParameter("@new_descricao", a.Descricao);
                p2.Direction = ParameterDirection.Input;
             

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


        public void Delete(Departamento a)
        {
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {

             
                SqlCommand cmd = new SqlCommand("remove_Departamento");
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@sigla", a.Sigla);
                p1.Direction = ParameterDirection.Input;

                cmd.Parameters.Add(p1);

                using (var cn = new SqlConnection(cs))
                {
                    cmd.Connection = cn;
                    cn.Open();

                    cmd.ExecuteNonQuery();
                }

                ts.Complete();
            }
            

            /*
            Departamento dep = new Departamento();
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "DELETE FROM Departamento where sigla = @sigla";
                SqlParameter p1 = new SqlParameter("@sigla", a.Sigla);
                cmd.Parameters.Add(p1);

                using (var cn = new SqlConnection(cs))
                {

                    cmd.Connection = cn;
                    cn.Open();

                    cmd.ExecuteNonQuery();

                }
                

               //FALTA EXCECAO


                ts.Complete();
            }
            */

        }

        public Departamento Read(String sigla)
        {
            Departamento dep = new Departamento();
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT @descricao = descricao FROM Departamento where sigla = @sigla";
                SqlParameter p1 = cmd.Parameters.Add("@descricao", SqlDbType.VarChar, 255);
                p1.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p2 = new SqlParameter("@sigla", sigla);
                cmd.Parameters.Add(p2);

                using (var cn = new SqlConnection(cs))
                {

                    cmd.Connection = cn;
                    cn.Open();

                    cmd.ExecuteNonQuery();

                }

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
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {


                SqlCommand cmd = new SqlCommand("update_Departamento");
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter p1 = new SqlParameter("@sigla", entity.Sigla);
                p1.Direction = ParameterDirection.Input;
                SqlParameter p2 = new SqlParameter("@new_descricao", entity.Descricao);
                p1.Direction = ParameterDirection.Input;

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
    }
}
