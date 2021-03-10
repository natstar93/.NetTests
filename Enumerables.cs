using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace XUnitTestProject
{
    public class IEnumerableTest
    {
        [Fact]
        public void OrderByIEnumerable()
        {
            List<string> tocs = new List<string> { "SNCF", "Eurostar", "Chiltern Railways", "" };
            IEnumerable<string> sortedTocs = tocs.Where(toc => toc.Length > 0).OrderBy(toc => toc);

            List<string> expected = new List<string> { "Chiltern Railways", "Eurostar", "SNCF" };

            Assert.Equal(expected, sortedTocs); // this passes but the types are different
        }

        [Fact]
        public void MaxEnumerable()
        {

            List<int> passengers = new List<int> { 2, 1, 1, 4, 1, 1, 4 };

            int highestNumberOfPassengers = passengers.Max();

            Assert.Equal(4, highestNumberOfPassengers);
        }

        [Fact]
        public void AverageEnumerable()
        {
            List<double> ticketPrices = new List<double> { 20.00, 38.40, 6.70, 118.20 };

            double averageTicketPrice = Math.Round(ticketPrices.Average(), 2, MidpointRounding.AwayFromZero);

            Assert.Equal(45.83, averageTicketPrice);
        }

        [Fact]
        public void SelectMany()
        {
            Toc[] tocs = {
                new Toc { TocName = "SNCF", TicketName = new List<string> { "TresCool", "PasBon" } },
                new Toc { TocName = "Renfe", TicketName = new List<string> { "Primero", "Segundo" } }
            };
            IEnumerable<string> ticketTypes = tocs.SelectMany(toc => toc.TicketName, (toc, ticketName) => String.Format("{0} {1}", toc.TocName, ticketName));

            Assert.Equal(4, ticketTypes.Count());
            Assert.Equal("SNCF TresCool", ticketTypes.First());
            Assert.Equal("SNCF PasBon", ticketTypes.ElementAt(1));
            Assert.Equal("Renfe Primero", ticketTypes.ElementAt(2));
            Assert.Equal("Renfe Segundo", ticketTypes.Last());
        }

        [Fact]
        public void SelectManyWhere()
        {
            Station[] stations =
            {
                new Station { Name = "St Pancras", Shops = new List<string> { "Pret", "Boots", "Rituals" } },
                new Station { Name = "Marylebone", Shops = new List<string> { "Pret", "Boots", "WHSmith" } }
            };
            var results = stations.SelectMany(station => station.Shops, (station, shopName) => new { station, shopName })
                .Where(stationAndShop => !stationAndShop.shopName.Equals("Pret"))
                .Select(stationAndShop => new
                {
                    Location = stationAndShop.station.Name,
                    Shop = stationAndShop.shopName,
                });

            var expected = new[]
            {
                new {
                    Location = "St Pancras",
                    Shop = "Boots",
                },
                new { Location = "St Pancras", Shop = "Rituals" },
                new { Location = "Marylebone", Shop = "Boots" },
                new { Location = "Marylebone", Shop = "WHSmith" }
            }.AsEnumerable();

            Assert.Equal(expected, results);
        }

        [Fact]
        public void IEnumerableYield()
        {
            IEnumerable<string> IdNos(int max)
            {
                for (int i = 0; i < max; i++)
                {
                    yield return i.ToString();
                }
            }

            IEnumerable<string> expected = new List<string> { "0", "1", "2" };

            var result = IdNos(3);
                
            Assert.Equal(expected, result);
        }

        [Fact]
        public void FirstOrDefault()
        {
            Fee[] fees =  {
                new Fee { Name="Booking Fee", Cost=1.50m },
                new Fee { Name="Refund Fee", Cost=5.70m },
                new Fee { Name="Toc Admin Charge", Cost=2.00m }
            };

            Assert.Equal(fees[1], fees.FirstOrDefault(fee => fee.Cost > 5m));
            Assert.Equal(fees[0], fees.FirstOrDefault(fee => fee.Cost < 5m));
            Assert.Equal(fees[2], fees.FirstOrDefault(fee => fee.Cost == 2m));
            Assert.Null(fees.FirstOrDefault(fee => fee.Cost == 0m));

            Assert.Equal(fees[1], fees.First(fee => fee.Cost > 5m));
            Assert.Throws<InvalidOperationException>(() => fees.First(fee => fee.Cost == 0m));
            // I had to accept an option in VS to handle the exception here.
            // Would another user checking out the repo and running this test have to do the same? If so is there a better way to handle?
        }
    }
}
