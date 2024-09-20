using Core.Entities.Common;

namespace Core.Entities;

public class Product : BaseEntity
{
    public string Name { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    public string Image { get; set; }
    public int Rating { get; set; }
	public bool IsInStock { get; set; }
    public int CategoryId { get; set; }
    public Category Category { get; set; }

}
