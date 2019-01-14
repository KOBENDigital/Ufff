using Our.Umbraco.Ufff.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace Our.Umbraco.UFFF.Core.Models
{
    public abstract class TriggerBase : ITrigger
    {
        public List<IAction> Actions { get; set; } = new List<IAction>();

        public abstract string Alias { get; }

        public abstract Guid Id { get; }

        public abstract string Name { get; }

        public abstract void Register();

    }
}
