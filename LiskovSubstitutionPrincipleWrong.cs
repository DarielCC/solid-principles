public abstract class Retagulo {
    public virtual double Altura { get; set; }
    public virtual double Largura { get; set; }

    public double Area { get { return Altura * Largura; } }
}

public class Quadrado : Retagulo {
    public override double Altura { set { base.Altura = base.Largura = value; } } 
    public override double Largura { set { base.Altura = base.Largura = value; } } 
}

public class CalculoArea
{
    private static void ObterAreaRetangulo(Retangulo ret)
    {
        Console.Clear();
        Console.WriteLine("Calculo da área do Retangulo");
        Console.WriteLine();
        Console.WriteLine(ret.Altura + " * " + ret.Largura);
        Console.WriteLine();
        Console.WriteLine(ret.Area);
        Console.ReadKey();
    }

    public static void Calcular()
    {
        var quad = new Quadrado()
        {
            Altura = 10,
            Largura = 5
        };

        ObterAreaRetangulo(quad);
    }
}