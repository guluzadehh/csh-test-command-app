using CommandApp.Feature;
using CommandApp.Exceptions;

namespace TemperatureApp;

public abstract class TemperatureFeature : BaseFeature
{
    protected abstract string Info { get; }

    public override void Run()
    {
        App.Output.Write(Info);
        try
        {
            double? inp = GetDouble();
            if (inp == null) return;

            double res = Convert((double)inp!);

            SendResponse($"{inp} Celsius to Fahrenheit = {string.Format("{0:0.00}", res)}");
        }
        catch (QuitInputRead)
        {
            return;
        }
    }

    protected abstract double Convert(double inp);

    private double? GetDouble()
    {
        string inp = App.Input.Get();

        try
        {
            return double.Parse(inp);
        }
        catch
        {
            App.Output.WriteAndWait($"Wrong double format `{inp}`");
        }

        return null;
    }
}

public class CelsiusToFarenheitFeature : TemperatureFeature
{
    protected override string Info { get; } = "Convert from Celsius to Farenheit";

    protected override double Convert(double celsius)
    {
        return celsius * 9 / 5 + 32;
    }
}

public class FarenheitToCelsiusFeature : TemperatureFeature
{
    protected override string Info { get; } = "Convert from Farenheit to Celsius";

    protected override double Convert(double fahrenheit)
    {
        return (fahrenheit - 32) * 5 / 9;
    }
}