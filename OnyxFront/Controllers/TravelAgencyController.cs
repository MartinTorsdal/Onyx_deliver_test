using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Threading.Tasks;
using checkVatServiceRef;

namespace OnyxFront.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TravelAgencyController : ControllerBase
    {

        [HttpGet]
        public IEnumerable<TravelAgentInfo> GetAgentInfo(List<InvoiceGroup> invoiceGroups, int yearToCheck)
        {

            IEnumerable<TravelAgentInfo> numberOfNightsByTravelAgent = invoiceGroups.Where(x => x.IssueDate.Year == yearToCheck)
                .SelectMany(l => l.Invoices.SelectMany(l1 => l1.Observations.Select(l2 => l2)))
                .GroupBy(x => x.TravelAgent)
                .Select(y => new TravelAgentInfo { TotalNumberOfNights = y.Sum(s => s.NumberOfNights), TravelAgent = y.Key }).ToList();

            return numberOfNightsByTravelAgent;
        }

        [HttpGet]
        public IEnumerable<string> GetGuests(List<InvoiceGroup> invoiceGroups)
        {

            IEnumerable<string> repeatedGuestNames = invoiceGroups
                .SelectMany(l => l.Invoices.SelectMany(l1 => l1.Observations.Select(l2 => l2)))
                .GroupBy(p => p.GuestName)
                .Where(g => g.Count() > 1)
                .Select(x => x.First().GuestName)
                .ToList();

            return repeatedGuestNames;
        }

    }
}
