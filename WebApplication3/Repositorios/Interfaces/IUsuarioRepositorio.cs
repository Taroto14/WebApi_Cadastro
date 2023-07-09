using PrimeiraApi.Models;

namespace PrimeiraApi.Repositorios.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModel>> BuscarTodosUsuarios();
        UsuarioModel BuscarPorId(int id);
        Task<List<UsuarioModel>> BuscarUsuarioPorCpf(string cpf);
        UsuarioModel Adicionar(UsuarioModel usuario);
        void Atualizar(UsuarioModel usuario, int id);
    }
}
