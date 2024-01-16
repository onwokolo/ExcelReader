public class StockPrice
{
    public int Id { get; set; }
    public string Counter { get; set; } = string.Empty;
    public string Ticker { get; set; } = string.Empty;
    public decimal PClose { get; set; }
    public decimal Open { get; set; }
    public decimal High { get; set; }
    public decimal Low { get; set; }
    public decimal Close { get; set; }
    public decimal TodayPriceChange { get; set; }
}