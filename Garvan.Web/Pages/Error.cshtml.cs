using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace Garvan.Web.Pages
{
    public class ErrorModel : PageModel
    {
        private readonly ILogger<ErrorModel> _logger;

        [BindProperty]
        public int StatusCode { get; set; }

        public ErrorModel(ILogger<ErrorModel> logger)
        {
            _logger = logger;
        }

        public void OnGet(int statusCode)
        {
            _logger.LogInformation($"Unexpected Status Code: {statusCode}, OriginalPath: {HttpContext.Items["originalPath"]}");
            StatusCode = statusCode;
        }
    }
}
