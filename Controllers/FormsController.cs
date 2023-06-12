using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using ShortKnowledge.Models;
using ShortKnowledge.Services;

namespace ShortKnowledge.Controllers;

[Route("api/[controller]")]
public class FormsController : Controller 
{   
    private readonly ILogger<FormsController> _logger;

    public FormsController(ILogger<FormsController> logger)
    {
        _logger = logger;
    }

    [HttpPost]
    public async Task<IActionResult> Index(ShortRequestViewModel model)
    {
        if (model.Text != null && model.Text != ""){
            string summary = await SummarizeService.Summarize(model);
            return RedirectToAction("Result","Home",new { summary = summary});
        }
        else if (model.URL != null && model.URL != ""){
            // TODO: Hier muss die URL aufgerufen werden und danach der Inhalt geparst werden
            return BadRequest();
        }

        return BadRequest();
    }
}