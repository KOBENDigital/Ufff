using Our.Umbraco.Ufff.Core.Attributes;
using Our.Umbraco.Ufff.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core;
using Umbraco.Core.Logging;

namespace Our.Umbraco.UFFF.Core.Models
{
    public class TreeStructure
    {
        public static IList<Connector> Connectors { get; set; } = new List<Connector>();


        public static void Build(IEnumerable<ITrigger> triggers)
        {

            foreach (var trigger in triggers)
            {
                ConnectorAttribute attr = (ConnectorAttribute)Attribute.GetCustomAttribute(trigger.GetType(), typeof(ConnectorAttribute));
                if (attr == null)
                {
                    LogHelper.Warn(typeof(TreeStructure), $"The trigger doesn't have the ConnectorAttribute. Trigger: {trigger.Alias}. Type: {trigger.GetType().FullName}");
                }
                else
                {
                    var connector = AddConnector(attr.ConnectorAlias, attr.ConnectorName);
                    var section = AddSection(connector, attr.SectionAlias, attr.SectionName);
                    AddTrigger(section, trigger);
                }
            }
        }

        private static void AddTrigger(ConnectorSection section, ITrigger trigger)
        {
            if (section == null)
            {
                throw new ArgumentNullException(nameof(section));
            }

            if (trigger == null)
            {
                throw new ArgumentNullException(nameof(trigger));
            }

            var existingTrigger= section.Triggers
                                         .FirstOrDefault(c => c.Alias.Equals(trigger.Alias, StringComparison.OrdinalIgnoreCase));

            if(existingTrigger == null)
            {
                section.Triggers.Add(trigger);
            }

        }

        private static ConnectorSection AddSection(Connector connector, string sectionAlias, string sectionName)
        {
            if (connector == null) throw new ArgumentNullException(nameof(connector));
            if (sectionAlias.IsNullOrWhiteSpace()) throw new ArgumentNullException(nameof(sectionAlias));
            if (string.IsNullOrWhiteSpace(sectionName)) throw new ArgumentNullException(nameof(sectionName));

            var existingSection = connector.Sections
                                           .FirstOrDefault(c => c.Alias.Equals(sectionAlias, StringComparison.OrdinalIgnoreCase));
            if (existingSection == null)
            {
                var newSection = new ConnectorSection(sectionAlias, sectionName);
                connector.Sections.Add(newSection);
                return newSection;
            }

            return existingSection;

        }

        private static Connector AddConnector(string alias, string name)
        {
            if (string.IsNullOrWhiteSpace(alias))
            {
                throw new ArgumentNullException(nameof(alias));
            }

            if (string.IsNullOrWhiteSpace(name))
            {
                throw new ArgumentNullException(nameof(name));
            }

            var existingConnector = Connectors.FirstOrDefault(con => con.Alias.Equals(alias, StringComparison.OrdinalIgnoreCase));
            if (existingConnector == null)
            {
                var newConnector = new Connector(alias, name);
                Connectors.Add(newConnector);

                return newConnector;
            }

            return existingConnector;
        }
    }
}
