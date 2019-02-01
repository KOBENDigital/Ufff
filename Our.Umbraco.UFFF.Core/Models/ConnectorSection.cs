using Our.Umbraco.Ufff.Core.Interfaces;
using System;
using System.Collections.Generic;

namespace Our.Umbraco.UFFF.Core.Models
{
    /// <summary>
    /// It represents a section in a connector aka subfolder. This is a container that holds available Triggers and Actions.
    /// </summary>
    public class ConnectorSection
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        public string Alias { get; }

        /// <summary>
        /// Readable name to display in the backoffice
        /// </summary>
        public string Name { get; }



        public ConnectorSection(string alias, string name)
        {
            Alias = alias;
            Name = name;
        }

        /// <summary>
        /// List of available actions for this connector
        /// </summary>
        public ICollection<IAction> Actions { get; set; } = new List<IAction>();

        /// <summary>
        /// List of available triggers for this connector
        /// </summary>
        public ICollection<ITrigger> Triggers { get; set; } = new List<ITrigger>();
    }
}
