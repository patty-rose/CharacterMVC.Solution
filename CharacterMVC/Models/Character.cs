using System.Collections.Generic;
using System;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace CharacterMVC.Models
{
  public class Character
  {
    public int CharacterId { get; set; }
    
    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int Age { get; set; }

    public string MediaTitle{ get; set; }

    public string MediaType { get; set; }

    public static List<Character> GetCharacters()
    {
      var apiCallTask = ApiHelper.GetAll();
      var result = apiCallTask.Result;

      JArray jsonResponse = JsonConvert.DeserializeObject<JArray>(result);
      List<Character> CharacterList = JsonConvert.DeserializeObject<List<Character>>(jsonResponse.ToString());

      return CharacterList;
    }

    //key differences between GetCharacters() and GetDetails(): 1. GetDetails The method will return a singular Character. 2. GetDetails() will take an id. 3. the API call results in a JSOn object as opposed to a JSON array
    public static Character GetDetails(int id)
    {
      var apiCallTask = ApiHelper.Get(id);
      var result = apiCallTask.Result;

      JObject jsonResponse = JsonConvert.DeserializeObject<JObject>(result);
      Character Character = JsonConvert.DeserializeObject<Character>(jsonResponse.ToString());

      return Character;
    }

    public static void Post(Character Character)
    {
      string jsonCharacter = JsonConvert.SerializeObject(Character);//converts Character object into JSON 
      var apiCallTask = ApiHelper.Post(jsonCharacter);
    }

    public static void Put(Character Character)
    {
      string jsonCharacter = JsonConvert.SerializeObject(Character);
      var apiCallTask = ApiHelper.Put(Character.CharacterId, jsonCharacter);
    }

    public static void Delete(int id)
    {
      var apiCallTask = ApiHelper.Delete(id);
    }
  }
}