using System;

// Абстрактний клас або інтерфейс для всіх типів графіків
public interface IChart
{
    void Draw();
}

// Конкретний клас для лінійного графіка
public class LineChart : IChart
{
    public void Draw()
    {
        Console.WriteLine("Drawing Line Chart");
        // Логіка для візуалізації лінійного графіка
    }
}

// Конкретний клас для стовпчикового графіка
public class BarChart : IChart
{
    public void Draw()
    {
        Console.WriteLine("Drawing Bar Chart");
        // Логіка для візуалізації стовпчикового графіка
    }
}

// Конкретний клас для кругової діаграми
public class PieChart : IChart
{
    public void Draw()
    {
        Console.WriteLine("Drawing Pie Chart");
        // Логіка для візуалізації кругової діаграми
    }
}

// Абстрактний клас або інтерфейс для фабрики графіків
public interface IGraphFactory
{
    IChart CreateChart();
}

// Конкретна фабрика для лінійного графіка
public class LineChartFactory : IGraphFactory
{
    public IChart CreateChart()
    {
        return new LineChart();
    }
}

// Конкретна фабрика для стовпчикового графіка
public class BarChartFactory : IGraphFactory
{
    public IChart CreateChart()
    {
        return new BarChart();
    }
}

// Конкретна фабрика для кругової діаграми
public class PieChartFactory : IGraphFactory
{
    public IChart CreateChart()
    {
        return new PieChart();
    }
}

class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("Введіть тип графіка (line, bar, pie):");
        string chartType = Console.ReadLine();

        IGraphFactory factory = GetChartFactory(chartType);
        if (factory != null)
        {
            IChart chart = factory.CreateChart();
            chart.Draw();
        }
        else
        {
            Console.WriteLine("Невідомий тип графіка.");
        }
    }

    static IGraphFactory GetChartFactory(string chartType)
    {
        switch (chartType.ToLower())
        {
            case "line":
                return new LineChartFactory();
            case "bar":
                return new BarChartFactory();
            case "pie":
                return new PieChartFactory();
            default:
                return null;
        }
    }
}
