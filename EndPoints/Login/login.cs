using RestSharp;

//Autor: Brenda Rodrigues
//Classe: Login
class Login
{        public int logarComSucesso(string email, string senha)
    {
        var client = new RestClient("https://serverest.dev/login");
        client.Timeout = -1;
        var request = new RestRequest(Method.POST);
        request.AddHeader("Content-Type", "application/json");
        var body = "{" + "\n" + "\"email\":\"" + email + "\","+"\n" + "\"senha\":\"" + senha + "\n" + "\"}";
        request.AddParameter("application/json", body, ParameterType.RequestBody);
        IRestResponse response = client.Execute(request);
        return ((int)response.StatusCode);
    }

}

