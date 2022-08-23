using System;
using System.Collections.Generic;
using System.Linq;

namespace Onyx
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var ob1 = new Observation()
            {
                GuestName = "Tom",
                NumberOfNights = 1,
                TravelAgent = "Kris"
            };
            var ob2 = new Observation()
            {
                GuestName = "Tom",
                NumberOfNights = 2,
                TravelAgent = "Poppy"
            };
            var ob3 = new Observation()
            {
                GuestName = "Bert",
                NumberOfNights = 1,
                TravelAgent = "Kris"
            };
            var ob4 = new Observation()
            {
                GuestName = "Bob",
                NumberOfNights = 3,
                TravelAgent = "Kris"
            };
            var ob5 = new Observation()
            {
                GuestName = "Bob",
                NumberOfNights = 3,
                TravelAgent = "Kris"
            };
            var ob6 = new Observation()
            {
                GuestName = "Bob",
                NumberOfNights = 3,
                TravelAgent = "Kris"
            };
            var ob7 = new Observation()
            {
                GuestName = "Bert",
                NumberOfNights = 3,
                TravelAgent = "Poppy"
            };
            var ob8 = new Observation()
            {
                GuestName = "Kris",
                NumberOfNights = 3,
                TravelAgent = "Kris"
            };

            var lOb1 = new List<Observation> { ob1, ob3, ob4, ob5, ob6 };
            var lOb2 = new List<Observation> { ob2, ob7 };

            var inv1 = new Invoice() { Observations = lOb1 };
            var inv2 = new Invoice() { Observations = lOb2 };

            var invGr = new InvoiceGroup()
            {
                Invoices = new List<Invoice>() { inv1, inv2 },
                IssueDate = new DateTime(2015, 06, 12)

            };
            var invGr1 = new InvoiceGroup()
            {
                Invoices = new List<Invoice>() { inv1, inv2 },
                IssueDate = new DateTime(2016, 06, 12)

            };
            var invoiceGroups = new List<InvoiceGroup>() { invGr, invGr1 };
            

            //1a
            IEnumerable<string> repeatedGuestNames = invoiceGroups
                .SelectMany(l => l.Invoices.SelectMany(l1 => l1.Observations.Select(l2 => l2)))
                .GroupBy(p => p.GuestName)
                .Where(g => g.Count() > 1)
                .Select(x => x.First().GuestName)
                .ToList();

            //1b
            //IEnumerable<TravelAgentInfo> numberOfNightsByTravelAgent
            int yearToCheck = 2015;
            IEnumerable<TravelAgentInfo> numberOfNightsByTravelAgent = invoiceGroups.Where(x => x.IssueDate.Year == yearToCheck)
                .SelectMany(l => l.Invoices.SelectMany(l1 => l1.Observations.Select(l2 => l2)))
                .GroupBy(x => x.TravelAgent)
                .Select(y => new TravelAgentInfo { TotalNumberOfNights = y.Sum(s => s.NumberOfNights), TravelAgent = y.Key }).ToList();

            foreach (var item in repeatedGuestNames)
            {
                Console.WriteLine(item);
            }
            foreach (var item in numberOfNightsByTravelAgent)
            {
                Console.WriteLine(item.TravelAgent + " : " + item.TotalNumberOfNights);
            }


            //3
            VatVerifier vatVerifier = new VatVerifier();

            var vatTask = vatVerifier.Verify("DE", "118856456");
            vatTask.Wait();

            var vatResponse = vatTask.Result;

            Console.WriteLine(vatResponse.valid.ToString());

            Console.ReadLine();
        }
    }   
}
