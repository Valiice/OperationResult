using OperationResult;
using static OperationResult.Helpers;

namespace RustErrorHandling.Cons;
static class Program
{
    static void Main()
    {
        Console.WriteLine("Calculator POC");
        Console.WriteLine("==============");

        // Using traditional exception-based error handling
        Console.WriteLine("\nException-based error handling:");
        try
        {
            int result = DivideWithExceptions(10, 0);
            Console.WriteLine($"Result: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
        }

        // Using Result-based error handling
        Console.WriteLine("\nResult-based error handling:");
        Result<int, string> resultWithResultType = DivideWithResultType(10, 0);
        if (resultWithResultType)
        {
            Console.WriteLine($"Result: {resultWithResultType.Value}");
        }
        else
        {
            Console.WriteLine($"Error: {resultWithResultType.Error}");
        }
    }

    // Exception-based error handling
    static int DivideWithExceptions(int dividend, int divisor)
    {
        if (divisor == 0)
        {
            throw new ArgumentException("Divisor cannot be zero.");
        }
        return dividend / divisor;
    }

    // Result-based error handling
    static Result<int, string> DivideWithResultType(int dividend, int divisor)
    {
        if (divisor == 0)
        {
            return Error("Divisor cannot be zero.");
        }
        return Ok(dividend / divisor);
    }
}
