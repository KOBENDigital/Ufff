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
        private readonly string connectorName;
        private readonly string sectionName;
        public ConnectorAttribute(string connectorName, string sectionName)
        {
            this.connectorName = connectorName;
            this.sectionName = sectionName;
        }
    }
}
