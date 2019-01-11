using Our.Umbraco.Ufff.Core.Interfaces;
using Our.Umbraco.UFFF.Core.Services;
using System;
using System.Linq;

namespace Our.Umbraco.Ufff.Core
{
    class Ufff
    {
        private DataService _dataService;
        private TriggerService _triggerService;

        public Ufff()
        {
            _dataService = new DataService();
            _triggerService = new TriggerService();
        }



        public void Init()
        {
            _dataService.CreateTables();
            RegisterTriggers();
        }


        void RegisterTriggers()
        {
            var triggers = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(ITrigger).IsAssignableFrom(p) && !p.IsInterface);


            foreach (var triggerType in triggers)
            {
                ITrigger trigger = (ITrigger)Activator.CreateInstance(triggerType);

                _triggerService.HydrateTriggerActions(trigger);
                trigger.Register();
            }

        }
    }
}
