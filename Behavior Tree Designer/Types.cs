using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public enum NodeStatus
{
    Success, Failure, Running, Unknown, None
}

public enum NodeType
{
    Composite, Decorator, Leaf
}