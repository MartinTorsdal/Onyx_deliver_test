using checkVatServiceRef;
using System.Threading.Tasks;

public class VatVerifier
{
    enum VerificationStatus
    {
        Valid,
        Invalid,
        // Unable to get status (e.g. service unavailable)
        Unavailable
    }

    /// <summary>
    /// Verifies the given VAT number for the given country using the EU VIES web service.
    /// </summary>
    /// <param name="countryCode"></param>
    /// <param name="vatNumber"></param>
    /// <returns>Verification status</returns>
    // TODO: Implement Verify method

    public async Task<checkVatResponse> Verify(string countryCode, string vatNumber) 
    {
        checkVatRequest vatReq = new checkVatRequest() 
        { 
            countryCode = countryCode, 
            vatNumber = vatNumber 
        };

        checkVatPortTypeClient client = new checkVatPortTypeClient(); 

        return await client.checkVatAsync(vatReq);
    }
}