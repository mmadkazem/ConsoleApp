while (true)
{
    try
    {
        Menu.Main();
        int ch = int.Parse(Console.ReadLine());
        switch (ch)
        {
            case 1:
                ProductController.ProductMenu();
                break;
            case 2:
                CategoryController.CategoryMenu();
                break;
            case 3:
                ProductController.AddInventory();
                break;
            case 4:
                ProductController.LowInventory();
                break;
            case 5:
                ProductController.Report();
                break;
            case 6:
                Console.Clear();
                Console.SetCursorPosition(10, 10);
                Console.Write("------this exit------");
                return;

            default:
                break;
        }
    }
    catch (FormatException ex)
    {
        Console.Clear();
        Console.Write($"{ex.Message}");
        Menu.PresEnterToBack();
    }
}