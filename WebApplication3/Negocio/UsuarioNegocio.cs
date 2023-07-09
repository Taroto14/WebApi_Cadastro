using PrimeiraApi.Models;
using PrimeiraApi.Negocio.Util;
using PrimeiraApi.Repositorios.Interfaces;
using System.Linq;
using System.Runtime.InteropServices;

namespace PrimeiraApi.Negocio
{
    public class UsuarioNegocio
    {
        IUsuarioRepositorio usuarioRepositorio;

        public UsuarioNegocio(IUsuarioRepositorio UsuarioRepositorio)
        {
            usuarioRepositorio = UsuarioRepositorio;
        }
        public void Incluir(UsuarioModel usuario)
        {
            if (!CPF.ValidaCPF(usuario.Cpf))
                throw new ArgumentException("CPF não é valido!");

            var usuarioDuplicado = usuarioRepositorio.BuscarUsuarioPorCpf(usuario.Cpf).Result.ToList();
            
            if(usuarioDuplicado.Any())
                throw new ArgumentException("Já existe usuário cadastrado com esse CPF!");

            if (string.IsNullOrWhiteSpace(usuario.Nome))
                throw new ArgumentException("Nome precisa ser preenchido!");

            usuarioRepositorio.Adicionar(usuario);
        }

        public List<UsuarioModel> BuscarTodosUsuarios()
        {
            return usuarioRepositorio.BuscarTodosUsuarios().Result.ToList();
        }

        public List<UsuarioModel> BuscarUsuarioPorCpf(string cpf)
        {
            return usuarioRepositorio.BuscarUsuarioPorCpf(cpf).Result.ToList();
        }

        public void Atualizar(UsuarioModel usuario, int Id)
        {
            var usuarioDuplicado = usuarioRepositorio.BuscarUsuarioPorCpf(usuario.Cpf).Result.ToList().Where(usuario => usuario.Id != Id);

            if (usuarioDuplicado.Any())
                throw new ArgumentException("Já existe usuário cadastrado com esse CPF!");

            usuarioRepositorio.Atualizar(usuario, Id);
            
        }
    }
}
