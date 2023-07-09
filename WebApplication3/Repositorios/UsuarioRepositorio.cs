using Microsoft.EntityFrameworkCore;
using PrimeiraApi.Data;
using PrimeiraApi.Models;
using PrimeiraApi.Negocio.Util;
using PrimeiraApi.Repositorios.Interfaces;

namespace PrimeiraApi.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaTarefasDBContext _dbContext;
        public UsuarioRepositorio(SistemaTarefasDBContext sistemaTarefasDBContext)
        {
            _dbContext = sistemaTarefasDBContext;
        }
        public UsuarioModel BuscarPorId(int id)
        {
            return _dbContext.Usuarios.FirstOrDefault(x => x.Id == id);
        }

        public async Task<List<UsuarioModel>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }

        public async Task<List<UsuarioModel>> BuscarUsuarioPorCpf(string cpf)
        {
            return await _dbContext.Usuarios.Where(usuario => usuario.Cpf == cpf).ToListAsync();
        }
        public UsuarioModel Adicionar(UsuarioModel usuario)
        {
            _dbContext.Usuarios.Add(usuario);
            _dbContext.SaveChanges();

            return usuario;
        }

        public async Task<bool> Apagar(int id, UsuarioModel usuarioPorId)
        {
            UsuarioModel UsuarioPorId = BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o Id: {id} não foi encontrado no banco de dados.");
            }

            _dbContext.Usuarios.Remove(usuarioPorId);
            await _dbContext.SaveChangesAsync();
            return true;
        }

        public void Atualizar(UsuarioModel usuario, int id)
        {
            UsuarioModel usuarioPorId = BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o Id: {id} não foi encontrado no banco de dados.");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Endereco = usuario.Endereco;
            usuarioPorId.Cpf = usuario.Cpf;
            usuarioPorId.Telefone = usuario.Telefone;

            _dbContext.Usuarios.Update(usuarioPorId);
            _dbContext.SaveChangesAsync();

        }

    }
}
