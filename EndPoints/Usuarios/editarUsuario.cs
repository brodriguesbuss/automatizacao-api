using System;
using RestSharp;

//Autor: Brenda Rodrigues
//Classe: Editar

class Editar
{
    String body = "";
    public void editarUsuario(string nome, string email, string password, string ehAdm)
    {
        body = "{" + "\n" +
        "\"nome\":\"" + nome + "\"" + "," + "\n" +
        "\"email\":\"" + email + "\"" + "," + "\n" +
        "\"password\":\"" + password + "\"" + "," + "\n" +
        "\"administrador\":\"" + ehAdm + "\"" + "\n" +
        "}";

    }

    public int editarUsuarioPorId(string id)
    {
        var client = new RestClient("https://serverest.dev/usuarios" + "/" + id);
        client.Timeout = -1;
        var request = new RestRequest(Method.PUT);
        request.AddHeader("Content-Type", "application/json");
        request.AddParameter("application/json", body, ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);
        return ((int)response.StatusCode);
    }
}