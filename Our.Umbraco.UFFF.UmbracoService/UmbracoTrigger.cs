using Our.Umbraco.Ufff.Core.Attributes;
using Our.Umbraco.Ufff.Core.Interfaces;
using Our.Umbraco.UFFF.Core.Models;
using System.Collections.Generic;
using Umbraco.Core.Services.Implement;

namespace Our.Umbraco.Ufff.Core.Triggers
{
    [Connector("Umbraco", "Content")]
    public class SaveNodeTrigger : TriggerBase
    {
        public override string Alias => "savedNode";


        /// <summary>
        /// It adapts a services event to a UFFF trigger
        /// </summary>
        public override void Register()
        {
            ContentService.Published += ContentService_Published;
        }

        private void ContentService_Published(global::Umbraco.Core.Services.IContentService sender, global::Umbraco.Core.Events.PublishEventArgs<global::Umbraco.Core.Models.IContent> e)
        {
            this.Actions.ForEach(a => a.Run());
        }
    }
}
