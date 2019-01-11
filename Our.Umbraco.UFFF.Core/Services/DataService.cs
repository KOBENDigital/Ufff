using Our.Umbraco.Ufff.Core.Interfaces;
using Our.Umbraco.UFFF.Core.Models.Data;
using System.Collections.Generic;
using Umbraco.Core;
using Umbraco.Core.Persistence;
using UfffData = Our.Umbraco.UFFF.Core.Models.Data;

namespace Our.Umbraco.UFFF.Core.Services
{
    public class DataService
    {
        private readonly DatabaseContext _ctx;

        public DataService()
        {
            _ctx = ApplicationContext.Current.DatabaseContext;
        }

        public void CreateTables()
        {
            DatabaseSchemaHelper schemaHelper = new DatabaseSchemaHelper(_ctx.Database, ApplicationContext.Current.ProfilingLogger.Logger, _ctx.SqlSyntax);

            _ctx.Database.BeginTransaction();

            if (!schemaHelper.TableExist(UfffData.Constants.DatabaseSchema.Tables.Actions)) schemaHelper.CreateTable<Action>();

            _ctx.Database.CompleteTransaction();
        }


        public void SaveAction(Action action)
        {
            _ctx.Database.Save(action);
        }

        public void DeleteAction(Action action)
        {
            _ctx.Database.Delete(action);
        }

        /// <summary>
        /// Returns the actions subscribed to certain trigger.
        /// </summary>
        /// <param name="trigger"></param>
        /// <returns></returns>
        public IEnumerable<Action> GetActions(ITrigger trigger)
        {
            return _ctx.Database.Query<Action>($"select * from {UfffData.Constants.DatabaseSchema.Tables.Actions} where TriggerAlias = '{trigger.Alias}'");
        }

    }
}
