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
            Text = "Sequence";
        }

        public override void Run()
        {
            Status = NodeStatus.Running;
            for(int i = 0; i < Nodes.Count; i++)
            {
                Nodes[i].Run();
                if (Nodes[i].Status == NodeStatus.Running)
                    return;
                else if(Nodes[i].Status == NodeStatus.Failure)
                {
                    Status = NodeStatus.Failure;
                    return;
                }
            }
            Status = NodeStatus.Success;
        }
    }
}
