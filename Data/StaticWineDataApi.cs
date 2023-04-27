using Vinlotteri_backend.Models;

namespace Vinlotteri_backend.Data;

public static class StaticWineDataApi
{
    public static readonly List<Wine> Wines = new List<Wine>
    {
        new Wine { Name = "Chateau Lafite Rothschild 1982", Price = 150, WonBy = string.Empty},
        new Wine { Name = "Penfolds Grange Hermitage 2004", Price = 160, WonBy = string.Empty},
        new Wine { Name = "Chateau Margaux 2010", Price = 170, WonBy = string.Empty},
        new Wine { Name = "Screaming Eagle Cabernet Sauvignon 1992", Price = 180, WonBy = string.Empty},
        new Wine { Name = "Domaine de la Romanee-Conti Romanee-Conti Grand Cru 2007", Price = 190, WonBy = string.Empty},
        new Wine { Name = "Vega Sicilia Unico Gran Reserva 1996", Price = 200, WonBy = string.Empty},
        new Wine { Name = "Petrus Pomerol 2005", Price = 205, WonBy = string.Empty},
        new Wine { Name = "Gaja Barbaresco 2016", Price = 210, WonBy = string.Empty},
        new Wine { Name = "Chateau Haut-Brion 2005", Price = 215, WonBy = string.Empty},
        new Wine { Name = "Sassicaia Tenuta San Guido 2015", Price = 220, WonBy = string.Empty},
        new Wine { Name = "Opus One Napa Valley 2016", Price = 225, WonBy = string.Empty},
        new Wine { Name = "Chateau Mouton Rothschild 1986", Price = 230, WonBy = string.Empty},
        new Wine { Name = "Tignanello Antinori Toscana 2016", Price = 235, WonBy = string.Empty},
        new Wine { Name = "Chateau d'Yquem Sauternes 2005", Price = 240, WonBy = string.Empty},
        new Wine { Name = "Clos des Lambrays Grand Cru 2009", Price = 250, WonBy = string.Empty}
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
                WonBy = string.Empty
            });
        }

        return randomWines;
    }
}