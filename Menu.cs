namespace ConsoleApp;

public class Menu
{
    public static void Main()
    {
        Console.Clear();
        Console.Write("--------------------------------------");
        Console.SetCursorPosition(5, 5);
        Console.Write("Menu:");
        Console.SetCursorPosition(7, 7);
        Console.Write("1- Product");
        Console.SetCursorPosition(7, 9);
        Console.Write("2- Category");
        Console.SetCursorPosition(7, 11);
        Console.Write("3- Add Product Inventory");
        Console.SetCursorPosition(7, 13);
        Console.Write("4- Low Product Inventory");
        Console.SetCursorPosition(7, 15);
        Console.Write("5- Product report");
        Console.SetCursorPosition(7, 17);
        Console.Write("6- Exist");
        Console.SetCursorPosition(7, 19);
        Console.Write("Choice: ");
    }
    public static void productMenu()
    {
        Console.Clear();
        Console.Write("--------------------------------------");
        Console.SetCursorPosition(5, 5);
        Console.Write("Product Menu:");
        Console.SetCursorPosition(7, 7);
        Console.Write("1- Create");
        Console.SetCursorPosition(7, 9);
        Console.Write("2- Get All");
        Console.SetCursorPosition(7, 11);
        Console.Write("3- Search By Name");
        Console.SetCursorPosition(7, 13);
        Console.Write("4- Update");
        Console.SetCursorPosition(7, 15);
        Console.Write("5- Delete");
        Console.SetCursorPosition(7, 17);
        Console.Write("6- Back");
        Console.SetCursorPosition(7, 19);
        Console.Write("Choice: ");
    }
    public static void CategoryMenu()
    {
        Console.Clear();
        Console.Write("--------------------------------------");
        Console.SetCursorPosition(5, 5);
        Console.Write("Category Menu:");
        Console.SetCursorPosition(7, 7);
        Console.Write("1- Create");
        Console.SetCursorPosition(7, 9);
        Console.Write("2- Get All");
        Console.SetCursorPosition(7, 11);
        Console.Write("3- Update");
        Console.SetCursorPosition(7, 13);
        Console.Write("4- Delete");
        Console.SetCursorPosition(7, 15);
        Console.Write("5- Back");
        Console.SetCursorPosition(7, 17);
        Console.Write("Choice: ");
    }
    public static void AddProductInventory()
    {
        Console.Clear();
        Console.Write("--------------------------------------");
        Console.SetCursorPosition(5, 5);
        Console.Write("Add Product Inventory Menu:");
        Console.SetCursorPosition(7, 7);
        Console.Write("Id: ");
    }
    public static void LowProductInventory()
    {
        Console.Clear();
        Console.Write("--------------------------------------");
        Console.SetCursorPosition(5, 5);
        Console.Write("Low Product Inventory Menu:");
        Console.SetCursorPosition(7, 7);
        Console.Write("Id: ");
    }
}