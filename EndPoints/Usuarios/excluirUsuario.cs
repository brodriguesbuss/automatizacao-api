using RestSharp;

//Autor: Brenda Rodrigues
//Classe: Excluir

class Excluir
{
    public int excluirUsuarioPorId(string idUsuario)
    {
        string url = "https://serverest.dev/usuarios" + "/" + idUsuario;
        var client = new RestClient(url);
        client.Timeout = -1;
        var request = new RestRequest(Method.DELETE);
        request.AddHeader("Content-Type", "application/json");
        var body = @"";
        request.AddParameter("application/json", body, ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);
        return ((int)response.StatusCode);

    }
}