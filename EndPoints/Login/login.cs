using System;
using RestSharp;

//Autor: Brenda Rodrigues
//Classe: Login
class Login
{
    //Metodo: geraToken
    //Objetivo: Gerar token a partir de um login
     public string geraToken(string email, string senha)
    {
        var client = new RestClient("https://serverest.dev/login");
        client.Timeout = -1;
        var request = new RestRequest(Method.POST);
        request.AddHeader("Content-Type", "application/json");
        var body = "{" + "\n" +
"\"email\":\"" + email + "\"" + "," + "\n" +
"\"password\":\"" + senha + "\"" + "\n" +
"}";
        request.AddParameter("application/json", body, ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);
        string token = "Bearer ";

        if ((int)response.StatusCode == 200)
        {
            string resultadoJSON = response.Content;
            char[] caracteresIgnorar = { ' ', ',', ':', '\"', '{', '}'};
            string[] array = resultadoJSON.Split(caracteresIgnorar, StringSplitOptions.RemoveEmptyEntries);
            token = token + array[9];

        } 

        return token;

    }

    //Metodo: geraToken
    //Objetivo: Gerar token a partir de um login fixo
    public string geraToken()
    {
        var client = new RestClient("https://serverest.dev/login");
        client.Timeout = -1;
        var request = new RestRequest(Method.POST);
        request.AddHeader("Content-Type", "application/json");
        var body = "{" + "\n" +
"\"email\":\"" + "fulano@qa.com" + "\"" + "," + "\n" +
"\"password\":\"" + "teste" + "\"" + "\n" +
"}";
        request.AddParameter("application/json", body, ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);
        string token = "Bearer ";

        if ((int)response.StatusCode == 200)
        {
            string resultadoJSON = response.Content;
            char[] caracteresIgnorar = { ' ', ',', ':', '\"', '{', '}'};
            string[] array = resultadoJSON.Split(caracteresIgnorar, StringSplitOptions.RemoveEmptyEntries);
            token = token + array[9];

        } 

        return token;

    }

}

