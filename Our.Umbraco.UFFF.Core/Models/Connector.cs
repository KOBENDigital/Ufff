using System;
using System.Collections.Generic;

namespace Our.Umbraco.UFFF.Core.Models
{
    /// <summary>
    /// It represents a Ufff connector. This is a container that holds available Triggers and Actions. These are divided into subsections using <see cref="ConnectorSection"/>
    /// </summary>
    public class Connector
    {

        public Guid Id { get; set; } = Guid.NewGuid();


        /// <summary>
        /// Unique alias
        /// </summary>
        public string Alias { get; }

        /// <summary>
        /// Readable name to display in the backoffice
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Collection of sections/folders
        /// </summary>
        public IList<ConnectorSection> Sections { get; set; } = new List<ConnectorSection>();


        public Connector(string alias, string name)
        {
            Alias = alias ?? throw new ArgumentNullException(nameof(alias));
            Name = name ?? throw new ArgumentNullException(nameof(name));
        }


    }
}
