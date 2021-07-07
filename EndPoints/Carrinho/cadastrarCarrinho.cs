using System;
using System.Collections;
using RestSharp;

//Autor: Brenda Rodrigues
//Classe: Carrinho

class Carrinho
{

    //Variaveis
    public ArrayList IdsDeCarrinho = new ArrayList();
    int contadorCarrinho = 0;

    //Metodo: cadastrarCarrinho
    //Objetivo: Cadastrar produtos no carrinho guardando o ID de cada carrinho
    public int cadastrarCarrinho(string idProduto, int quantidade, string email, string senha)
    {
        Login login = new Login();
        var client = new RestClient("https://serverest.dev/carrinhos");
        client.Timeout = -1;
        var request = new RestRequest(Method.POST);
        request.AddHeader("Authorization", login.geraToken(email, senha));
        request.AddHeader("Content-Type", "application/json");
        var body = "{\"produtos\":[{\"idProduto\":\"" + idProduto + "\", \"quantidade\":\"" + quantidade
        + "\"}]}";
        request.AddParameter("application/json", body, ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);
        if ((int)response.StatusCode == 201)
        {
            string resultadoJSON = response.Content;
            char[] caracteresIgnorar = { ' ', ',', '.', ':', '\"', '\t', '\n', '{', '}', '_', '\r' };
            string[] array = resultadoJSON.Split(caracteresIgnorar, StringSplitOptions.RemoveEmptyEntries);
            IdsDeCarrinho.Add(array[6]);
        }
        else if ((int)response.StatusCode == 401)
        {
            cadastrarCarrinho(idProduto, quantidade, email, senha);
        }
        return ((int)response.StatusCode);
    }

    //Metodo: listarCarrinhoComMaisCincoItens
    //Objetivo: Varrer os produtos
    public int listarCarrinhoComMaisCincoItens()
    {
        foreach (var itemID in IdsDeCarrinho)
        {
            pesquisaCarrinhoPorID(itemID.ToString());
        }
        return contadorCarrinho;
    }

    //Metodo: pesquisaCarrinhoPorID
    //Objetivo: Verificar a quantidade de cada carrinho pesquisando pelo id de carrinho
    public void pesquisaCarrinhoPorID(string id)
    {
        var client = new RestClient("https://serverest.dev/carrinhos" + "/" + id);
        client.Timeout = -1;
        var request = new RestRequest(Method.GET);
        IRestResponse response = client.Execute(request);
        if ((int)response.StatusCode == 200)
        {
            string resultadoJSON = response.Content;
            char[] caracteresIgnorar = { ' ', ',', '.', ':', '\"', '\t', '\n', '{', '}', '_', '\r' };
            string[] array = resultadoJSON.Split(caracteresIgnorar, StringSplitOptions.RemoveEmptyEntries);
            if (Int32.Parse(array[12]) > 5)
            {
                contadorCarrinho++;

            }
        }
    }
}