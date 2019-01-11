using Our.Umbraco.UFFF.Core.Models.Data;
using System.Collections.Generic;

namespace Our.Umbraco.Ufff.Core.Interfaces
{
    public interface ITrigger
    {
        /// <summary>
        /// Stores all the <see cref="IAction"/> registered against this trigger
        /// </summary>
        List<IAction> Actions { get; set; }

        /// <summary>
        /// The alias for this action (must be unique)
        /// </summary>
        string Alias { get; }

        /// <summary>
        /// Registers the trigger into Ufff and loads the related actions from the database if any. This has to include the event listener that needs to be executed.
        /// </summary>
        void Register();
    }
}
