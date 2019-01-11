using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Our.Umbraco.Ufff.Core.Interfaces
{
    public interface IAction
    {
        /// <summary>
        /// Action alias. It must be unique in the combination Connector/Section
        /// </summary>
        string Alias { get; }

        /// <summary>
        /// Alias of the <see cref="ITrigger"/> this action is associated to.
        /// </summary>
        string TriggerAlias { get; set; }

        /// <summary>
        /// It will run the action.
        /// </summary>
        void Run();
    }
}
