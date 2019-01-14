using Our.Umbraco.UFFF.Core.Models.Data;
using System;
using System.Collections.Generic;

namespace Our.Umbraco.Ufff.Core.Interfaces
{
    public interface ITrigger
    {
        /// <summary>
        /// Stores all the <see cref="IAction"/> registered against this trigger
        /// </summary>
        List<IAction> Actions { get; set; }


        Guid Id{ get; }


        /// <summary>
        /// The alias for this action (must be unique)
        /// </summary>
        string Alias { get; }


        /// <summary>
        /// Name to display
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Registers the trigger into Ufff and loads the related actions from the database if any. This has to include the event listener that needs to be executed.
        /// </summary>
        void Register();
    }
}
