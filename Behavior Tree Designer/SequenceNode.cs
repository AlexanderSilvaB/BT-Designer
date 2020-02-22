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
    public class SequenceNode : Node
    {
        public SequenceNode() : base(NodeType.Composite)
        {
            Icon = Resources.iconfinder_arrow_right_227601;
            Tag = "Sequence";
            Text = "Sequence";
        }

        public override bool Run(NodeStatus status)
        {
            Status = NodeStatus.Success;
            if (status == NodeStatus.None)
                Status = NodeStatus.None;
            NodeStatus forced = status;
            for(int i = 0; i < Nodes.Count; i++)
            {
                Nodes[i].Run(forced);
                if (forced == NodeStatus.Unknown && Nodes[i].Status == NodeStatus.Running)
                {
                    Status = NodeStatus.Running;
                    forced = NodeStatus.None;
                }
                else if (forced == NodeStatus.Unknown && Nodes[i].Status == NodeStatus.Failure)
                {
                    Status = NodeStatus.Failure;
                    forced = NodeStatus.None;
                }
            }
            return true;
        }
    }
}
