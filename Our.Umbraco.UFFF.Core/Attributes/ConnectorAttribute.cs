using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Our.Umbraco.Ufff.Core.Attributes
{
    /// <summary>
    /// Used to indicate which Connector a Trigger or Action belongs to.
    /// </summary>
    [AttributeUsage(AttributeTargets.Class, Inherited = false)]
    public class ConnectorAttribute : Attribute
    {
        public string ConnectorAlias { get; set; }
        public string ConnectorName{ get; set; }
        public string SectionAlias { get; set; }

        public string SectionName { get; set; }

        public ConnectorAttribute(string connectorAlias, string connectorName, string sectionAlias, string sectionName)
        {
            ConnectorAlias = connectorAlias;
            ConnectorName = connectorName;
            SectionName = sectionName;
            SectionAlias = sectionAlias;
        }
    }
}
