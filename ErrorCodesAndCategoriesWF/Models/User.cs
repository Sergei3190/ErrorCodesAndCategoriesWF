using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using Newtonsoft.Json;

namespace ErrorCodesAndCategoriesWF.Models
{
    public class User
    {
        [JsonProperty("Full Name")]
        public string FullName { get; set; }

        [JsonProperty("Country")]
        public string Country { get; set; }

        [JsonProperty("Created At")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonProperty("Id")]
        public long Id { get; set; }

        [JsonProperty("Email")]
        public string Email { get; set; }
    }
}
