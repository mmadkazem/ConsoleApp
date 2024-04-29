namespace ConsoleApp.Controllers;

public class CategoryController
{
    public static void CategoryMenu()
    {
        while (true)
        {
            Menu.CategoryMenu();
            int ch = int.Parse(Console.ReadLine());
            Console.Clear();
            switch (ch)
            {
                case 1:
                    Create();
                    Menu.PresEnterToBack();
                    break;

                case 2:
                    GetAll();
                    Menu.PresEnterToBack();
                    break;

                case 3:
                    Update();
                    Menu.PresEnterToBack();
                    break;

                case 4:
                    Remove();
                    Menu.PresEnterToBack();
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
    private static void GetAll()
    {
        var _service = new CategoryService();
        var results = _service.GetAll();
        if (!results.IsSuccess)
        {
            Menu.PrintMessage(results.ToString());
            return;
        }

        foreach (var item in results.Value)
        {
            if (item.ParentCategory is not null)
            {
                Console.WriteLine(item.ToString() + $"ParentCategoryId: {item.ParentCategory.Id}\n");
                continue;
            }
            Console.WriteLine(item.ToString());
        }

    }

    private static void Update()
    {
        Console.Write("Id: ");
        var id = int.Parse(Console.ReadLine());
        Console.Write("Name: ");
        var name = Console.ReadLine();

        var _service = new CategoryService();
        var result = _service.Update(id, name);
        Menu.PrintMessage($"Message: {result.Message}");
    }

    private static void Create()
    {
        Console.Write("Name: ");
        var name = Console.ReadLine();
        Console.Write("parent Category Id(Enter 0 if not present): ");
        var parentCategoryId = int.Parse(Console.ReadLine());

        var _service = new CategoryService();
        var result = _service.Create(parentCategoryId, name);
        Console.Write($"Message: {result.Message}");

    }

    private static void Remove()
    {
        Console.Write("Id: ");
        var id = int.Parse(Console.ReadLine());

        var _service = new CategoryService();
        var result = _service.Remove(id);
        Console.Write($"Message: {result.Message}");
    }
    #endregion
}