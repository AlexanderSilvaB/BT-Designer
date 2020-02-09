using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavior_Tree_Designer
{
    public enum NodeStatus
    {
        Success, Failure, Running
    }

    public enum NodeType
    {
        Composite, Decorator, Leaf
    }
}
