namespace ConsoleApp.Controllers;

public class CategoryController
{
    public static void CategoryMenu()
    {
        while (true)
        {
            Menu.productMenu();
            int ch = int.Parse(Console.ReadLine());
            Console.Clear();
            var _service = new CategoryService();
            switch (ch)
            {
                case 1:
                    Create(_service);
                    Thread.Sleep(5000);
                    break;

                case 2:
                    GetAll(_service);
                    Thread.Sleep(5000);
                    break;

                case 3:
                    Update(_service);
                    Thread.Sleep(5000);
                    break;
                case 4:
                    Remove(_service);
                    Thread.Sleep(5000);
                    break;
                    
                default:
                    break;
            }
            if (ch == 5)
            {
                break;
            }
        }
    }
    #region CategoryService
    private static void GetAll(CategoryService _service)
    {
        var results = _service.GetAll();
        Console.WriteLine(results.ToString());
        foreach (var item in results.Value)
        {
            Console.WriteLine(item.ToString());
        }
    }

    private static void Update(CategoryService _service)
    {
        Console.Write("Id: ");
        var id = int.Parse(Console.ReadLine());
        Console.Write("Name: ");
        var name = Console.ReadLine();

        var result = _service.Update(id, name);
        Console.Write($"Message: {result.Message}");
    }

    private static void Create(CategoryService _service)
    {
        Console.Write("Name: ");
        var name = Console.ReadLine();
        Console.Write("parent Category Id: ");
        var parentCategoryId = int.Parse(Console.ReadLine());

        var result = _service.Create(parentCategoryId, name);
        Console.Write($"Message: {result.Message}");

    }

    private static void Remove(CategoryService _service)
    {
        Console.Write("Id: ");
        var id = int.Parse(Console.ReadLine());
        var result = _service.Remove(id);
        Console.Write($"Message: {result.Message}");
    }
    #endregion
}