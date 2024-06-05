using APBD10.ResponseModel;
using APBD10.Services;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Exceptions;

namespace APBD10.Controllers;
[ApiController]
[Route("/api/products")]
public class ProductController(IProductService productService) : ControllerBase
{
    [HttpPost]
    public async Task<IActionResult> AddProduct(CancellationToken cancellationToken, PostProductModel postProductModel)
    {
        try
        {
            var result = await productService.AddProduct(postProductModel, cancellationToken);
            return Ok(result);
        }
        catch (NotFoundException e)
        {
            return NotFound(e.Message);
        }
    }
}