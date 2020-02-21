using Senai.Peoples.WebApi.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Peoples.WebApi.Interfaces
{
    interface IFuncionariosRepository
    {
        /// <summary>
        /// Vai listar todos os dados da tabela
        /// </summary>
        /// <returns>O nome E sobrenome de cada funcionario</returns>
        List<FuncionariosDomain> Listar();

        /// <summary>
        /// Cadastra um funcionario novo
        /// </summary>
        /// <param name="funcionariosDomain"></param>
        void Inserir(FuncionariosDomain funcionariosDomain);

        /// <summary>
        /// Busca um funcionario pelo Id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>O nome e sobrenome do funcionario</returns>
        FuncionariosDomain BuscarPorId(int id);


        /// <summary>
        /// Altera o nome de um funcionario
        /// </summary>
        /// <param name="id"></param>
        /// <param name="funcionarios"></param>
        void AtulizarIdUrl(int id, FuncionariosDomain funcionarios);


        /// <summary>
        /// Deleta um funcionario pelo ID
        /// </summary>
        /// <param name="id"></param>
        void Deletar(int id);

            


    }
}
