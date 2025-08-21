using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SpendSmart.Models;

namespace SpendSmart.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly SpendSmartDbContext _dbContext;

    public HomeController(ILogger<HomeController> logger, SpendSmartDbContext dbContext)
    {
        _logger = logger;
        _dbContext = dbContext;
    }

    public IActionResult Index()
    {
        return View();
    }
    public async Task<IActionResult> Expenses()
    {
        var allexpenses = await _dbContext.Expenses.ToListAsync();
        var totalexpenses = await _dbContext.Expenses.SumAsync(x => x.Amount);
        ViewBag.TotalExpenses = totalexpenses;
        return View(allexpenses);
    }
    public async Task<IActionResult> CreateEditExpense(int? id)
    {
        if (id.HasValue)
        {
            // Edit mode: Load existing expense
            var expense = await _dbContext.Expenses.FindAsync(id.Value);
            if (expense == null)
            {
                return NotFound();
            }
            return View(expense);
        }

        // Create mode: Return empty model
        return View(new Expense());
    }
    public async Task<IActionResult> DeleteExpense(int? id)
    {
        var deleteexpense = await _dbContext.Expenses.FindAsync(id);
        if (deleteexpense != null)
        {
            _dbContext.Expenses.Remove(deleteexpense);
            await _dbContext.SaveChangesAsync();
        }
        return RedirectToAction("Expenses");
    }
    [HttpPost]
    public async Task<IActionResult> SubmitForm(Expense model)
    {
        if (model.Id == 0)
        {
            // Creating new expense - set the current date
            model.Date = DateTime.Now;
            _dbContext.Expenses.Add(model);
        }
        else
        {
            // Editing an existing expense
            var existingExpense = await _dbContext.Expenses.FindAsync(model.Id);
            if (existingExpense == null)
            {
                return NotFound();
            }

            // Update only the properties you want to change
            existingExpense.Description = model.Description;
            existingExpense.Amount = model.Amount;
            // Date is preserved from the existing record
        }

        await _dbContext.SaveChangesAsync();
        return RedirectToAction("Expenses");
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
