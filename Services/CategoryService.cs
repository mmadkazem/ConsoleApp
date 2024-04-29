using Microsoft.EntityFrameworkCore;

namespace ConsoleApp.Services;


public class CategoryService
{
    private readonly AppDbContext _context = new AppDbContext();

    public ResultDto Create(int parentCategoryId, string name)
    {
        var category = new Category
        {
            Name = name,
        };

        var result = Get(parentCategoryId);
        if (result.IsSuccess)
        {
            category.ParentCategory = result.Value;
        }

        _context.Categories.Add(category);
        _context.SaveChanges();
        return new ResultDto { Message = "Category Created", IsSuccess = true };
    }

    public ResultDto Update(int id, string name)
    {
        var result = Get(id);
        if (!result.IsSuccess)
        {
            return result;
        }
        result.Value.Name = name;

        _context.Categories.Update(result.Value);
        _context.SaveChanges();

        return new ResultDto { Message = "Product updated", IsSuccess = true };
    }

    public ResultDto Remove(int id)
    {
        try
        {
            var result = Get(id);
            if (!result.IsSuccess)
            {
                return result;
            }

            _context.Categories.Remove(result.Value);
            _context.SaveChanges();

            return new ResultDto { Message = "Product removed", IsSuccess = true };
        }
        catch
        {
            return new ResultDto { IsSuccess = false, Message = "category is Parent category." };
        }
    }

    private ResultDto<Category> Get(int id)
    {
        var category = _context.Categories.Where(p => p.Id == id).FirstOrDefault();
        if (category is null)
        {
            return new ResultDto<Category>
            {
                Message = "This category does not exist!",
                IsSuccess = false
            };
        }
        return new ResultDto<Category> { Value = category, IsSuccess = true };
    }

    public ResultsDto<Category> GetAll()
    {
        var categories = _context.Categories.ToList();
        if (categories is null)
        {
            return new ResultsDto<Category>
            {
                Message = "categories does not exist!",
                IsSuccess = false
            };
        }

        return new ResultsDto<Category> { Value = categories, IsSuccess = true };
    }

}