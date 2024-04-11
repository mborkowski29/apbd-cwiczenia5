using Tutorial4.Models;

namespace Tutorial4.Database;

public class MockDb
{
    public List<Animal> Animals { get; set; } = new List<Animal>();
    public List<Visit> Visits { get; set; } = new List<Visit>();

    public MockDb()
    {
        Animals.Add(new Animal { Id = 1, FirstName = "Burek", Category = "Pies", Weight = 45, FurColor = "Brązowy" });
        Animals.Add(new Animal { Id = 2, FirstName = "Murek", Category = "Kot", Weight = 8, FurColor = "Czarny" });
        Animals.Add(new Animal { Id = 3, FirstName = "Rurek", Category = "Pies", Weight = 28, FurColor = "Biały" });
        Animals.Add(new Animal { Id = 4, FirstName = "Durek", Category = "Kot", Weight = 7, FurColor = "Żółty" });
        
        Visits = new List<Visit>
        {
            new Visit { VisitDate = DateTime.Now, Animal = Animals[0], Description = "Badanie ogólne", Price = 80, Id = 1},
            new Visit { VisitDate = DateTime.Now.AddDays(-1), Animal = Animals[1], Description = "Szczepienie", Price = 200,Id = 2 },
            new Visit { VisitDate = DateTime.Now.AddDays(-2), Animal = Animals[2], Description = "Pobieranie krwi", Price = 100,Id = 3 },
            new Visit { VisitDate = DateTime.Now.AddDays(-3), Animal = Animals[3], Description = "Operacja", Price = 350,Id = 4 }
        };
        }
        
    }
