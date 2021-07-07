using NUnit.Framework;

//Autor: Brenda Rodrigues
//Package: Testes Unitários

namespace Testes.Test
{

    [TestFixture]
    public class TestesEndPoints
    {
        //Instancias
        Cadastrar cadastroUsuario = new Cadastrar();
        Editar editar = new Editar();
        Listar listar = new Listar();
        Excluir excluir = new Excluir();
        Carrinho carrinho = new Carrinho();
        CadastrarProduto produto = new CadastrarProduto();

        //Variaveis Auxiliadoras
        string email1 = "Usuario01@gmail.com";
        string email2 = "Usuario02@gmail.com";
        string email3 = "Usuario03@gmail.com";
        string email4 = "Usuario04@gmail.com";
        string email5 = "Usuario05@gmail.com";
        string email6 = "Usuario06@gmail.com";
        string email7 = "Usuario07@gmail.com";
        string emailAlterar = "Usuario08@gmail.com";
        string emailExcluir = "Usuario09@gmail.com";
        string senha = "admin";
        string produto1 = "Item01";
        string produto2 = "Item02";
        string produto3 = "Item03";
        string produto4 = "Item04";
        
        
        //Testes da Questão 1 - Realizar testes no endpoint usuários (/usuarios)

        [Test]
        public void Teste01CadastrarUsuarioComSucesso()
        {
            Assert.AreEqual(201, cadastroUsuario.cadastrarUsuario(("Usuario a"), email1, senha, "true"));
            Assert.AreEqual(201, cadastroUsuario.cadastrarUsuario(("Usuario b"), email2, senha, "true"));
            Assert.AreEqual(201, cadastroUsuario.cadastrarUsuario(("Usuario c"), email3, senha, "true"));
            Assert.AreEqual(201, cadastroUsuario.cadastrarUsuario(("Usuario d"), email4, senha, "true"));
            Assert.AreEqual(201, cadastroUsuario.cadastrarUsuario(("Usuario e"), email5, senha, "true"));
            Assert.AreEqual(201, cadastroUsuario.cadastrarUsuario(("Usuario f"), email6, senha, "true"));
            Assert.AreEqual(201, cadastroUsuario.cadastrarUsuario(("Usuario g"), email7, senha, "true"));

            //Tentativa de cadastro de usuário que já existe
            Assert.AreEqual(400, cadastroUsuario.cadastrarUsuario("Usuario a", email1, senha, "true"));

            //Cadastros para alterar ou excluir
            Assert.AreEqual(201, cadastroUsuario.cadastrarUsuario("Usuario Alterar", emailAlterar, senha, "true"));
            Assert.AreEqual(201, cadastroUsuario.cadastrarUsuario("Usuario Excluir", emailExcluir, senha, "true"));

        }

        [Test]
        public void Teste02EditarUsuario()
        {
            editar.editarUsuario("Usuario Alterada", "pessoaAlterada@gmail.com", "admin", "true");
            Assert.AreEqual(200, editar.editarUsuarioPorId(cadastroUsuario.IdDoUsuario));
        }

        [Test]
        public void Teste03ListarUsuario()
        {

            Assert.AreEqual(200, listar.listarUsuarioPorID(cadastroUsuario.IdDoUsuario));
        }

        [Test]
        public void Teste04ExcluirUsuario()
        {

            Assert.AreEqual(200, excluir.excluirUsuarioPorId(cadastroUsuario.IdDoUsuario));
        }

        //Testes da Questão 2 - Realizar testes de contrato para o verbo POST do endpoint de Produtos (/produtos)

        [Test]
        public void Teste05CadastrarProduto()
        {
            Assert.AreEqual(201, produto.cadastrarProduto(produto1, 120, "TV.........", 450, email4, senha));
            Assert.AreEqual(201, produto.cadastrarProduto(produto2, 250, "BARBEADOR..", 260, email5, senha));
            Assert.AreEqual(201, produto.cadastrarProduto(produto3, 050, "CHAPINHA...", 888, email6, senha));
            Assert.AreEqual(201, produto.cadastrarProduto(produto4, 900, "TENIS......", 588, email7, senha));

        }

        [Test]
        public void Teste06CadastrarProdutoJaExistente()
        {
            Assert.AreEqual(400, produto.cadastrarProduto("TV LED PHILCO 35", 1200, "TV", 1, email1, senha));

        }

        [Test]
        public void Teste07CadastrarProdutoInvalido()
        {
            //Deve retornar Erro 400, pois o nome não pode ficar em branco e preco deve ser um número positivo
            Assert.AreEqual(400, produto.cadastrarProduto("", -2, "TV", -1, "Admin", "Admin"));

        }

        //Teste Questão 3 – Realizar a pesquisa de carrinhos que tenha produtos com quantidade total superior a 5 (resultado deve retornar no mínimo 3 carrinhos).


        [Test]
        public void Teste08CadastrarCarrinho()
        {
            Assert.AreEqual(201, carrinho.cadastrarCarrinho(produto.idsDeProduto[0] + "", 6, email1, senha));
            Assert.AreEqual(201, carrinho.cadastrarCarrinho(produto.idsDeProduto[1] + "", 9, email2, senha));
            Assert.AreEqual(201, carrinho.cadastrarCarrinho(produto.idsDeProduto[2] + "", 10, email3, senha));
            Assert.AreEqual(201, carrinho.cadastrarCarrinho(produto.idsDeProduto[3] + "", 7, email4, senha));

        }

        [Test]
        public void Teste09CarrinhosQuantidadeAcimaCinco()
        {
            Assert.True(carrinho.listarCarrinhoComMaisCincoItens() > 3);

        }

    }
}