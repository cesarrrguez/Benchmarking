namespace Benchmarking.Benchmarks.JSON;

public class JsonService
{
    public string Serialization_Text_Newtonsoft(User user) => Newtonsoft.Json.JsonConvert.SerializeObject(user);

    public string Serialization_Text_SystemTextJson(User user) => System.Text.Json.JsonSerializer.Serialize(user);

    public string Serialization_Text_Jil(User user) => Jil.JSON.Serialize(user);

    public string Serialization_Text_Utf8Json(User user) => Utf8Json.JsonSerializer.ToJsonString(user);

    public User Deserialization_Text_Newtonsoft(string userAsText) => Newtonsoft.Json.JsonConvert.DeserializeObject<User>(userAsText);

    public User Deserialization_Text_SystemTextJson(string userAsText) => System.Text.Json.JsonSerializer.Deserialize<User>(userAsText);

    public User Deserialization_Text_Jil(string userAsText) => Jil.JSON.Deserialize<User>(userAsText);

    public User Deserialization_Text_Utf8Json(string userAsText) => Utf8Json.JsonSerializer.Deserialize<User>(userAsText);
}
