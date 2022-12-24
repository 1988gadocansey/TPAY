using System.Text.Json.Serialization;

namespace TPAY.Models;

public class PblResponse
{
    [JsonPropertyName("status")]
    public string status { get; set; }

    [JsonPropertyName("message")]
    public string message { get; set; }
        
        
    public Details details;
        
    [JsonPropertyName("statusMessage")]
    public string statusMessage { get; set; }
       
}