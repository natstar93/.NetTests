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
            Toc[] tocs = { new Toc { TocName = "SNCF", TicketName = new List<string> { "TresCool", "PasBon" } }, new Toc { TocName = "Renfe", TicketName = new List<string> { "Primero", "Segundo" } } };
            IEnumerable<string> ticketTypes = tocs.SelectMany(toc => toc.TicketName, (toc, ticketName) => String.Format("{0} {1}", toc.TocName, ticketName));

            Assert.Equal(4, ticketTypes.Count());
            Assert.Equal("SNCF TresCool", ticketTypes.First());
            Assert.Equal("SNCF PasBon", ticketTypes.ElementAt(1));
            Assert.Equal("Renfe Primero", ticketTypes.ElementAt(2));
            Assert.Equal("Renfe Segundo", ticketTypes.Last());
        }
    }
}
