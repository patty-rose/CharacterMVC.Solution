using System.Threading.Tasks;
using RestSharp;

namespace CharacterMVC.Models
{
  class ApiHelper
  {
    public static async Task<string> GetAll()
    {
      RestClient client = new RestClient("http://localhost:5004/api");//should include the port that CretaceousPark is set to listen to. For the purposes of this project, we assume it listens on 5000 as it does in the example repo. If you choose to deploy an API at some point, you'll need to update the URL to include the domain of the deployed site instead of localhost.
      RestRequest request = new RestRequest($"characters", Method.GET);//endpoint = characters
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    //key differences between Getcharacters() and GetDetails(): 1. GetDetails The method will return a singular character. 2. GetDetails() will take an id. 3. the API call results in a JSOn object as opposed to a JSON array

    public static async Task<string> Get(int id)
    {
      RestClient client = new RestClient("http://localhost:5004/api");
      RestRequest request = new RestRequest($"characters/{id}", Method.GET);
      var response = await client.ExecuteTaskAsync(request);
      return response.Content;
    }

    public static async Task Post(string newCharacter)//newCharacter string is header/body. we will convert to JSON
    {
      RestClient client = new RestClient("http://localhost:5004/api");
      RestRequest request = new RestRequest($"characters", Method.POST);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newCharacter);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Put(int id, string newCharacter)
    {
      RestClient client = new RestClient("http://localhost:5004/api");
      RestRequest request = new RestRequest($"characters/{id}", Method.PUT);
      request.AddHeader("Content-Type", "application/json");
      request.AddJsonBody(newCharacter);
      var response = await client.ExecuteTaskAsync(request);
    }

    public static async Task Delete(int id)
    {
      RestClient client = new RestClient("http://localhost:5004/api");
      RestRequest request = new RestRequest($"characters/{id}", Method.DELETE);
      request.AddHeader("Content-Type", "application/json");
      var response = await client.ExecuteTaskAsync(request);
    }
  }
}