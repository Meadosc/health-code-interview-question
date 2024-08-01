namespace MiniThatchTest;

public abstract class UnitTest
{
    protected abstract List<Action> Tests { get; }

    protected static void AssertEqual<T>(T expected, T actual)
    {
        if (!expected.Equals(actual))
        {
            throw new Exception($"Test failed!\nExpected: {expected}\nActual: {actual}");
        }
    }

    public void RunTests()
    {
        var failures = 0;

        foreach (var test in Tests)
        {
            Console.WriteLine($"--- Running test {test.Method.Name}...");
            try
            {
                test();
            }
            catch (Exception e)
            {
                failures++;
                Console.WriteLine($"{e.Message}\n");
            }
        }

        Console.WriteLine($"Ran {Tests.Count} tests, {failures} failures.\n");
        if (failures == 0)
        {
            Console.WriteLine("All tests passed!\n");
        }
    }
}
