namespace com.ktgame.ads.core
{
    public class ImpressionData
    {
        public AdPlatform AdPlatform { get; }
        public string AdNetwork { get; }
        public string AdUnit { get; }
        public AdFormat AdFormat { get; }
        public string AdPlacement { get; }
        public string Currency { get; }
        public double Revenue { get; }

        public ImpressionData(AdPlatform adPlatform, string adNetwork, string adUnit, AdFormat adFormat, string placement, string currency, double revenue)
        {
            AdPlatform = adPlatform;
            AdNetwork = adNetwork;
            AdUnit = adUnit;
            AdFormat = adFormat;
            AdPlacement = placement;
            Currency = currency;
            Revenue = revenue;
        }
        
        public override string ToString()
        {
            return $"Impression Data: {AdPlatform} {AdNetwork} {AdUnit} {AdFormat} {AdPlacement} {Revenue} {Currency}";
        }
    }
}