using System.Diagnostics;
using System.Text.Json;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Mvc;
using Zadanie_rekrutacyjne_Aleksandra_Budzikowska.Models;

namespace Zadanie_rekrutacyjne_Aleksandra_Budzikowska.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View(new HomeViewModel());
    }

    [HttpPost]
    public IActionResult Index(HomeViewModel model)
    {
        try
        {
            var array = JsonSerializer.Deserialize<int[]>(model.Input);
            var result = new List<int>();

            var countDictionary = new Dictionary<int, int>();

            foreach(var number in array)
            {
                if (!countDictionary.ContainsKey(number))
                {
                    countDictionary.Add(number, 1);
                }
                else
                {
                    countDictionary[number]++;
                }
            }
            var outputArray = countDictionary.Where(v => v.Value >= 3).OrderByDescending(v => v.Key).Select(v => v.Key);
            model.Output = JsonSerializer.Serialize(outputArray);
        }
        catch (JsonException)
        {
            model.Output = "Error";
        }
        return View(model);
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}

