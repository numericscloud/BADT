using System;
using System.Windows.Forms;

namespace BizTalkDeploymentTool
{
    public static class PropertyGridExtensions
    {
        public static void ExpandGroup(this PropertyGrid propertyGrid, string groupName)
        {
            GridItem root = propertyGrid.SelectedGridItem;
            //Get the parent
           /* while (root.Parent != null)
                root = root.Parent;*/

            if (root != null && root.Parent!=null)
            {
                foreach (GridItem g in root.Parent.GridItems)
                {
                    if (g.GridItemType == GridItemType.Property && g.Label == groupName)
                    {
                        g.Expanded = true;
                        break;
                    }
                }
            }
        }
    }
}
