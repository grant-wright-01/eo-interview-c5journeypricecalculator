namespace SainsburysPriceCalculator
{
    public class PricingRequest
    {
        public Haulier Haulier { get; set; }
        public required string JourneyCode { get; set; }
        public int Distance { get; set; }
        public int Discount { get; set; }
    }

    public enum Haulier
    {
        Sainsburys,
        Evri,
        UPS
    }
}
