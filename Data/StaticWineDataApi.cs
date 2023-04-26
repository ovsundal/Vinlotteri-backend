using Vinlotteri_backend.Models;

namespace Vinlotteri_backend.Data;

public static class StaticWineDataApi
{
    public static readonly List<Wine> Wines = new List<Wine>
    {
        new Wine { Name = "Chateau Lafite Rothschild 1982", Price = 150, HasBeenAwarded = false},
        new Wine { Name = "Penfolds Grange Hermitage 2004", Price = 160, HasBeenAwarded = false},
        new Wine { Name = "Chateau Margaux 2010", Price = 170, HasBeenAwarded = false},
        new Wine { Name = "Screaming Eagle Cabernet Sauvignon 1992", Price = 180, HasBeenAwarded = false},
        new Wine { Name = "Domaine de la Romanee-Conti Romanee-Conti Grand Cru 2007", Price = 190, HasBeenAwarded = false},
        new Wine { Name = "Vega Sicilia Unico Gran Reserva 1996", Price = 200, HasBeenAwarded = false},
        new Wine { Name = "Petrus Pomerol 2005", Price = 205, HasBeenAwarded = false},
        new Wine { Name = "Gaja Barbaresco 2016", Price = 210, HasBeenAwarded = false},
        new Wine { Name = "Chateau Haut-Brion 2005", Price = 215, HasBeenAwarded = false},
        new Wine { Name = "Sassicaia Tenuta San Guido 2015", Price = 220, HasBeenAwarded = false},
        new Wine { Name = "Opus One Napa Valley 2016", Price = 225, HasBeenAwarded = false},
        new Wine { Name = "Chateau Mouton Rothschild 1986", Price = 230, HasBeenAwarded = false},
        new Wine { Name = "Tignanello Antinori Toscana 2016", Price = 235, HasBeenAwarded = false},
        new Wine { Name = "Chateau d'Yquem Sauternes 2005", Price = 240, HasBeenAwarded = false},
        new Wine { Name = "Clos des Lambrays Grand Cru 2009", Price = 250, HasBeenAwarded = false}
    };

    public static ICollection<Wine> GetRandomWines(int count)
    {
        var randomWines = new List<Wine>();
        var random = new Random();

        for (int i = 0; i < count; i++)
        {
            int index = random.Next(Wines.Count);
            
            randomWines.Add(new Wine
            {
                Name = Wines[index].Name,
                Price = Wines[index].Price,
                HasBeenAwarded = false
            });
        }

        return randomWines;
    }
}