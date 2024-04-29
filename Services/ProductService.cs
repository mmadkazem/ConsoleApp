using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Services;

public class ProductService
{
    private readonly AppDbContext _context = new AppDbContext();

    public ResultDto Create(ProductDto model)
    {
        var category = _context.Categories.Find(model.CategoryId);
        if (category is null)
        {
            return new ResultDto { Message = "This category not found!", IsSuccess = false };
        }

        var product = new Product()
        {
            Name = model.Name,
            Inventory = model.Inventory,
            Category = category
        };
        _context.Products.Add(product);
        _context.SaveChanges();
        return new ResultDto { Message = "Product Created", IsSuccess = true };
    }

    public ResultDto Update(int id, ProductDto model)
    {
        var result = Get(id);
        if (!result.IsSuccess)
        {
            return result;
        }
        var category = _context.Categories.Find(model.CategoryId);
        if (category is null)
        {
            return new ResultDto { IsSuccess = false, Message = "Category does not exist." };
        }
        result.Value.Name = model.Name;
        result.Value.Inventory = model.Inventory;
        result.Value.Category = category;

        _context.Products.Update(result.Value);
        _context.SaveChanges();

        return new ResultDto { Message = "Product updated", IsSuccess = true };
    }

    public ResultDto Remove(int id)
    {
        var result = Get(id);
        if (!result.IsSuccess)
        {
            return result;
        }

        _context.Products.Remove(result.Value);
        _context.SaveChanges();

        return new ResultDto { Message = "Product removed", IsSuccess = true };
    }

    public ResultDto<Product> SearchByName(string name)
    {
        var product = _context.Products.Where(p => p.Name == name).FirstOrDefault();
        if (product is null)
        {
            return new ResultDto<Product> { Message = "This product not exist!", IsSuccess = false };
        }
        return new ResultDto<Product> { Value = product, IsSuccess = true };
    }
    private ResultDto<Product> Get(int id)
    {
        var product = _context.Products.Where(p => p.Id == id).FirstOrDefault();
        if (product is null)
        {
            return new ResultDto<Product> { Message = "This product does not exist!", IsSuccess = false };
        }
        return new ResultDto<Product> { Value = product, IsSuccess = true };
    }

    public ResultsDto<Product> Report()
    {
        var products = _context.Products.Include(p => p.Category).ToList();
        if (products.Count == 0)
        {
            return new ResultsDto<Product> { Message = "products does not exist!", IsSuccess = false };
        }
        return new ResultsDto<Product> { Value = products, IsSuccess = true };
    }

    public ResultsDto<Product> GetAll()
    {
        var products = _context.Products.ToList();
        if (products.Count == 0)
        {
            return new ResultsDto<Product> { Message = "product does not exist!", IsSuccess = false };
        }

        return new ResultsDto<Product> { Value = products, IsSuccess = true };
    }

    public ResultDto AddInventory(int id, int inventory)
    {
        var result = Get(id);
        if (!result.IsSuccess)
        {
            return result;
        }

        result.Value.Inventory += inventory;
        _context.Products.Update(result.Value);
        _context.SaveChanges();
        return new ResultDto { Message = $"{inventory} Inventory added", IsSuccess = true };
    }

    public ResultDto LowInventory(int id, int inventory)
    {
        var result = Get(id);
        if (!result.IsSuccess)
        {
            return result;
        }
        if (result.Value.Inventory - inventory <= 0)
        {
            return new ResultDto { Message = "This amount is not in stock", IsSuccess = false };
        }

        result.Value.Inventory += inventory;
        _context.Products.Update(result.Value);
        _context.SaveChanges();

        return new ResultDto { Message = $"{inventory} added in Inventory", IsSuccess = true };
    }

}
public record ProductDto(string Name, int Inventory, int CategoryId);