using Behavior_Tree_Designer.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavior_Tree_Designer
{
    [Serializable]
    public class ActionNode : Node
    {
        public ActionNode() : base(NodeType.Leaf)
        {
            Text = "Action name";
            Tag = "Action";
        }

        public override bool DoubleClick()
        {
            if (Status == NodeStatus.Success)
                Status = NodeStatus.Running;
            else if (Status == NodeStatus.Running)
                Status = NodeStatus.Failure;
            else
                Status = NodeStatus.Success;
            return true;
        }
    }
}
