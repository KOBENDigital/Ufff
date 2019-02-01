using Our.Umbraco.Ufff.Core.Interfaces;
using Our.Umbraco.UFFF.Core.Models;
using Our.Umbraco.UFFF.Core.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Our.Umbraco.Ufff.Core
{
    public static class UfffApplication
    {
        private static DataService _dataService;
        public static TriggerService TriggerService { get; }
        public static IList<ITrigger> Triggers { get; private set; }

        static UfffApplication()
        {
            _dataService = new DataService();
            TriggerService = new TriggerService();
        }


        public static void Init()
        {
            _dataService.CreateTables();
            RegisterTriggers();
            TreeStructure.Build(Triggers);
        }


        private static void RegisterTriggers()
        {
            Triggers = TriggerService.GetAvailableTriggers().ToList();

            foreach (var trigger in Triggers)
            {
                try
                {
                    trigger.Register();
                }
                catch (Exception ex)
                {
                    Triggers.Remove(trigger);
                }
            }
        }


    }
}
