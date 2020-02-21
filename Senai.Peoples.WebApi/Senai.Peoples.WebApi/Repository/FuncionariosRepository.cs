using Senai.Peoples.WebApi.Domain;
using Senai.Peoples.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Repository
{
    public class FuncionariosRepository : IFuncionariosRepository
    {
        private string stringConexao = "Data Source=DEV801\\SQLEXPRESS; initial catalog=T_Peoples; user Id=sa; pwd=sa@132";



        public void AtulizarIdUrl(int id, FuncionariosDomain funcionarios)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryAtualizarPorUrl = "UPDATE Funcionarios SET Nome = @nome, Sobrenome = @sobrenome where IdFuncionario = @ID";

                using (SqlCommand cmd = new SqlCommand(queryAtualizarPorUrl, con))
                {
                    cmd.Parameters.AddWithValue("@nome", funcionarios.Nome);
                    cmd.Parameters.AddWithValue("@sobrenome", funcionarios.Sobrenome);
                    cmd.Parameters.AddWithValue("@ID", id);

                    con.Open();

                    cmd.ExecuteNonQuery();
                }
            }
        }

        public FuncionariosDomain BuscarPorId(int id)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryBuscarPorId = "select IdFuncionario, Nome, Sobrenome from Funcionarios WHERE IdFuncionario = @ID";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryBuscarPorId, con))
                {
                    cmd.Parameters.AddWithValue("@ID", id);

                    rdr = cmd.ExecuteReader();

                    if(rdr.Read())
                    {
                        FuncionariosDomain funcionarios = new FuncionariosDomain
                        {
                            IdFuncionario = Convert.ToInt32(rdr["IdFuncionario"]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString()
                        };
                        return funcionarios;
                    }

                    return null;
                }
            }
        }

        public void Inserir(FuncionariosDomain funcionarios)
        {
            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryInserir = "INSERT INTO Funcionarios(Nome, Sobrenome) VALUES (@Nome,@Sobrenome)";

                SqlCommand cmd = new SqlCommand(queryInserir, con);
                
                cmd.Parameters.AddWithValue("@Nome", funcionarios.Nome);

                cmd.Parameters.AddWithValue("@Sobrenome", funcionarios.Sobrenome);

                con.Open();

                cmd.ExecuteNonQuery();
                
            }
        }

        public List<FuncionariosDomain> Listar()
        {
            List<FuncionariosDomain> funcionariosDomain = new List<FuncionariosDomain>();

            using (SqlConnection con = new SqlConnection(stringConexao))
            {
                string queryListar = "select IdFuncionario, Nome, Sobrenome from Funcionarios";

                con.Open();

                SqlDataReader rdr;

                using (SqlCommand cmd = new SqlCommand(queryListar, con))
                {
                    rdr = cmd.ExecuteReader();

                    while(rdr.Read())
                    {
                        FuncionariosDomain funcionarios = new FuncionariosDomain()
                        {

                            IdFuncionario = Convert.ToInt32(rdr[0]),
                            Nome = rdr["Nome"].ToString(),
                            Sobrenome = rdr["Sobrenome"].ToString()

                        };
                        funcionariosDomain.Add(funcionarios);
                    }
                }
            }
                    return funcionariosDomain;
        }

        
    }
}
