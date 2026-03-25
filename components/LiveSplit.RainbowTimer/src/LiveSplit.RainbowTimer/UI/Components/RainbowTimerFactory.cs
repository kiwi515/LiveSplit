using System;

using LiveSplit.Model;
using LiveSplit.UI.Components;

[assembly: ComponentFactory(typeof(RainbowTimerFactory))]

namespace LiveSplit.UI.Components;

public class RainbowTimerFactory : IComponentFactory
{
    public string ComponentName => "Rainbow Timer";

    public string Description => "Displays the current run time. Turns rainbow when you PB!";

    public ComponentCategory Category => ComponentCategory.Timer;

    public IComponent Create(LiveSplitState state)
    {
        return new RainbowTimer();
    }

    public string UpdateName => ComponentName;

    public string XMLURL => "";

    public string UpdateURL => "";

    public Version Version => Version.Parse("1.0.0");
}
