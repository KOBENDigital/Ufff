using System;
using System.Collections.Generic;
using System.Linq;
using Our.Umbraco.Ufff.Core.Interfaces;

namespace Our.Umbraco.UFFF.Core.Services
{
    public class TriggerService
    {
        private DataService _db;

        public TriggerService()
        {
            _db = new DataService();
        }

        /// <summary>
        /// It'll find all <see cref="ITrigger"/>
        /// </summary>
        /// <returns></returns>
        public IEnumerable<ITrigger> GetAvailableTriggers()
        {
            var triggers =  AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(ITrigger).IsAssignableFrom(p) && !p.IsInterface && !p.IsAbstract);


            var instances = new List<ITrigger>();
            foreach (var triggerType in triggers)
            {
                instances.Add((ITrigger)Activator.CreateInstance(triggerType));
            }

            return instances;
        }


        /// <summary>
        /// It finds the linked Actions for a trigger and hydrate its Actions list.
        /// </summary>
        /// <param name="trigger"></param>
        public void HydrateTriggerActions(ITrigger trigger)
        {
            var actionsData = _db.GetActions(trigger);
            trigger.Actions = InstantiateActions(actionsData).ToList();
        }

        /// <summary>
        /// Finds the <see cref="IAction"/>s from the data information and instantiate them.
        /// </summary>
        /// <param name="actionData"></param>
        /// <returns></returns>
        private IEnumerable<IAction> InstantiateActions(IEnumerable<Models.Data.Action> actionData)
        {
            var actions = AppDomain.CurrentDomain.GetAssemblies()
                .SelectMany(s => s.GetTypes())
                .Where(p => typeof(IAction).IsAssignableFrom(p) && !p.IsInterface);


            foreach (Type type in actions)
            {
                IAction action = (IAction)Activator.CreateInstance(type);
                yield return action;
            }
        }
    }
}
