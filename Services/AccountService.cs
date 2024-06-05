using APBD10.Models;
using APBD10.ResponseModel;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Exceptions;

namespace APBD10.Services;

public interface IAccountService
{
    Task<GetAccountResponseModel> GetAccountById(int id, CancellationToken cancellationToken);
}

public class AccountService(DatabaseContext context) : IAccountService
{
    public async Task<GetAccountResponseModel> GetAccountById(int id, CancellationToken cancellationToken)
    {
        
        var result = await context.Accounts
            .Where(a => a.Id == id)
            .Select(account => new GetAccountResponseModel
            {
                FirstName = account.FirstName,
                LastName = account.LastName,
                Email = account.Email,
                Phone = account.Phone,
                Role = context.Roles.Where(role => role.Id == account.RoleId).Select(role => role.Name)
                    .First(),
                Cart = context.ShoppingCarts.Where(cart => cart.AccountId == id).Select(cart => new GetCartModel
                {
                    ProductId = cart.ProductId,
                    ProductName = context.Products.Where(product => product.Id == cart.ProductId)
                        .Select(product => product.Name).First(),
                    Amount = cart.Amount
                }).ToList()
            }).FirstOrDefaultAsync(cancellationToken);
        
        
        if (result is null)
        {
            throw new NotFoundException($"Account with id:{id} does not exist");
        }

        return result;
    }
}