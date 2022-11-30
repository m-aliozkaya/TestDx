namespace TestDx.Entities;

public class BaseEntity
{
    public int Id { get; set; }
    public int ColorId { get; set; }
    
    // Reference object
    public Color Color { get; set; }
}