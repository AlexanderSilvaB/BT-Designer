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
            Text = "Selector";
        }

        public override void Run()
        {
            Status = NodeStatus.Running;
            for (int i = 0; i < Nodes.Count; i++)
            {
                Nodes[i].Run();
                if (Nodes[i].Status == NodeStatus.Running)
                    return;
                else if (Nodes[i].Status == NodeStatus.Success)
                {
                    Status = NodeStatus.Success;
                    return;
                }
            }
            Status = NodeStatus.Failure;
        }
    }
}
