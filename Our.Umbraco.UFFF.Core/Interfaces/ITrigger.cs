using Our.Umbraco.UFFF.Core.Models.Data;
using System.Collections.Generic;

namespace Our.Umbraco.Ufff.Core.Interfaces
{
    public interface ITrigger
    {
        /// <summary>
        /// Stores all the <see cref="IAction"/> registered against this trigger
        /// </summary>
        IList<Action> Actions { get; set; }

        /// <summary>
        /// The alias for this action (must be unique)
        /// </summary>
        string Alias { get; }

        /// <summary>
        /// Registers the trigger into Ufff and loads the related actions from the database if any
        /// </summary>
        void Register();
    }
}
