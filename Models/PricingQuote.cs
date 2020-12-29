using System;

namespace PriceQuoteForValueLabs
{
    public class PricingQuote
    {
        public string Symbol { get; set; }
        public string Name { get; set; }
        public double? Price { get; set; }
        public double? ChangesPercentage { get; set; }
        public double? Change { get; set; }
        public double? DayLow { get; set; }
        public double? DayHigh { get; set; }
        public double? YearHigh { get; set; }
        public double? YearLow { get; set; }
        public double? MarketCap { get; set; }
        public double? PriceAvg50 { get; set; }
        public double? PriceAvg200 { get; set; }
        public int? Volume { get; set; }
        public int? AvgVolume { get; set; }
        public string Exchange { get; set; }
        public double? Open { get; set; }
        public double? PreviousClose { get; set; }
        public double? Eps { get; set; }
        public string Pe { get; set; }
        public DateTime? EarningsAnnouncement { get; set; }
        public int? SharesOutstanding { get; set; }
        public string Timestamp { get; set; }
    }
}