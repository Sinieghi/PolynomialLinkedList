class Polynomial
{

    Node First;

    public Polynomial() { First = null; }
    public void Create(int[] C, int[] E, int n)
    {
        Node node, last;
        First = new() { exp = E[0], coef = C[0], next = null };
        last = First;
        for (int i = 1; i < n; i++)
        {
            node = new()
            {
                coef = i > C.Length - 1 ? 0 : C[i],
                exp = i > E.Length - 1 ? 0 : E[i],
                next = null
            };
            last.next = node;
            last = node;
        }

    }

    static int Pow(int m, int n)
    {
        if (n == 0) return 1;
        if (n % 2 == 0) return Pow(m * m, n / 2);
        return Pow(m * m, (n - 1) / 2) * m;
    }


    public double Evaluate(int x)
    {
        double sum = 0.0;
        Node node = First;
        while (node != null)
        {
            sum += node.coef * Pow(x, node.exp);
            node = node.next;
        }
        return sum;
    }




    public void Addition(Polynomial pol)
    {
        Node p1 = First;
        Node p2 = pol.First;
        Node last;
        Node third;
        if (p1.exp > p2.exp)
        {
            third = last = p1;
            p1 = p1.next;
            third.next = null;
        }
        else if (p1.exp < p2.exp)
        {
            third = last = p2;
            p2 = p2.next;
            third.next = null;
        }
        else
        {
            p1.coef += p2.coef;
            third = last = p1;
            p1 = p1.next;
            p2 = p2.next;
            third.next = null;
        }
        //8x3+9x3+9x2+12x1+7x1+16x0 
        while (p1 != null && p2 != null)
        {
            if (p1.exp < p2.exp)
            {
                last.next = p2;
                last = p2;
                p2 = p2.next;
            }
            else if (p1.exp > p2.exp)
            {
                last.next = p1;
                last = p1;
                p1 = p1.next;

            }
            else
            {
                p1.coef += p2.coef;
                last.next = p1;
                last = p1;
                p2 = p2.next;
                p1 = p1.next;
            }
            last.next = null;
        }

        if (p1 != null) last.next = p1;
        else last.next = p2;
    }

    public void Display()
    {
        Node node = First;
        while (node != null)
        {
            System.Console.Write(node.coef);
            System.Console.Write("x");
            System.Console.Write(node.exp);
            if (node.next != null) System.Console.Write("+"); else System.Console.Write(" = ");
            node = node.next;
        }
    }

}