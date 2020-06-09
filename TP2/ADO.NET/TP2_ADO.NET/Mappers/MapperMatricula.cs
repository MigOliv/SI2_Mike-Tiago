﻿using System;
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
            cs = ConfigurationManager.ConnectionStrings["SI2 Database"].ConnectionString;
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

        public Matricula Read(int numAluno, int ano)
        {
            Matricula matricula = new Matricula();
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT @siglaCurso = siglaCurso FROM Matricula where numAluno = @numAluno AND ano = @ano";
                SqlParameter p1 = new SqlParameter("@siglaCurso", System.Data.SqlDbType.VarChar, 6);
                p1.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p2 = new SqlParameter("@numAluno", numAluno);
                cmd.Parameters.Add(p2);
                SqlParameter p3 = new SqlParameter("@ano", ano);
                cmd.Parameters.Add(p3);
                cmd.ExecuteNonQuery();
                if (p1.Value is System.DBNull)
                    throw new Exception("Não existe Matricula com a combinacao numAluno/ano: " + numAluno + "/" + ano);

                matricula.siglaCurso = (string)p1.Value;
                matricula.numAluno = numAluno;
                matricula.ano = ano;

                ts.Complete();
            }

            return matricula;
        }

        public void Update(Matricula entity)
        {
            throw new NotImplementedException();
        }
    }
}
