using Our.Umbraco.UFFF.Core.Models;
using System;
using System.Linq;
using System.Net.Http.Formatting;
using umbraco;
using umbraco.BusinessLogic.Actions;
using Umbraco.Core;
using Umbraco.Web.Models.Trees;
using Umbraco.Web.Mvc;
using Umbraco.Web.Trees;
using Umbraco.Web.WebApi.Filters;

namespace Our.Umbraco.UFFF.Web.Config
{
    [UmbracoApplicationAuthorize(Constants.Applications.Content)]
    [Tree("Ufff", "UfffTree", "Events", sortOrder: 12)]
    [PluginController("Ufff")]
    public class UfffTreeController : TreeController
    {
        protected override MenuItemCollection GetMenuForNode(string id, System.Net.Http.Formatting.FormDataCollection queryStrings)
        {
            // create a Menu Item Collection to return so people can interact with the nodes in your tree
            var menu = new MenuItemCollection();

            if (id == Constants.System.Root.ToInvariantString())
            {
                // root actions, perhaps users can create new items in this tree, or perhaps it's not a content tree, it might be a read only tree, or each node item might represent something entirely different...
                // add your menu items here following the pattern of <Umbraco.Web.Models.Trees.ActionMenuItem,umbraco.interfaces.IAction>
                menu.Items.Add<CreateChildEntity, ActionNew>(ui.Text("actions", ActionNew.Instance.Alias));
                // add refresh menu item            
                menu.Items.Add<RefreshNode, ActionRefresh>(ui.Text("actions", ActionRefresh.Instance.Alias), true);
                return menu;
            }
            // add a delete action to each individual item
            menu.Items.Add<ActionDelete>(ui.Text("actions", ActionDelete.Instance.Alias));

            return menu;
        }

        protected override TreeNodeCollection GetTreeNodes(string id, System.Net.Http.Formatting.FormDataCollection queryStrings)
        {
            var connectors = TreeStructure.Connectors;
            var nodes = new TreeNodeCollection();


            // check if we're rendering the root node's children
            if (id == Constants.System.Root.ToInvariantString())
            {

                foreach (var item in connectors)
                {
                    AddConnectorNodes(queryStrings, nodes, item);
                }

            }
            else
            {
                var connector = connectors.FirstOrDefault(con => con.Id.Equals(new Guid(id)));
                if (connector != null && connector.Sections.Any())
                {
                    //it's a connector so we render its sections
                    AddSectionNodes(connector, nodes, queryStrings);
                }
                else
                {
                    ConnectorSection section = null;
                    foreach (var conn in connectors)
                    {
                        section = conn.Sections.FirstOrDefault(sec => sec.Id.Equals(new Guid(id)));
                        if (section != null)
                        {
                            //item's a section so we render its trigger and actions
                            if (section.Triggers.Any())
                            {
                                var trgFolder = CreateTreeNode(Guid.NewGuid().ToString(), section.Id.ToString(), queryStrings, "Triggers");
                                trgFolder.HasChildren = true;

                                AddTriggers(section, nodes, queryStrings, trgFolder);
                            }

                            if (section.Actions.Any())
                            {
                                var actFolder = CreateTreeNode(Guid.NewGuid().ToString(), section.Id.ToString(), queryStrings, "Actions");

                                //TODO: Add actions
                                //AddTriggers(section, nodes, queryStrings);
                            }
                            break;
                        }
                    }

                }


            }
            return nodes;

        }

        private void AddTriggers(ConnectorSection section, TreeNodeCollection nodes, FormDataCollection queryStrings, TreeNode trgFolder)
        {
            foreach (var trigger in section.Triggers)
            {
                var node = CreateTreeNode(trigger.Id.ToString(), trgFolder.Id.ToString(), queryStrings, trigger.Name);
                nodes.Add(node);
            }
        }

        private void AddSectionNodes(Connector connector, TreeNodeCollection nodes, FormDataCollection queryStrings)
        {
            foreach (var section in connector.Sections)
            {
                var node = CreateTreeNode(section.Id.ToString(), connector.Id.ToString(), queryStrings, section.Name);

                if (section.Triggers.Any() || section.Actions.Any())
                {
                    node.HasChildren = true;
                }

                nodes.Add(node);
            }
        }

        private void AddConnectorNodes(System.Net.Http.Formatting.FormDataCollection queryStrings, TreeNodeCollection nodes, Connector item)
        {
            var node = CreateTreeNode(item.Id.ToString(), "-1", queryStrings, item.Name);

            if (item.Sections.Any())
            {
                node.HasChildren = true;
            }
            nodes.Add(node);
        }
    }
}
