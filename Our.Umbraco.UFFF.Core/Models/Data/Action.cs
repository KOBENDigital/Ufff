using NPoco;
using Our.Umbraco.Ufff.Core.Interfaces;

namespace Our.Umbraco.UFFF.Core.Models.Data
{
    [TableName(Action.TableName)]
    [PrimaryKey("id", AutoIncrement = true)]
    public class Action
    {
        public const string TableName = Constants.DatabaseSchema.Tables.Actions;

        public int Id { get; set; }
        public string Alias { get; set; }
        public string TriggerAlias { get; set; }
    }
}
