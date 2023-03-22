using System.Diagnostics;
using Microsoft.AspNetCore.Cors.Infrastructure;
using Microsoft.AspNetCore.Mvc;
using Webapp.Interfaces;
using Webapp.Models;
using Webapp.Services;

namespace Webapp.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ISrwasButikServices _srwasButikServices;


    public HomeController(ILogger<HomeController> logger, ISrwasButikServices srwasButikServices)
    {
        _logger = logger;
        _srwasButikServices = srwasButikServices;
    }

    [HttpGet()]
    public async Task<IActionResult> Index()
    {
        return View();

    }
    
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }

  
}
