using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using AspnetCoreMvcFull.Models;
using AdventureCore.Data;
using AdventureCore.Models;
using Microsoft.EntityFrameworkCore;

namespace AspnetCoreMvcFull.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ContextoAdventure BdContexto;
    public HomeController(ILogger<HomeController> logger, ContextoAdventure context)
    {
        _logger = logger;
        BdContexto = context;
    }

    public IActionResult Index() {
     
        return View();
    }
  public async Task<JsonResult> GetLisSimple()
  {
    IEnumerable<ProductBasic> productBasic = await BdContexto.Products
    .Where(x => x.ProductSubcategoryId == 1)
    .Select(x => new ProductBasic { IdProductID = x.ProductId, ProductName = x.Name, ListPrince = x.ListPrice })
    .ToListAsync();

    return Json(productBasic);
  }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
