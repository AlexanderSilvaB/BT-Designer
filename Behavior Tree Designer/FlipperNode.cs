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
    public class FlipperNode : Node
    {
        bool all = true;
        public FlipperNode() : base(NodeType.Leaf)
        {
            Text = "Flipper\n\nAll";
            Tag = "Flipper";
            Icon = Resources.iconfinder_clock_226587;
            SmallIcon = true;
        }

        public override bool Run(NodeStatus status)
        {
            if (!base.Run(status))
                return false;
            if (all)
            {
                if (Status == NodeStatus.Success)
                    Status = NodeStatus.Running;
                else if (Status == NodeStatus.Running)
                    Status = NodeStatus.Failure;
                else
                    Status = NodeStatus.Success;
            }
            else
            {
                if (Status == NodeStatus.Success)
                    Status = NodeStatus.Failure;
                else
                    Status = NodeStatus.Success;
            }
            PropagateStatus();
            return true;
        }

        public override bool KeyPress(char key)
        {
            string[] lines = Text.Split('\n');
            Text = lines.First();
            bool ret = base.KeyPress(key);
            Text = Text.Split('\n')[0] + "\n\n" + lines.Last();
            return ret;

        }

        public override bool DoubleClick()
        {
            all = !all;
            if (all)
                Text = Text.Split('\n').First() + "\n\nAll";
            else
                Text = Text.Split('\n').First() + "\n\nS&F";
            return true;
        }
    }
}
