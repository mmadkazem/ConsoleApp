namespace ConsoleApp.Entities;

public class Category
{
    public int Id { get; set; }
    public string Name { get; set; }
    public Category ParentCategory { get; set; }

    public override string ToString()
    {
        return $"Id: {Id}\nName: {Name}\n";
    }
}