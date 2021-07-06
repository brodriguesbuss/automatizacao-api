//Autor: Brenda Rodrigues
//Classe: Program/Main

namespace Automatizacao_API
{
    class Program
    {
        static void Main(string[] args)
        {
            Login login = new Login();
            login.logarComSucesso("fulano@qa.com", "teste");
            Cadastrar usuario = new Cadastrar();
            usuario.cadastrarUsuario("Alexandre Silva", "alexandresilva@gmail.com", "senha", "false");
            Listar lista = new Listar();
            lista.listarUsuarioPorID(usuario.id);
            Editar editar = new Editar();
            editar.editarUsuario("Alexandre da Silva", "alexandredasilva@gmail.com", "senha", "false");
            editar.editarUsuarioPorId(usuario.id);
            Excluir excluir = new Excluir();
            excluir.excluirUsuarioPorId(usuario.id);

        }
    }
}
