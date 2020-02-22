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
    public class FailureNode : Node
    {
        public FailureNode() : base(NodeType.Decorator)
        {
            Icon = Resources.iconfinder_false_cross_reject_decline_2075833;
            Tag = "Failure";
            SmallIcon = true;
            Text = "Failure";
        }

        public override bool Run(NodeStatus status)
        {
            if (!base.Run(status))
            {
                if(Nodes.Count > 0)
                    Nodes[0].Run(status);
                return false;
            }
            Status = NodeStatus.Failure;    
            return true;
        }
    }
}
