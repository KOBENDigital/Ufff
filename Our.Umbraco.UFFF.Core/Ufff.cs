using Our.Umbraco.Ufff.Core.Interfaces;
using Our.Umbraco.UFFF.Core.Services;
using System.Collections.Generic;

namespace Our.Umbraco.Ufff.Core
{
    public static class UfffApplication
    {
        private static DataService _dataService;
        public static TriggerService TriggerService { get; }
        public static IEnumerable<ITrigger> Triggers { get; private set; }

        static UfffApplication()
        {
            _dataService = new DataService();
            TriggerService = new TriggerService();
        }


        public static void Init()
        {
            _dataService.CreateTables();
            RegisterTriggers();
        }


        private static void RegisterTriggers()
        {
            Triggers = TriggerService.GetAvailableTriggers();

            foreach (var trigger in Triggers)
            {
                trigger.Register();
            }
        }

    }
}
