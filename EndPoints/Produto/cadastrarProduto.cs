using System;
using System.Collections;
using RestSharp;

//Autor: Brenda Rodrigues
//Classe: CadastrarProduto

class CadastrarProduto
{

    //Variaveis
    public ArrayList idsDeProduto = new ArrayList();
    
    //Metodo: cadastrarProduto
    //Objetivo: Cadastrar produtos guardando seu ID
    public int cadastrarProduto(string nomeProduto, int preco, string descricao, int quantidade, string email, string senha)
    {
        Login login = new Login();
        var client = new RestClient("https://serverest.dev/produtos");
        client.Timeout = -1;
        var request = new RestRequest(Method.POST);
        request.AddHeader("Authorization", login.geraToken());
        request.AddHeader("Content-Type", "application/json");
        var body = "{" + "\n" +
 "\"nome\":\"" + nomeProduto + "\"" + "," + "\n" +
 "\"preco\":\"" + preco + "\"" + "," + "\n" +
 "\"descricao\":\"" + descricao + "\"" + "," + "\n" +
 "\"quantidade\":\"" + quantidade + "\"" + "\n" +
 "}";

        request.AddParameter("application/json", body, ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);

        if ((int)response.StatusCode == 201)
        {
            string resultadoJSON = response.Content;
            char[] caracteresIgnorar = { ' ', ',', '.', ':', '\"', '\t', '\n', '{', '}', '_', '\r' };
            string[] array = resultadoJSON.Split(caracteresIgnorar, StringSplitOptions.RemoveEmptyEntries);
            idsDeProduto.Add(array[6]);
        }
        if ((int)response.StatusCode == 401){
            cadastrarProduto(nomeProduto,  preco,  descricao,  quantidade,  email,  senha);
        }
        return (int)response.StatusCode;
    }
}