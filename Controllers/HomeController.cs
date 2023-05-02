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

    [Route("/product/{id}")]
    public async Task<IActionResult> Details(int id)
    {
        var product = await _repository.GetSingleProductsAsync(id);
        return View(_mapper.Map<ProductDto>(product));
    }


    [Route("/cart")]
    public IActionResult Cart()
    {
        return View();
    }

    [Route("/dashboard")]
    public async Task<IActionResult> Dashboard()
    {
        var products = await _repository.GetProductsAsync();
        return View(_mapper.Map<IEnumerable<ProductDto>>(products));
    }


    [Route("/dashboard/editProduct/{id}")]
    public async Task<IActionResult> DashboardEditProduct(int id)
    {
        var product = await _repository.GetSingleProductsAsync(id);
        return View(_mapper.Map<ProductDto>(product));
    }

    [HttpPost]
    public async Task<ActionResult> EditProduct(ProductDto product)
    {
        Console.WriteLine(product.Name + " " + product.Description + product.Id + "------------------------");
        var productEntity = await _repository.GetSingleProductsAsync(product.Id);
        if (productEntity == null)
        {
            return BadRequest();
        }
        _mapper.Map(product, productEntity);
        await _repository.SaveChangesAsync();
        return RedirectToAction("Dashboard");
    }

    [Route("/dashboard/addProduct")]
    public IActionResult DashboardAddProduct()
    {
        return View();
    }

    [HttpPost]
    public async Task<ActionResult> AddProduct(ProductDto product)
    {
        Console.WriteLine(product.Name + "------------------------------------");
        var productEntity = _mapper.Map<Product>(product);
        _repository.AddProductsAsync(productEntity);
        await _repository.SaveChangesAsync();
        return RedirectToAction("Dashboard");
    }

    [Route("/delete/{id}")]
    public async Task<IActionResult> DeleteProduct(int id) 
    {

        await _repository.DeleteProductAsync(id);
        await _repository.SaveChangesAsync();
        return RedirectToAction("Dashboard");
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

    //[HttpPost]
    [Route("/search")]
    public async Task<ActionResult> SearchProducts(string searchKey)
    {
        var productsFromSearch = await _repository.SearchProductsAsync(searchKey);

        if (productsFromSearch == null) {
            return View();
        }
        //return RedirectToAction("SearchProducts", "Home" , _mapper.Map<IEnumerable<ProductDto>>(productsFromSearch));
        return View(_mapper.Map<IEnumerable<ProductDto>>(productsFromSearch));

    }

    //public IActionResult SearchProducts(IEnumerable<ProductDto> products)
    //{
    //}

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
