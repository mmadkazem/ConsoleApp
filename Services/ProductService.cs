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
            return new ResultDto { Message = "This category not found!", IsSuccess = false};
        }

        var product = new Product()
        {
            Name = model.Name,
            Inventory = model.Inventory,
            Category = category
        };
        _context.Products.Add(product);
        _context.SaveChanges();
        return new ResultDto { Message = "Product Created" , IsSuccess = true };
    }

    public ResultDto Update(int id, ProductDto model)
    {
        var product = Get(id).Value;
        product.Name = model.Name;
        product.Inventory = model.Inventory;

        _context.Products.Update(product);
        _context.SaveChanges();

        return new ResultDto { Message = "Product updated" , IsSuccess = true};
    }

    public ResultDto Remove(int id)
    {
        var product = Get(id).Value;

        _context.Products.Remove(product);
        _context.SaveChanges();

        return new ResultDto { Message = "Product removed", IsSuccess = true};
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
            return new ResultDto<Product> { Message = "This product not exist!", IsSuccess = false };
        }
        return new ResultDto<Product> { Value = product, IsSuccess = true };
    }

    public ResultsDto<Product> Report()
    {
        var products = _context.Products.Include(p => p.Category).ToList();
        if (products.Count == 0)
        {
            return new ResultsDto<Product> { Message = "This product not exist!", IsSuccess = false };
        }
        return new ResultsDto<Product> { Value = products, IsSuccess = true };
    }

    public ResultsDto<Product> GetAll()
    {
        var products = _context.Products.ToList();
        if (products.Count == 0)
        {
            return new ResultsDto<Product> { Message = "This product not exist!", IsSuccess = false };
        }

        return new ResultsDto<Product> { Value = products, IsSuccess = true };
    }

    public ResultDto AddInventory(int id, int inventory)
    {
        var result = Get(id);
        var product = result.Value;
        if (product is null)
        {
            return new ResultDto { Message = result.Message, IsSuccess = false };
        }

        product.Inventory += inventory;
        _context.Products.Update(product);
        _context.SaveChanges();
        return new ResultDto { Message = $"{inventory} Inventory added", IsSuccess = true };
    }

    public ResultDto LowInventory(int id, int inventory)
    {
        var result = Get(id);
        var product = result.Value;
        if (product is null)
        {
            return new ResultDto { Message = result.Message, IsSuccess = false };
        }
        if (product.Inventory - inventory <= 0)
        {
            return new ResultDto { Message = "This amount is not in stock", IsSuccess = false };
        }

        product.Inventory += inventory;
        _context.Products.Update(product);
        _context.SaveChanges();

        return new ResultDto { Message = $"{inventory} added in Inventory", IsSuccess = true };
    }

}

public record ProductDto(string Name, int Inventory, int CategoryId);
