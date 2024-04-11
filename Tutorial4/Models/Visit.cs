
namespace Tutorial4.Models;

public class Visit
{
    public DateTime VisitDate { get; set; }
    public Animal Animal { get; set; }
    public string Description { get; set; }
    public double Price { get; set; }
    
    public int Id { get; set; }
}