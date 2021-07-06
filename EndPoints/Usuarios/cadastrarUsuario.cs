using System;
using RestSharp;

//Autor: Brenda Rodrigues
//Classe: Cadastrar

class Cadastrar
{

    public string id = "";

    public int cadastrarUsuario(string nome, string email, string password, string ehAdm)
    {

        var client = new RestClient("https://serverest.dev/usuarios");
        client.Timeout = -1;
        var request = new RestRequest(Method.POST);
        request.AddHeader("Content-Type", "application/json");
        var body = "{" + "\n" +
        "\"nome\":\"" + nome + "\"" + "," + "\n" +
        "\"email\":\"" + email + "\"" + "," + "\n" +
        "\"password\":\"" + password + "\"" + "," + "\n" +
        "\"administrador\":\"" + ehAdm + "\"" + "\n" +
        "}";
        request.AddParameter("application/json", body, ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);

        if ((int)response.StatusCode == 201)
        {
            string resultadoJSON = response.Content;
            char[] caracteresIgnorar = { ' ', ',', '.', ':', '\"', '\t', '\n', '{', '}', '_', '\r' };
            string[] array = resultadoJSON.Split(caracteresIgnorar, StringSplitOptions.RemoveEmptyEntries);
            id = array[6];
        }
        return ((int)response.StatusCode);
    }
}