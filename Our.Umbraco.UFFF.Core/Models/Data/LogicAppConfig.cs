using NPoco;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Our.Umbraco.UFFF.Core.Models.Data
{
    [TableName(TableName)]
    [PrimaryKey("id", AutoIncrement = true)]
    internal class LogicAppConfig
    {
        public const string TableName = Constants.DatabaseSchema.Tables.LogicApp;

        public int Id { get; set; }

        public string Trigger { get; set; }

        public string Action { get; set; }
    }
}
