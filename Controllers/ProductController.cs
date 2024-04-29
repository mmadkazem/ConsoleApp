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
                    SearchByName();
                    Menu.PresEnterToBack();
                    break;

                case 4:
                    Update();
                    Menu.PresEnterToBack();
                    break;

                case 5:
                    Remove();
                    Menu.PresEnterToBack();
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
        Console.Clear();
        var _service = new ProductService();
        var results = _service.Report();
        if (!results.IsSuccess)
        {
            Menu.PrintMessage($"Message: {results.Message}");
            return;
        }

        // Presentation
        foreach (var item in results.Value)
        {
            Console.Write(item.Report());
        }
        Menu.PresEnterToBack();
    }
    #endregion

    #region ProductService
    private static void GetAll()
    {
        var _service = new ProductService();
        var results = _service.GetAll();
        foreach (var item in results.Value)
        {
            Console.Write(item.ToString());
        }
    }

    private static void SearchByName()
    {
        var _service = new ProductService();
        Console.Write("Name: ");
        var name = Console.ReadLine();
        var result = _service.SearchByName(name);
        if (!result.IsSuccess)
        {
            Menu.PrintMessage($"Message: {result.Message}");
            return;
        }
        Menu.PrintMessage(result.ToString() + result.Value.ToString());
    }

    private static void Update()
    {
        var _service = new ProductService();
        Console.Write("Id: ");
        var id = int.Parse(Console.ReadLine());
        var newProduct = ReadProduct();
        var result = _service.Update(id, newProduct);
        Menu.PrintMessage($"Message: {result.Message}");
    }

    private static void Create()
    {
        var _service = new ProductService();
        var product = ReadProduct();
        var result = _service.Create(product);
        Menu.PrintMessage($"Message: {result.Message}");

    }

    private static void Remove()
    {
        var _service = new ProductService();
        Console.Write("Id: ");
        var id = int.Parse(Console.ReadLine());
        var result = _service.Remove(id);
        Menu.PrintMessage($"Message: {result.Message}");
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
        Menu.PrintMessage($"Message: {result.Message}");
        Menu.PresEnterToBack();

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
        Menu.PrintMessage($"Message: {result.Message}");
        Menu.PresEnterToBack();
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