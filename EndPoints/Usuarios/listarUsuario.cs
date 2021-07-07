using RestSharp;

//Autor: Brenda Rodrigues
//Classe: Listar

class Listar
{
    //Metodo: listarUsuarioPorID
    //Objetivo: Listar usuario por Id
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

    //Metodo: listarUsuarioPorNome
    //Objetivo: Listar usuario por Nome
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