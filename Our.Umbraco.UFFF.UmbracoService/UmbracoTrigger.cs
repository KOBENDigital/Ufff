using Our.Umbraco.Ufff.Core.Attributes;
using Our.Umbraco.UFFF.Core.Models;
using System;
using Umbraco.Core.Events;
using Umbraco.Core.Models;
using Umbraco.Core.Publishing;
using Umbraco.Core.Services;

namespace Our.Umbraco.Ufff.Core.Triggers
{
    [Connector("umbraco", "Umbraco", "content", "Content")]
    public class SaveNodeTrigger : TriggerBase
    {

        public override Guid Id => new Guid("8c8504e0-9505-4dcd-8761-2d4bdf9d782d");

        public override string Alias => "saveNode";

        public override string Name => "Save Node";


        /// <summary>
        /// It adapts a services event to a UFFF trigger
        /// </summary>
        public override void Register()
        {
            ContentService.Published += ContentService_Published;
        }


        private void ContentService_Published(IPublishingStrategy sender, PublishEventArgs<IContent> e)
        {
            this.Actions.ForEach(a => a.Run());
        }
    }
}
