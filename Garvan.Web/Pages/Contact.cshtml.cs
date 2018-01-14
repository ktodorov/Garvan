using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Garvan.Data.Interfaces;
using Garvan.Entities;
using Garvan.Web.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Garvan.Web.Pages
{
    public class ContactModel : PageModel
    {
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public ContactModel(IMapper mapper, IEmailService emailService)
        {
            _mapper = mapper;
            _emailService = emailService;
        }

        [BindProperty]
        public EmailToSendDto EmailToSendDto { get; set; }

        //[BindProperty]
        //[JsonProperty(PropertyName = "g-recaptcha-response")]
        //public string RecaptchaResponse { get; set; }

        public void OnGet()
        {
        }

        public async Task OnPostAsync(IFormCollection data)
        {
            var response = data["g-recaptcha-response"];
            string secretKey = "your secret key here";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");

            if (!status || !ModelState.IsValid || EmailToSendDto == null)
            {
                return;// StatusCode(200);
            }

            var emailToSend = _mapper.Map<EmailToSend>(EmailToSendDto);
            await _emailService.SendEmail(emailToSend);
            return;// StatusCode(200);
        }
    }
}
