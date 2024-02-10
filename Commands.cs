using CommandApp.App;
using CommandApp.Command;

namespace BigApp;

public class SnakeAppCommand : ICommand
{
    public string Value { get; } = "snake";

    public string Description { get; } = "Console based old-school snake game";

    public void Execute(IApp app)
    {
        ICommandCollection commands = new DefaultCommandCollection();
        commands.Register(new SnakeApp.SetArenaSizeCommand());
        commands.Register(new SnakeApp.StartGameCommand());

        IApp snakeApp = new DefaultApp(commands);
        snakeApp.Start();
    }
}

public class TemperatureAppCommand : ICommand
{
    public string Value { get; } = "tc";

    public string Description { get; } = "Temperature converter";

    public void Execute(IApp app)
    {
        ICommandCollection commands = new DefaultCommandCollection();
        commands.Register(new TemperatureApp.CelsiusToFarenheitCommand());
        commands.Register(new TemperatureApp.FarenheitToCelsiusCommand());

        IApp temperatureApp = new DefaultApp(commands);
        temperatureApp.Start();
    }
}
