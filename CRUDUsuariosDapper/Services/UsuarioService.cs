using CRUDUsuariosDapper.Dto;
using CRUDUsuariosDapper.Models;
using Dapper;
using System.Data.SqlClient;

namespace CRUDUsuariosDapper.Services
{
    public class UsuarioService : IUsuarioInterface
    {
        private readonly IConfiguration _configuration;
        public UsuarioService(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<ResponseModel<List<UsuarioListarDto>>> BuscarUsuarios()
        {
            ResponseModel<List<UsuarioListarDto>> response = new ResponseModel<List<UsuarioListarDto>>(); 

            using (var connection = new SqlConnection(_configuration.GetConnectionString("DefaultConnection")))
            {
                var usuariosBanco = await connection.QueryAsync<Usuario>("select * from Usuarios");
                if (usuariosBanco.Count() == 0)
                {
                    response.Mensagem = "Nenhum usuário localizado!";
                    response.Status = false;
                    return response;
                }
                //response.Dados = usuariosBanco;
                //response.Mensagem = "Usuários localizados com sucesso!";
            }
            return response;
        }
    }
}
