using NUnit.Framework;

//Autor: Brenda Rodrigues
//Package: Testes Unitários

namespace LoginTest.Test
{

    [TestFixture]
    public class TestesUnitarios
    {

        //Teste Questão 1 - Realizar testes no endpoint usuários (/usuarios)
        Cadastrar cadastro = new Cadastrar();

        [Test]
        public void Teste01CadastrarUsuarioComSucesso()
        {
            Assert.AreEqual(201, cadastro.cadastrarUsuario("Luiz Cunha", "Luiz@gmail.com", "senhadoBento", "false"));
            Assert.AreEqual(400, cadastro.cadastrarUsuario("Luiz Cunha", "Luiz@gmail.com", "senhadoBento", "false"));
        }

        [Test]
        public void Teste02EditarUsuario()
        {
            Editar editar = new Editar();
            editar.editarUsuario("Luiz Cunha da Rosa", "Luizrosa@gmail.com", "senhadoBento", "false");
            Assert.AreEqual(200, editar.editarUsuarioPorId(cadastro.id));
        }

        [Test]
        public void Teste03ListarUsuario()
        {
            Listar listar = new Listar();
            Assert.AreEqual(200, listar.listarUsuarioPorID(cadastro.id));
        }

        [Test]
        public void Teste04ExcluirUsuario()
        {
            Excluir excluir = new Excluir();
            Assert.AreEqual(200, excluir.excluirUsuarioPorId(cadastro.id));
        }
    }
}