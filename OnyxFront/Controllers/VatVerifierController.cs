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
    public class VatVerifierController : ControllerBase
    {
        private readonly VatVerifier _vatVerifier = new VatVerifier();

        [HttpGet]
        public async Task<checkVatResponse> VatVerify(string countryCode, string vatNumber)
        {
            var vatTask = await _vatVerifier.Verify(countryCode, vatNumber);

            return vatTask;
        }
    }
}
