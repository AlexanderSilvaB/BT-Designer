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
    public class SuccessNode : Node
    {
        public SuccessNode() : base(NodeType.Decorator)
        {
            Icon = Resources.iconfinder_true_check_accept_approve_2075831__1_;
            Tag = "Success";
            SmallIcon = true;
            Text = "Success";
        }

        public override bool Run(NodeStatus status)
        {
            if (!base.Run(status))
            {
                if(Nodes.Count > 0)
                    Nodes[0].Run(status);
                return false;
            }
            Status = NodeStatus.Success;    
            return true;
        }
    }
}
