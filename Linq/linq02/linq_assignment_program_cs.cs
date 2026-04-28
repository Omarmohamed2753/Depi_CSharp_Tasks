using System;
using System.Collections.Generic;
using System.Linq;

class Product
{
    public int ProductID { get; set; }
    public string ProductName { get; set; }
    public string Category { get; set; }
    public decimal UnitPrice { get; set; }
    public int UnitsInStock { get; set; }
}

class Order
{
    public int OrderID { get; set; }
    public decimal Total { get; set; }
    public DateTime OrderDate { get; set; }
}

class Customer
{
    public string CustomerName { get; set; }
    public string Region { get; set; }
    public List<Order> Orders { get; set; }
}

class Program
{
    static void Main(string[] args)
    {
        List<Product> products = new List<Product>
        {
            new Product { ProductID = 1, ProductName = "Chai", Category = "Beverages", UnitPrice = 18, UnitsInStock = 39 },
            new Product { ProductID = 2, ProductName = "Chang", Category = "Beverages", UnitPrice = 19, UnitsInStock = 0 },
            new Product { ProductID = 3, ProductName = "Aniseed Syrup", Category = "Condiments", UnitPrice = 10, UnitsInStock = 13 },
            new Product { ProductID = 4, ProductName = "Chef Anton", Category = "Condiments", UnitPrice = 22, UnitsInStock = 0 },
            new Product { ProductID = 5, ProductName = "Ikura", Category = "Seafood", UnitPrice = 31, UnitsInStock = 20 }
        };

        List<Customer> customers = new List<Customer>
        {
            new Customer
            {
                CustomerName = "Ahmed",
                Region = "WA",
                Orders = new List<Order>
                {
                    new Order { OrderID = 1, Total = 300, OrderDate = new DateTime(1997, 5, 1) },
                    new Order { OrderID = 2, Total = 700, OrderDate = new DateTime(1999, 2, 1) },
                    new Order { OrderID = 3, Total = 100, OrderDate = new DateTime(2000, 1, 1) }
                }
            },
            new Customer
            {
                CustomerName = "Ali",
                Region = "NY",
                Orders = new List<Order>
                {
                    new Order { OrderID = 4, Total = 900, OrderDate = new DateTime(1998, 3, 1) }
                }
            }
        };

        string[] digits = { "zero", "one", "two", "three", "four", "five", "six", "seven", "eight", "nine" };
        int[] arr = { 5, 4, 1, 3, 9, 8, 6, 7, 2, 0 };
        string[] words = { "aPPLE", "AbAcUs", "bRaNcH", "BlUeBeRrY", "ClOvEr", "cHeRry" };
        string[] dictionary = { "apple", "banana", "kiwi", "strawberry", "orange", "grape" };

        var outOfStock = products.Where(p => p.UnitsInStock == 0);

        var inStock = products.Where(p => p.UnitsInStock > 0 && p.UnitPrice > 3);

        var shortDigits = digits.Where((d, i) => d.Length < i);

        var firstOutOfStock = products.FirstOrDefault(p => p.UnitsInStock == 0);

        var expensiveProduct = products.FirstOrDefault(p => p.UnitPrice > 1000);

        var secondNumber = arr.Where(x => x > 5).Skip(1).FirstOrDefault();

        int oddCount = arr.Count(x => x % 2 != 0);

        var customerOrders = customers.Select(c => new
        {
            c.CustomerName,
            OrderCount = c.Orders.Count
        });

        var categoryProducts = products.GroupBy(p => p.Category)
            .Select(g => new
            {
                Category = g.Key,
                Count = g.Count()
            });

        int total = arr.Sum();

        int totalCharacters = dictionary.Sum(w => w.Length);

        var unitsInStock = products.GroupBy(p => p.Category)
            .Select(g => new
            {
                Category = g.Key,
                Units = g.Sum(p => p.UnitsInStock)
            });

        int shortestWord = dictionary.Min(w => w.Length);

        var cheapestPrice = products.GroupBy(p => p.Category)
            .Select(g => new
            {
                Category = g.Key,
                Price = g.Min(p => p.UnitPrice)
            });

        var cheapestProducts = from p in products
                               group p by p.Category into g
                               let minPrice = g.Min(x => x.UnitPrice)
                               from item in g
                               where item.UnitPrice == minPrice
                               select item;

        int longestWord = dictionary.Max(w => w.Length);

        var expensivePrice = products.GroupBy(p => p.Category)
            .Select(g => new
            {
                Category = g.Key,
                Price = g.Max(p => p.UnitPrice)
            });

        var expensiveProducts = from p in products
                                group p by p.Category into g
                                let maxPrice = g.Max(x => x.UnitPrice)
                                from item in g
                                where item.UnitPrice == maxPrice
                                select item;

        double averageLength = dictionary.Average(w => w.Length);

        var averagePrice = products.GroupBy(p => p.Category)
            .Select(g => new
            {
                Category = g.Key,
                Average = g.Average(p => p.UnitPrice)
            });

        var sortedProducts = products.OrderBy(p => p.ProductName);

        var sortedWords = words.OrderBy(w => w, StringComparer.OrdinalIgnoreCase);

        var stockSorted = products.OrderByDescending(p => p.UnitsInStock);

        var sortedDigits = digits.OrderBy(d => d.Length).ThenBy(d => d);

        var sortedByLength = words.OrderBy(w => w.Length)
            .ThenBy(w => w, StringComparer.OrdinalIgnoreCase);

        var sortedCategoryPrice = products.OrderBy(p => p.Category)
            .ThenByDescending(p => p.UnitPrice);

        var descendingWords = words.OrderBy(w => w.Length)
            .ThenByDescending(w => w, StringComparer.OrdinalIgnoreCase);

        var reversedDigits = digits.Where(d => d[1] == 'i').Reverse();

        var productNames = products.Select(p => p.ProductName);

        var upperLower = words.Select(w => new
        {
            Upper = w.ToUpper(),
            Lower = w.ToLower()
        });

        var selectedProducts = products.Select(p => new
        {
            p.ProductName,
            Price = p.UnitPrice,
            p.Category
        });

        var positions = arr.Select((n, i) => new
        {
            Number = n,
            Match = n == i
        });

        int[] numbersA = { 0, 2, 4, 5, 6, 8, 9 };
        int[] numbersB = { 1, 3, 5, 7, 8 };

        var pairs = from a in numbersA
                    from b in numbersB
                    where a < b
                    select new
                    {
                        A = a,
                        B = b
                    };

        var smallOrders = customers.SelectMany(c => c.Orders)
            .Where(o => o.Total < 500);

        var recentOrders = customers.SelectMany(c => c.Orders)
            .Where(o => o.OrderDate.Year >= 1998);

        var firstThreeOrders = customers.Where(c => c.Region == "WA")
            .SelectMany(c => c.Orders)
            .Take(3);

        var skipTwoOrders = customers.Where(c => c.Region == "WA")
            .SelectMany(c => c.Orders)
            .Skip(2);

        var takeWhileNumbers = arr.TakeWhile((n, i) => n >= i);

        var skipUntilDivisible = arr.SkipWhile(n => n % 3 != 0);

        var skipWhilePosition = arr.SkipWhile((n, i) => n >= i);

        bool containsEi = dictionary.Any(w => w.Contains("ei"));

        var outStockGroups = products.GroupBy(p => p.Category)
            .Where(g => g.Any(p => p.UnitsInStock == 0));

        var inStockGroups = products.GroupBy(p => p.Category)
            .Where(g => g.All(p => p.UnitsInStock > 0));

        Console.WriteLine("LINQ Assignment Completed");
    }
}
