namespace ConsoleApp.Entities;

public class Product
{
    public int Id { get; set; }
    public string Name { get; set; }
    public int Inventory { get; set; }

    public Category Category { get; set; }
    public int CategoryId { get; set; }
    public override string ToString()
    {
        return $"Id: {Id}\nName: {Name}\nInventory: {Inventory}\n\n";
    }
    public string Report()
    {
        return $"Id: {Id}\nName: {Name}\nInventory: {Inventory}\n CategoryName: {Category.Name}\n\n";
    }
}