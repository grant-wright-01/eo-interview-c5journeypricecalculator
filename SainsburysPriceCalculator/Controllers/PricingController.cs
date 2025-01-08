using Microsoft.AspNetCore.Mvc;

namespace SainsburysPriceCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class PricingController : ControllerBase
    {
        private List<string> _availableJourneyCodes = ["YY01", "XX01", "ABC123", "TTPS"];

        [HttpPost]
        public int CalculatePrice([FromBody] PricingRequest pricingRequest)
        {
            if (pricingRequest.Haulier == Haulier.Sainsburys)
            {
                if (pricingRequest.JourneyCode == "YY01")
                {
                    return (pricingRequest.Distance /  10) * pricingRequest.Discount;
                }
                else if (pricingRequest.JourneyCode == "XX01")
                {
                    return (pricingRequest.Distance / 10) * (pricingRequest.Discount + 4);
                }
                else
                {
                    throw new Exception("invalid journey code");
                }
            }
            else if (pricingRequest.Haulier == Haulier.Evri)
            {
                if (pricingRequest.JourneyCode == "ABC123")
                {
                    return 200 + pricingRequest.Discount;
                }
                else
                {
                    throw new Exception("invalid product code");
                }
            }
            else if (pricingRequest.Haulier == Haulier.UPS)
            {
                if (pricingRequest.JourneyCode == "TTPS")
                {
                    return 10 * pricingRequest.Distance * 2;
                }
                else if (pricingRequest.JourneyCode == "YY01")
                {
                    return (10 * pricingRequest.Distance) / 2;
                }
                else if (pricingRequest.JourneyCode == "XX01")
                {
                    return pricingRequest.Distance * 3 * pricingRequest.Discount;
                }
                else
                {
                    throw new Exception("invalid journey code");
                }
            }
            else
            {
                throw new Exception("invalid haulier");
            }
        }
    }
}
