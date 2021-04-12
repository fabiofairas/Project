using System;
using System.Text.Json.Serialization;

namespace Project.Model.DTOs
{
    public class ClienteRequest
    {
        public ClienteRequest()
        {
            Id = Guid.NewGuid();
        }
        
        [JsonIgnore]
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public int Idade { get; set; }
    }    
}