using Accounting.Shared.Models;
using Microsoft.AspNetCore.Mvc;

namespace Accounting.Server.Controllers;
[Route("api/[controller]")]
[ApiController]
public class BaseController : Controller
{
    protected readonly IUnitOfWork _iUnitOfWork;
    public BaseController(IUnitOfWork iUnitOfWork)
    {
        _iUnitOfWork = iUnitOfWork;
    }

    [HttpGet]
    [Route(("Accounting/GetAll"))]
    public async Task<IActionResult> AccountingGetAllAsync() => Ok(await _iUnitOfWork.AccountingModelService.GetAllAsync());

    [HttpPost]
    [Route("Accounting/UpdateOrAdd")]
    public async Task<IActionResult> AccountingUpdateOrData([FromBody] AccountingModel accounting)
    {
        try
        {
            var result = await _iUnitOfWork.AccountingModelService.UpdateOrAddAsync(accounting);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest("Error" + ex.Message);
        }
    }

    [HttpGet]
    [Route(("IncomeExpenses/GetAll"))]
    public async Task<IActionResult> IncomeExpensesGetAll() => Ok(await _iUnitOfWork.IncomeExpensesService.GetAllAsync());

    [HttpPost]
    [Route("IncomeExpenses/UpdateOrAdd")]
    public async Task<IActionResult> IncomeExpensesUpdateOrAdd([FromBody] IncomeExpense IncomeExpenses)
    {
        try
        {
            var result = await _iUnitOfWork.IncomeExpensesService.UpdateOrAddAsync(IncomeExpenses);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest("Error" + ex.Message);
        }
    }

    [HttpGet]
    [Route(("CategoryIncomeExpenses/GetAll"))]
    public async Task<IActionResult> CategoryIncomeExpensesGetAll() => Ok(await _iUnitOfWork.CategoryIncomeExpensesService.GetAllAsync());

    [HttpPost]
    [Route("CategoryIncomeExpenses/UpdateOrAdd")]
    public async Task<IActionResult> CategoryIncomeExpensesUpdateOrAdd([FromBody] CategoryIncomeExpenses CategoryIncomeExpenses)
    {
        try
        {
            var result = await _iUnitOfWork.CategoryIncomeExpensesService.UpdateOrAddAsync(CategoryIncomeExpenses);
            return Ok(result);
        }
        catch (Exception ex)
        {
            return BadRequest("Error" + ex.Message);
        }
    }
}
