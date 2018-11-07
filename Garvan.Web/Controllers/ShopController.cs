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
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json.Linq;

namespace Garvan.Web.Controllers
{
    public class ShopController : Controller
    {
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;
        private readonly IConfiguration _configuration;

        public ShopController(IMapper mapper, IEmailService emailService, IConfiguration configuration)
        {
            _mapper = mapper;
            _emailService = emailService;
            _configuration = configuration;
        }

        [HttpPost]
        public async Task<IActionResult> SendBasketEmail([FromBody] BasketToSendDto basketToSendDto)
        {
            if (!ModelState.IsValid)
            {
                return Json(new { success = false, responseText = Resources.Resources.PleaseFillAllFields });
            }

            if (string.IsNullOrWhiteSpace(basketToSendDto.RecaptchaResponse))
            {
                return Json(new { success = false, responseText = Resources.Resources.InvalidCaptchaEntered });
            }

            string secretKey = _configuration.GetSection("RecaptchaSecretKey").Value;
            if (string.IsNullOrWhiteSpace(secretKey))
            {
                return Json(new { success = false, responseText = Resources.Resources.ErrorOccurredTryAgain });
            }

            var client = new WebClient();
            var result = client.DownloadString(string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}", secretKey, basketToSendDto.RecaptchaResponse));
            var obj = JObject.Parse(result);
            var status = (bool)obj.SelectToken("success");

            if (!status)
            {
                return Json(new { success = false, responseText = Resources.Resources.InvalidCaptchaEntered });
            }

            var basketToSend = _mapper.Map<BasketToSend>(basketToSendDto);
            await _emailService.SendShopEmailAsync(basketToSend);
            return Json(new { success = true, responseText = Resources.Resources.MessageSent });
        }
    }
}