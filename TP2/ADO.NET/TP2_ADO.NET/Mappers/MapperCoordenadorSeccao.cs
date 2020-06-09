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
    public class MapperCoordenadorSeccao : IMapperCoordenadorSeccao
    {
        private string cs;

        public MapperCoordenadorSeccao()
        {
            cs = ConfigurationManager.ConnectionStrings["SI2 Database"].ConnectionString;
        }


        public void Create(CoordenadorSeccao a)
        {
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {

                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "INSERT INTO CoordenadorSeccao (siglaSeccao,ccProfessor,siglaDepartamento) VALUES(@siglaSeccao,@ccProfessor,@siglaDepartamento)";
                SqlParameter p1 = new SqlParameter("@siglaSeccao", a.SiglaSeccao);
                SqlParameter p2 = new SqlParameter("@ccProfessor", a.CcProfessor);
                SqlParameter p3 = new SqlParameter("@siglaDepartamento", a.SiglaDepartamento);
               

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


        public void Delete(CoordenadorSeccao entity)
        {
            throw new NotImplementedException();
        }

        public CoordenadorSeccao Read(String siglaSeccao, int ccProf)
        {
            CoordenadorSeccao coordenadorSeccao = new CoordenadorSeccao();
            using (var ts = new TransactionScope(TransactionScopeOption.Required))
            {
                SqlCommand cmd = new SqlCommand();
                cmd.CommandText = "SELECT @siglaDepartamento = siglaDepartamento FROM CoordenadorSeccao where siglaSeccao = @siglaSeccao AND ccProf = @ccProf";
                SqlParameter p1 = new SqlParameter("@siglaDepartamento", System.Data.SqlDbType.VarChar, 6);
                p1.Direction = System.Data.ParameterDirection.Output;
                SqlParameter p2 = new SqlParameter("@siglaSeccao", siglaSeccao);
                cmd.Parameters.Add(p2);
                SqlParameter p3 = new SqlParameter("@ccProf", ccProf);
                cmd.Parameters.Add(p3);
                cmd.ExecuteNonQuery();
                if (p1.Value is System.DBNull)
                    throw new Exception("Não existe Coordenador de Seccao com a combinacao siglaSeccao/ccProf: " + siglaSeccao + "/" + ccProf);

                coordenadorSeccao.SiglaDepartamento = (string)p1.Value;
                coordenadorSeccao.SiglaSeccao = siglaSeccao;
                coordenadorSeccao.CcProfessor = ccProf;

                ts.Complete();
            }

            return coordenadorSeccao;
        }

        public void Update(CoordenadorSeccao entity)
        {
            throw new NotImplementedException();
        }
    }
}
