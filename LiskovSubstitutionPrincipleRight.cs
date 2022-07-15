public abstract class Paralelogramo {
    protected Paralelogramo(int altura, int largura)
    {
        Altura = altura;
        Largura = largura;
    }

    public double Altura { get; private set; }
    public double Largura { get; private set ; }
    public double Area { get { return Altura * Largura; } } 
}

public class Retagulo : Paralelogramo {
    public Retagulo(int altura, int largura)
            :base(altura, largura) { }
}

public class Quadrado : Paralelogramo {
    public Quadrado(int altura, int largura)
        : base(altura, largura) {
        if(largura != altura)
            throw new ArgumentException("Os dois lados do quadrado precisam ser iguais");
    }
}

public class CalculoArea
{
    private static void ObterAreaParalelogramo(Paralelogramo ret)
    {
        Console.Clear();
        Console.WriteLine("Calculo da área do Paralelogramo");
        Console.WriteLine();
        Console.WriteLine(ret.Altura + " * " + ret.Largura);
        Console.WriteLine();
        Console.WriteLine(ret.Area);
        Console.ReadKey();
    }

    public static void Calcular()
    {
        Paralelogramo quad = new Quadrado(5, 5);
        Paralelogramo ret = new Retangulo(10, 5);

        ObterAreaParalelogramo(quad);
        ObterAreaParalelogramo(ret);
    }
}