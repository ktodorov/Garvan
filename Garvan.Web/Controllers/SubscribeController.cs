using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Garvan.Data.Interfaces;
using Garvan.Entities;
using Garvan.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace Garvan.Web.Controllers
{
    public class SubscribeController : Controller
    {
        private readonly ISubscribedUserService _subscribedUserService;

        public SubscribeController(ISubscribedUserService subscribedUserService)
        {
            _subscribedUserService = subscribedUserService;
        }

        [HttpPost]
        public async Task<IActionResult> AddEmail([FromBody]string email)
        {
            if (!ModelState.IsValid || string.IsNullOrWhiteSpace(email))
            {
                return StatusCode(400);
            }

            var dbSubscribedUser = await _subscribedUserService.GetSubscribedUserByEmail(email);
            if (dbSubscribedUser != null)
            {
                return Json(new { success = false, responseText = Resources.Resources.EmailAlreadyRegistered });
            }

            var subscribedUser = new SubscribedUser()
            {
                Email = email
            };

            await _subscribedUserService.AddSubscribedUserAsync(subscribedUser);
            return Json(new { success = true });
        }

        public IActionResult GetRequiredResources()
        {
            var subscribeResources = new SubscribeResourcesModel();
            return Ok(subscribeResources);
        }
    }
}