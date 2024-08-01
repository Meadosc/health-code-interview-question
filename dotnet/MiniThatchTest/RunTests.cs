namespace MiniThatchTest;

public class RunTests
{
    public static void Main()
    {
        UnitTest[] testSuite = {
            new TotalSpendTest(),
            new InvoiceItemGeneratorTest(),
        };

        foreach (var test in testSuite)
        {
            Console.WriteLine($"#### Running test suite {test.GetType().Name}.cs...");
            test.RunTests();
        }
    }
}
