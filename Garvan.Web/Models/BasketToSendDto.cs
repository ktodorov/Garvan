using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Garvan.Web.Models
{
    public class BasketToSendDto
    {
        [Required]
        [JsonProperty("shopObjects")]
        public IEnumerable<ShopObjectDto> ShopObjects { get; set; }

        [Required]
        [JsonProperty("name")]
        public string Name { get; set; }

        [Required]
        [JsonProperty("email")]
        public string Email { get; set; }

        [Required]
        [JsonProperty("subject")]
        public string Subject { get; set; }

        [Required]
        [JsonProperty("message")]
        public string Message { get; set; }

        [Required]
        [JsonProperty("recaptcha-response")]
        public string RecaptchaResponse { get; set; }
    }
}
