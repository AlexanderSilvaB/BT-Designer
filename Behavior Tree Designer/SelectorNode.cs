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
    public class SelectorNode : Node
    {
        public SelectorNode() : base(NodeType.Composite)
        {
            Icon = Resources.iconfinder_question_1608802;
            Tag = "Selector";
            Text = "Selector";
        }

        public override bool Run(NodeStatus status)
        {
            Status = NodeStatus.Failure;
            if (status == NodeStatus.None)
                Status = NodeStatus.None;
            NodeStatus forced = status;
            for (int i = 0; i < Nodes.Count; i++)
            {
                Nodes[i].Run(forced);
                if (forced == NodeStatus.Unknown && Nodes[i].Status == NodeStatus.Running)
                {
                    Status = NodeStatus.Running;
                    forced = NodeStatus.None;
                }
                else if (forced == NodeStatus.Unknown && Nodes[i].Status == NodeStatus.Success)
                {
                    Status = NodeStatus.Success;
                    forced = NodeStatus.None;
                }
            }
            return true;
        }
    }
}
