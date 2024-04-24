
namespace ConsoleApp.Controllers;

public class ProductController
{
    public static void ProductMenu()
    {
        while (true)
        {
            Menu.productMenu();
            int ch = int.Parse(Console.ReadLine());
            Console.Clear();
            var _service = new ProductService();
            switch (ch)
            {
                case 1:
                    Create(_service);
                    Thread.Sleep(2000);
                    break;

                case 2:
                    GetAll(_service);
                    Console.ReadKey();
                    break;
                case 3:
                    SearchByName(_service);
                    Console.ReadKey();
                    break;
                case 4:
                    Update(_service);
                    Thread.Sleep(2000);
                    break;
                case 5:
                    Remove(_service);
                    Thread.Sleep(2000);
                    break;
                default:
                    break;
            }
            if (ch == 6)
            {
                break;
            }
        }
    }
    #region Report Product
    public static void Report()
    {
        var _service = new ProductService();
        var results = _service.Report();
        Console.WriteLine(results.ToString());
        foreach (var item in results.Value)
        {
            Console.WriteLine(item.Report());
        }
        Console.ReadKey();
    }
    #endregion

    #region ProductService
    private static void GetAll(ProductService _service)
    {
        var results = _service.GetAll();
        Console.WriteLine(results.ToString());
        foreach (var item in results.Value)
        {
            Console.WriteLine(item.ToString());
        }
    }

    private static void SearchByName(ProductService _service)
    {
        Console.Write("Name: ");
        var name = Console.ReadLine();
        var result = _service.SearchByName(name);
        Console.Write(result.ToString() + result.Value.ToString());
    }

    private static void Update(ProductService _service)
    {
        Console.Write("Id: ");
        var id = int.Parse(Console.ReadLine());
        var newProduct = ReadProduct();
        var result = _service.Update(id, newProduct);
        Console.Write($"Message: {result.Message}");
    }

    private static void Create(ProductService _service)
    {
        var product = ReadProduct();
        var result = _service.Create(product);
        Console.Write($"Message: {result.Message}");

    }

    private static void Remove(ProductService _service)
    {
        Console.Write("Id: ");
        var id = int.Parse(Console.ReadLine());
        var result = _service.Remove(id);
        Console.Write($"Message: {result.Message}");
    }
    #endregion

    #region InventoryService
    public static void AddInventory()
    {
        // print menu
        Menu.AddProductInventory();

        // read data
        int id = int.Parse(Console.ReadLine());
        Console.SetCursorPosition(7, 9);
        Console.Write("Enter Inventory: ");
        int inventory = int.Parse(Console.ReadLine());
        // do
        var _service = new ProductService();
        var result = _service.AddInventory(id, inventory);

        // print result
        Console.Write($"Message: {result.Message}");
        Thread.Sleep(2000);

    }

    public static void LowInventory()
    {
        // print menu
        Menu.LowProductInventory();

        // read data
        int id = int.Parse(Console.ReadLine());
        Console.Write("Enter Inventory: ");
        int inventory = int.Parse(Console.ReadLine());

        // do
        var _service = new ProductService();
        var result = _service.LowInventory(id, inventory);

        // print result
        Console.Write($"Message: {result.Message}");
        Thread.Sleep(2000);
    }
    #endregion

    #region ReadData
    private static ProductDto ReadProduct()
    {
        Console.Write("Name: ");
        var name = Console.ReadLine();
        Console.Write("Inventory: ");
        var inventory = int.Parse(Console.ReadLine());
        Console.Write("CategoryId: ");
        var CategoryId = int.Parse(Console.ReadLine());
        return new ProductDto(name, inventory, CategoryId);
    }
    #endregion
}