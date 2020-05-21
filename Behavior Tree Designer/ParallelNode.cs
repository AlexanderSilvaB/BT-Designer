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
    public class ParallelNode : Node
    {
        public ParallelNode() : base(NodeType.Composite)
        {
            Icon = Resources.iconfinder_arrow_7_393270;
            Tag = "Parallel";
            Text = "Parallel";
        }

        public override bool Run(NodeStatus status)
        {
            Status = NodeStatus.Success;
            if (status == NodeStatus.None)
                Status = NodeStatus.None;
            NodeStatus forced = status;
            NodeStatus[] all = new NodeStatus[Nodes.Count];
            for (int i = 0; i < Nodes.Count; i++)
            {
                Nodes[i].Run(forced);
                all[i] = Nodes[i].Status;
                if (forced == NodeStatus.Unknown && Nodes[i].Status == NodeStatus.Running)
                {
                    Status = NodeStatus.Running;
                }
                else if (forced == NodeStatus.Unknown && Nodes[i].Status == NodeStatus.Failure)
                {
                    Status = NodeStatus.Failure;
                }
            }
            return true;
        }
    }
}
