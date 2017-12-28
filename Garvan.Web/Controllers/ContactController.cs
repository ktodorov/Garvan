using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using AutoMapper;
using Garvan.Data.Interfaces;
using Garvan.Entities;
using Garvan.Web.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;

namespace Garvan.Web.Controllers
{
    public class ContactController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public ContactController(IMapper mapper, IEmailService emailService)
        {
            _mapper = mapper;
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> SendEmail(EmailToSendDto emailToSendDto)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, responseText = Resources.Resources.PleaseFillAllFields });
            }

            var response = Request.Form["g-recaptcha-response"];
            if (!response.Any(r => !string.IsNullOrEmpty(r)))
            {
                return Json(new { success = false, responseText = Resources.Resources.InvalidCaptchaEntered });
            }

            string secretKey = "6LellD4UAAAAAGyy_jfZMX7ANXhjXjnQJTYU_DK1";
            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, response));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");

            if (!status)
            {
                return Json(new { success = false, responseText = Resources.Resources.InvalidCaptchaEntered });
            }

            var emailToSend = _mapper.Map<EmailToSend>(emailToSendDto);
            await _emailService.SendEmail(emailToSend);
                return Json(new { success = true, responseText = Resources.Resources.MessageSent });
        }
    }
}