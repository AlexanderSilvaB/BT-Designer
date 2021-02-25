using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public interface INode
{
    NodeType Type { get; }
    Image Icon { get; }
    string Text { get; }
    string Tag { get; }
    NodeStatus Status { get; }

    bool Run(NodeStatus status);
    bool DoubleClick();
}
