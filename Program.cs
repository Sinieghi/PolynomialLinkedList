class Program
{
    static void Main(string[] args)
    {
        Polynomial polynomial = new();
        Polynomial polynomial2 = new();
        //8x3+9x3+9x2+12x1+7x1+16x0 
        polynomial.Create([4, 9, 6, 7], [3, 2, 1], 4);
        polynomial2.Create([4, 9, 6, 7, 9], [3, 3, 1, 1], 5);
        polynomial.Addition(polynomial2);
        polynomial.Display();
        System.Console.WriteLine(polynomial.Evaluate(3));
    }
}