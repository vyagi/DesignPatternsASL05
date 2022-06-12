namespace AdapterPattern;

public interface IThermometer
{
    double GetTemperature();
}

//3rd Party Library



public class MercuryThermometer : IThermometer
{
    public static readonly Random Generator = new();

    public double GetTemperature() => Generator.NextDouble() * 100 - 50;
}

public class Detector
{
    private readonly IThermometer _thermometer;

    public Detector(IThermometer thermometer) => _thermometer = thermometer;

    public Decision Detect() =>
        _thermometer.GetTemperature() switch
        {
            < -5 => Decision.TooCold,
            > 25 => Decision.TooHot,
            _ => Decision.JustRight
        };
}

