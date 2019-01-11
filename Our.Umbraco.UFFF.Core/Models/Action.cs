using Our.Umbraco.Ufff.Core.Interfaces;

namespace Our.Umbraco.UFFF.Core.Models
{

    public class Action : IAction
    {
        public string Alias { get; set; }
        public string TriggerAlias { get; set; }

        public void Run()
        {
            throw new System.NotImplementedException();
        }
    }
}
