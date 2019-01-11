using Our.Umbraco.Ufff.Core.Interfaces;
using Our.Umbraco.UFFF.Core.Services;
using System;
using System.Linq;
using Umbraco.Core.Components;

namespace Our.Umbraco.Ufff.Core
{
    class Ufff
    {
        DataService _dataService;

        public Ufff()
        {
            _dataService = new DataService();
        }



        public void Init()
        {
            _dataService.CreateTables();
            RegisterTriggers();
        }


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
