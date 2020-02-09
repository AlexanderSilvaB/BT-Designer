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
    public class ConditionNode : Node
    {
        public ConditionNode() : base(NodeType.Leaf)
        {
            Icon = Resources.iconfinder_triangle_up_293707;
            Text = "C1 > C2";
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
