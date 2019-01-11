using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Persistence;
using Umbraco.Core.Scoping;
using Umbraco.Web;
using NPoco;
using Umbraco.Core.Composing;

namespace Our.Umbraco.UFFF.Core.Services
{
    class DataService
    {
        private readonly IUmbracoDatabase _db;

        public DataService(IScopeAccessor scopeAccessor)
        {
            _db = scopeAccessor.AmbientScope.Database;
        }


        public void CreateTables()
        {
            _db.BeginTransaction();
           

        }


        public void SaveLogic()
        {

        }
    }
}
