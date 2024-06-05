using APBD10.Services;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Exceptions;

namespace APBD10.Controllers;

[ApiController]
[Route("/api/accounts")]
public class AccountController(IAccountService accountService) : ControllerBase
{
    [HttpGet("{accountId:int}")]
    public async Task<IActionResult> GetAccountById(CancellationToken cancellationToken, int accountId)
    {
        try
        {
            var result = await accountService.GetAccountById(accountId, cancellationToken);
            return Ok(result);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}