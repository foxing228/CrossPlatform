using Lab5.Models;
using Lab5ClassLibrary;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Lab5.Controllers;

[Authorize]
public class LabsController : Controller
{
    // GET
    public IActionResult LAB1()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult LAB1(DnaModel model)
    {
        
        var analyzer = new Lab1Resolver.DnaAnalyzer(model.DnaOne, model.DnaTwo);
        try
        { 
            model.Calculated = analyzer.Analyze();
        }
        catch (ArgumentException e)
        {
            model.ErrorValue = e.Message;
        }
        catch (Exception e)
        {
            model.ErrorValue = e.Message;
        }

        return View(model);
    }
    
    public IActionResult LAB2()
    {
        return View();
    }
    
    [HttpPost]
    public IActionResult LAB2(WaysToGet2 model)
    {

        var resolver = new Lab2();
        try
        {
            model.Response = resolver.GetCountOfWaysToShowNumber(model.Number);
            model.Calculated = true;
        }
        catch (ArgumentException e)
        {
            model.ErrorValue = e.Message;
        }
        catch (Exception e)
        {
            model.ErrorValue = e.Message;
        }
    
        return View(model);
    }
    
    // public IActionResult LAB3()
    // {
    //     return View();
    // }
    //
    // [HttpPost]
    // public IActionResult LAB3(Ways model)
    // {
    //     
    //     var analyzer = new Lab1Resolver.DnaAnalyzer(model.DnaOne, model.DnaTwo);
    //     try
    //     { 
    //         model.Calculated = analyzer.Analyze();
    //     }
    //     catch (ArgumentException e)
    //     {
    //         model.ErrorValue = e.Message;
    //     }
    //     catch (Exception e)
    //     {
    //         model.ErrorValue = e.Message;
    //     }
    //
    //     return View(model);
    // }
}   
