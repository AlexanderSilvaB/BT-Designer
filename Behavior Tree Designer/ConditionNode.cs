﻿using Behavior_Tree_Designer.Properties;
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
            Tag = "Condition";
            Text = "C1 > C2";
            IsEllipse = true;
        }

        public override bool DoubleClick()
        {
            if (Status == NodeStatus.Success)
                Status = NodeStatus.Failure;
            else
                Status = NodeStatus.Success;
            PropagateStatus();
            return true;
        }
    }
}
