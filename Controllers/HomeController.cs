using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NetFullStack.Models;

namespace NetFullStack.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    [Route("/home")]
    public IActionResult Index()
    {
        return View();
    }

    [Route("/privacy")]
    public IActionResult Privacy()
    {
        return View();
    }

    [Route("/product")]
    public IActionResult Details()
    {
        return View();
    }

    [Route("/cart")]
    public IActionResult Cart()
    {
        return View();
    }

    [Route("/dashboard")]
    public IActionResult Dashboard()
    {
        return View();
    }

    [Route("/dashboard/addProduct")]
    public IActionResult DashboardAddProduct()
    {
        return View();
    }

    [Route("/dashboard/orders")]
    public IActionResult DashboardOrders()
    {
        return View();
    }

    [Route("/dashboard/ai")]
    public IActionResult DashboardAI()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
