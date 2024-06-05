using APBD10.Models;
using APBD10.ResponseModel;
using Microsoft.EntityFrameworkCore;
using WebApplication1.Exceptions;

namespace APBD10.Services;

public interface IProductService
{
    Task<PostProductModel> AddProduct(PostProductModel postProductModel,
        CancellationToken cancellationToken);
}

public class ProductService(DatabaseContext context) : IProductService
{

    public async Task<PostProductModel> AddProduct(PostProductModel postProductModel,
        CancellationToken cancellationToken)
    {
        var categories = new List<Category>();
        foreach (var id in postProductModel.ProductCategories)
        {
            var category = await context.Categories
                .Include(c => c.Products) 
                .Where(c => c.Id == id)
                .FirstOrDefaultAsync(cancellationToken);
            if (category is not null)
            {
                categories.Add(category);
            }
            else
            {
                throw new NotFoundException($"Category with id:{id} does not exist");
            }
        }

        var product = new Product
        {
            Name = postProductModel.ProductName,
            Depth = postProductModel.Depth,
            Height = postProductModel.Height,
            Weight = postProductModel.Weight,
            Width = postProductModel.Width,
            Categories = categories
        };

        await context.Products.AddAsync(product, cancellationToken);

 
        foreach (var category in categories)
        {
            if (category.Products is null)
            {
                category.Products = new List<Product>();
            }
            category.Products.Add(product); 
        }

        await context.SaveChangesAsync(cancellationToken);
        return postProductModel;
    }
}