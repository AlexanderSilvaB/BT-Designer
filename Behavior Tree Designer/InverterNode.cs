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
    public class InverterNode : Node
    {
        public InverterNode() : base(NodeType.Decorator)
        {
            Icon = Resources.iconfinder_UnitedArrowUpDown_1031499__1_;
            SmallIcon = true;
            Text = "Inverter";
        }

        public override void Run()
        {
            if (Nodes.Count == 0)
                Status = NodeStatus.Success;
            else
            {
                Nodes[0].Run();
                if (Nodes[0].Status == NodeStatus.Success)
                    Status = NodeStatus.Failure;
                else if (Nodes[0].Status == NodeStatus.Failure)
                    Status = NodeStatus.Success;
                else
                    Status = NodeStatus.Running;
            }
        }
    }
}
