using CommandApp.Command;
using CommandApp.Feature;

namespace TemperatureApp;

public class CelsiusToFarenheitCommand : BaseCommand
{
    public override string Value { get; } = "ctof";

    public override string Description { get; } = "Convert from Cesius to Farenheit";

    public override IFeature Feature { get; } = new CelsiusToFarenheitFeature();
}

public class FarenheitToCelsiusCommand : BaseCommand
{
    public override string Value { get; } = "ftoc";

    public override string Description { get; } = "Convert from Farenheit to Celsius";

    public override IFeature Feature { get; } = new FarenheitToCelsiusFeature();
}
