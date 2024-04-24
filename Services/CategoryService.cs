namespace ConsoleApp.Services;


public class CategoryService
{
    private readonly AppDbContext _context = new AppDbContext();

    public ResultDto Create(int parentCategoryId, string name)
    {
        var parentCategory = Get(parentCategoryId).Value;

        var category = new Category
        {
            Name = name,
            ParentCategory = parentCategory
        };
        _context.Categories.Add(category);
        _context.SaveChanges();
        return new ResultDto { Message = "Category Created" , IsSuccess = true };
    }

    public ResultDto Update(int id, string name)
    {
        var category = Get(id).Value;
        category.Name = name;

        _context.Categories.Update(category);
        _context.SaveChanges();

        return new ResultDto { Message = "Product updated", IsSuccess = true };
    }

    public ResultDto Remove(int id)
    {
        var product = Get(id).Value;

        _context.Categories.Remove(product);
        _context.SaveChanges();

        return new ResultDto { Message = "Product removed", IsSuccess = true };
    }

    public ResultDto<Category> Get(int id)
    {
        var category = _context.Categories.Where(p => p.Id == id).FirstOrDefault();
        if (category is null)
        {
            return new ResultDto<Category>
            {
                Message = "This product not exist!",
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
                Message = "This product not exist!",
                IsSuccess = false
            };
        }

        return new ResultsDto<Category> { Value = categories, IsSuccess = true };
    }

}