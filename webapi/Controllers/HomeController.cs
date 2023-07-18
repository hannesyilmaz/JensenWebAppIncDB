using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Logging;
using webapi.Models;
using webapi.Data;
using Microsoft.EntityFrameworkCore;

namespace webapi.Controllers
{
    [ApiController]
    [Route("/home")]
    public class HomeController : ControllerBase
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MyContext _context;

        public HomeController(ILogger<HomeController> logger, MyContext context)
        {
            _logger = logger;
            _context = context;
        }

        [HttpGet("/home/article")]
        public ActionResult<IEnumerable<Article>> Get(string topic = "", string sortBy = "")
        {
            try
            {
                var articles = _context.Articles.AsQueryable();

                if (!string.IsNullOrEmpty(topic))
                {
                    articles = articles.Where(a => a.Topic == topic);
                }

                switch (sortBy)
                {
                    case "newest":
                        articles = articles.OrderByDescending(a => a.Published);
                        break;
                    case "oldest":
                        articles = articles.OrderBy(a => a.Published);
                        break;
                }

                return Ok(articles.ToList());
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, $"Error occurred while fetching articles: {ex.Message}, {ex.InnerException?.Message}");
                return StatusCode(500, "An error occurred while fetching articles");
            }
        }

        [HttpGet("Error")]
        public IActionResult Error()
        {
            //Adjust this to your own needs. In this case, it just returns an error message.
            return Problem("An error has occurred");
        }
    }
}
