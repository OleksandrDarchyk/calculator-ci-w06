using System.Runtime.CompilerServices;

namespace Calculator;

public class CachedCalculator : ICalculator
{
    private readonly SimpleCalculator _calculator = new();
    private readonly Dictionary<string, Calculation> _cache = new();

    public int CacheCount => _cache.Count;

    public int Add(int a, int b)
        => (GetCachedResult<int>(a, b) ?? StoreInCache(_calculator.Add(a, b), a, b)).Result;

    public int Subtract(int a, int b)
        => (GetCachedResult<int>(a, b) ?? StoreInCache(_calculator.Subtract(a, b), a, b)).Result;

    public int Multiply(int a, int b)
        => (GetCachedResult<int>(a, b) ?? StoreInCache(_calculator.Multiply(a, b), a, b)).Result;

    public int Divide(int a, int b)
        => (GetCachedResult<int>(a, b) ?? StoreInCache(_calculator.Divide(a, b), a, b)).Result;

    public int Factorial(int n)
        => (GetCachedResult<int>(n) ?? StoreInCache(_calculator.Factorial(n), n)).Result;

    public bool IsPrime(int candidate)
        => (GetCachedResult<bool>(candidate) ?? StoreInCache(_calculator.IsPrime(candidate), candidate)).Result;

    private Calculation<T>? GetCachedResult<T>(int a, int? b = null, [CallerMemberName] string operation = "")
    {
        var calc = new Calculation<T>(default, operation, a, b);
        var key = calc.GetKey();
        return _cache.TryGetValue(key, out var value) ? (Calculation<T>?)value : null;
    }

    private Calculation<T> StoreInCache<T>(T result, int a, int? b = null, [CallerMemberName] string operation = "")
    {
        var calc = new Calculation<T>(result, operation, a, b);
        _cache.Add(calc.GetKey(), calc);
        return calc;
    }

    public class Calculation
    {
        private int A { get; }
        private int? B { get; }
        private string Operation { get; }

        protected Calculation(string operation, int a, int? b = null)
        {
            A = a;
            B = b;
            Operation = operation;
        }

        public string GetKey() => string.Concat(A, Operation, B);
    }

    private sealed class Calculation<T>(T? result, string operation, int a, int? b = null)
        : Calculation(operation, a, b)
    {
        public T? Result { get; set; } = result;
    }
}
