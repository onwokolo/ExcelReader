
// Do database setups including deleting and recreating
var context = Util.InitializeDatabase();

// Get file
FileInfo file = new("./extdata/NSE_Pricelist_06082020.xlsx");

// Insert stockprices in database
Console.WriteLine("Inserting stock prices into database...\n");
context.StockPrice.AddRange(Util.GetStockPricesFromFile(file));
context.SaveChanges();


// Read data from the database
Console.WriteLine("Reading stock prices from database...\n");
var stockPrices = context.StockPrice.ToList();

// Display stock prices gotten from database
Console.WriteLine("Displaying stock prices from database...\n");
Console.WriteLine("Ticker  | PClose | Open | High | Low | Close | Changes | Stock Name");
foreach (var s in stockPrices)
{
    Console.WriteLine($"{s.Ticker} | {s.PClose} | {s.Open} | {s.High} | {s.Low} | {s.Close} | {(s.TodayPriceChange * 100).ToString("0.00")}% | {s.Counter}");
}