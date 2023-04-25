using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using NetFullStack.Models;
using AutoMapper;
using NetFullStack.Entities;
using NetFullStack.Services;

namespace NetFullStack.Controllers;

public class HomeController : Controller
{
    public IAicommerceRepository _repository;
    public IMapper _mapper;
    private readonly ILogger<HomeController> _logger;
    public HomeController(IAicommerceRepository repository, IMapper mapper, ILogger<HomeController> logger)
    {
        _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));
        _logger = logger ?? throw new ArgumentNullException(nameof(logger));
    }

    [Route("/")]
    public async Task<IActionResult> Index()
    {
        var products = await _repository.GetProductsAsync();
        return View(_mapper.Map<IEnumerable<ProductDto>>(products));
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
