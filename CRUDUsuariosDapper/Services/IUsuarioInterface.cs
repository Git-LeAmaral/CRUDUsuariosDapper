using CRUDUsuariosDapper.Dto;
using CRUDUsuariosDapper.Models;

namespace CRUDUsuariosDapper.Services
{
    public interface IUsuarioInterface
    {
        Task<ResponseModel<List<UsuarioListarDto>>> BuscarUsuarios();
    }
}
