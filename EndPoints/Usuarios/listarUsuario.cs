using RestSharp;

//Autor: Brenda Rodrigues
//Classe: Listar

class Listar
{
    public int listarUsuarioPorID(string idUsuario)
    {
        var client = new RestClient("https://serverest.dev/usuarios" + "/" + idUsuario);
        client.Timeout = -1;
        var request = new RestRequest(Method.GET);
        var body = @"";
        request.AddParameter("text/plain", body, ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);
        return ((int)response.StatusCode);

    }

        public int listarUsuarioPorNome(string nome)
    {
        var client = new RestClient("https://serverest.dev/usuarios" + "/" + nome);
        client.Timeout = -1;
        var request = new RestRequest(Method.GET);
        var body = @"";
        request.AddParameter("text/plain", body, ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);
        return ((int)response.StatusCode);

    }

}