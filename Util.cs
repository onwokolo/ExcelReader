using OfficeOpenXml;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

public class Util
{
    public static ApplicationDbContext InitializeDatabase()
    {
        var configuration = new ConfigurationBuilder()
            .AddUserSecrets<Program>()
            .Build();

        var dbConnectionString = configuration["ConnectionStrings:DefaultConnection"];
        // Console.WriteLine($"Connection String: {dbConnectionString}");

        var options = new DbContextOptionsBuilder<ApplicationDbContext>()
                    .UseSqlServer(dbConnectionString)
                    .Options;

        ApplicationDbContext context = new(options);

        // Recreate Db if it already exists
        context.RecreateDatabase();

        return context;
    }

    public static List<StockPrice> GetStockPricesFromFile(FileInfo file)
    {
        Console.WriteLine("Reading stock prices from excel file...\n");
        List<StockPrice> stockPrices = new();
        using (ExcelPackage package = new(file))
        {
            ExcelWorksheet worksheet = package.Workbook.Worksheets[0];
            int rowCount = worksheet.Dimension.Rows;

            for (int row = 2; row <= rowCount; row++) // Assuming the first row is the header
            {
                StockPrice stockPrice = new();
                stockPrice.Counter = worksheet.Cells[row, 1].Value.ToString()!;
                stockPrice.Ticker = worksheet.Cells[row, 2].Value.ToString()!;
                stockPrice.PClose = Convert.ToDecimal(worksheet.Cells[row, 3].Value);
                stockPrice.Open = Convert.ToDecimal(worksheet.Cells[row, 4].Value);
                stockPrice.High = Convert.ToDecimal(worksheet.Cells[row, 5].Value);
                stockPrice.Low = Convert.ToDecimal(worksheet.Cells[row, 6].Value);
                stockPrice.Close = Convert.ToDecimal(worksheet.Cells[row, 7].Value);
                stockPrice.TodayPriceChange = Convert.ToDecimal(worksheet.Cells[row, 8].Value);

                stockPrices.Add(stockPrice);
            }
        }

        return stockPrices;
    }
}