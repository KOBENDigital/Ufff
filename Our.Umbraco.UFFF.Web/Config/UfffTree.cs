using System;
using Umbraco.Core;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Mvc;
using Umbraco.Web.Trees;
using Umbraco.Web.WebApi.Filters;

namespace Our.Umbraco.UFFF.Web.Config
{
    [UmbracoApplicationAuthorize(Constants.Applications.Content)]
    [Tree(Constants.Applications.Settings, Constants.Trees.ContentBlueprints, null, sortOrder: 12)]
    [PluginController("UfffTree")]
    public class UfffTree : TreeController
    {
        protected override MenuItemCollection GetMenuForNode(string id, System.Net.Http.Formatting.FormDataCollection queryStrings)
        {
            throw new NotImplementedException();
        }

        protected override TreeNodeCollection GetTreeNodes(string id, System.Net.Http.Formatting.FormDataCollection queryStrings)
        {
            //Load all created triggers as subnodes of a main node with the Connector name

            throw new NotImplementedException();
        }
    }
}
