namespace Decoration;
public class Program
{
    public static void Main(string[] args)
    {
        ICar basicCar = new BasicCar();
        Console.WriteLine(basicCar.GetDescription());
        Console.WriteLine(basicCar.GetCost());

        ICar sportsCar = new SportsCar(basicCar);
        Console.WriteLine(sportsCar.GetDescription());
        Console.WriteLine(sportsCar.GetCost());

        ICar luxurySportsCar = new LuxuryCar(sportsCar);
        Console.WriteLine(luxurySportsCar.GetDescription());
        Console.WriteLine(luxurySportsCar.GetCost());
    }
}

// Komponen Dasar (Component)
public interface ICar
{
    string GetDescription();
    double GetCost();
}

// Komponen Konkrit (Concrete Component)
public class BasicCar : ICar
{
    public string GetDescription()
    {
        return "Basic Car";
    }

    public double GetCost()
    {
        return 20000;
    }
}

// Decorator
public abstract class CarDecorator : ICar
{
    protected ICar decoratedCar;

    public CarDecorator(ICar decoratedCar)
    {
        this.decoratedCar = decoratedCar;
    }

    public virtual string GetDescription()
    {
        return decoratedCar.GetDescription();
    }

    public virtual double GetCost()
    {
        return decoratedCar.GetCost();
    }
}

// Decorator Konkrit (Concrete Decorator)
public class SportsCar : CarDecorator
{
    public SportsCar(ICar decoratedCar) : base(decoratedCar)
    {
    }

    public override string GetDescription()
    {
        return $"{base.GetDescription()}, Sports Car";
    }

    public override double GetCost()
    {
        return base.GetCost() + 10000;
    }
}

// Decorator Konkrit (Concrete Decorator)
public class LuxuryCar : CarDecorator
{
    public LuxuryCar(ICar decoratedCar) : base(decoratedCar)
    {
    }

    public override string GetDescription()
    {
        return $"{base.GetDescription()}, Luxury Car";
    }

    public override double GetCost()
    {
        return base.GetCost() + 20000;
    }
}