﻿using Our.Umbraco.Ufff.Core.Attributes;
using Our.Umbraco.Ufff.Core.Interfaces;

namespace Our.Umbraco.UFFF.Core.Models
{
    [Connector("Umbraco", "Content")]
    public abstract class ActionBase : IAction
    {
        public string Alias { get; }
        public string TriggerAlias { get; set; }

        public abstract void Run();
        
    }
}
