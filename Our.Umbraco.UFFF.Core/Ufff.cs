using Our.Umbraco.Ufff.Core.Interfaces;
using System;
using System.Linq;
using Umbraco.Core.Components;

namespace Our.Umbraco.Ufff.Core
{
    class Ufff
    {

        void RegisterTriggers()
        {
            var triggerType = typeof(ITrigger);
            var triggers = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => triggerType.IsAssignableFrom(p) && !p.IsInterface)
                .OfType<ITrigger>();


            foreach (var trigger in triggers)
            {
                trigger.Register();
            }

        }
    }
}
