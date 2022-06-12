using System.Globalization;

namespace AdapterPattern;

public class InternetThermometerAdapter : IThermometer
{
    private readonly InternetThermometer _internetThermometer;
    private readonly string _separator = CultureInfo.CurrentCulture.NumberFormat.NumberDecimalSeparator;

    public InternetThermometerAdapter(InternetThermometer internetThermometer) => _internetThermometer = internetThermometer;

    public double GetTemperature() => 
        double.Parse(_internetThermometer.Themperature.Replace(".",_separator)) - 273.15;
}