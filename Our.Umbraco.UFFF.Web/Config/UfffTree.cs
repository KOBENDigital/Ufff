using Our.Umbraco.Ufff.Core;
using System;
using System.Collections.Generic;
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
            // check if we're rendering the root node's children
            if (id == Constants.System.Root.ToInvariantString())
            {
                var triggers = UfffApplication.TriggerService.GetAvailableTriggers();
                

                var nodes = new TreeNodeCollection();
                foreach (var item in triggers)
                {
                    var node = CreateTreeNode(item.Id.ToString(), "-1", queryStrings, item.Name);
                    nodes.Add(node);
                }

                return nodes;
            }

            // this tree doesn't support rendering more than 1 level
            throw new NotSupportedException();
        }
    }
}
