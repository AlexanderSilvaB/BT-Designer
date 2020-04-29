using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Behavior_Tree_Designer
{
    [Serializable]
    public class Node
    {
        public int Id { get; private set; }
        public static Image ButtonIcon { get; set; }
        public static bool DrawStatus { get; set; }
        protected static Pen LinePen { get; private set; }
        protected static Pen SuccessPen { get; private set; }
        protected static Pen FailurePen { get; private set; }
        protected static Pen RunningPen { get; private set; }
        public bool IsFocused { get; set; }
        public NodeType Type { get; private set; }
        protected float TempX { get; set; }
        protected float TempY { get; set; }
        public float X { get; private set; }
        public float Y { get; private set; }
        public float Width { get; private set; }
        public float Height { get; private set; }
        public string Text { get; protected set; }
        public Image Icon { get; protected set; }
        public bool SmallIcon { get; protected set; }
        public List<Node> Nodes { get; private set; }
        public Node Parent { get; private set; }
        public NodeStatus Status { get; protected set; }
        private NodeStatus LastStatus;
        protected int Level { get; set; }
        protected string Tag { get; set; }
        protected Dictionary<string, object> Attributes;
        public static Dictionary<string, Type> Factory;

        protected bool IsEllipse { get; set; }
        public List<Node> References { get; private set; }
        private double PropagateHash;

        public Node(NodeType type)
        {
            Id = GetHashCode();
            Type = type;
            X = 100;
            Y = 100;
            TempX = X;
            TempY = Y;
            Width = 100;
            Height = 60;
            Text = null;
            Icon = null;
            SmallIcon = false;
            Attributes = new Dictionary<string, object>();
            Status = NodeStatus.Success;
            LastStatus = Status;
            Nodes = new List<Node>();
            Parent = null;
            Tag = "Node";
            IsEllipse = false;
            References = new List<Node>();
            PropagateHash = 0;
            if (LinePen == null)
            {
                Init();
            }
        }

        public static void Init()
        {
            Factory = new Dictionary<string, Type>();
            ButtonIcon = null;
            DrawStatus = false;
            LinePen = Pens.Black;

            SuccessPen = new Pen(Color.Blue);
            SuccessPen.DashStyle = DashStyle.Solid;
            SuccessPen.Brush = Brushes.Blue;

            FailurePen = new Pen(Color.Red);
            FailurePen.DashStyle = DashStyle.Solid;
            FailurePen.Brush = Brushes.Red;

            RunningPen = new Pen(Color.Green);
            RunningPen.DashStyle = DashStyle.Solid;
            RunningPen.Brush = Brushes.Green;
        }

        public static void Register(string tag, Type type)
        {
            Factory[tag] = type;
        }

        public void Move(float x, float y, bool align, int size)
        {
            TempX = x;
            TempY = y;
            if (align)
            {
                X = ((float)Math.Round(TempX / size)) * size;
                Y = ((float)Math.Round(TempY / size)) * size;
            }
            else
            {
                X = TempX;
                Y = TempY;
            }
        }

        public void Translate(float x, float y, bool align, int size)
        {
            TempX += x;
            TempY += y;

            if (align)
            {
                X = ((float)Math.Round(TempX / size)) * size;
                Y = ((float)Math.Round(TempY / size)) * size;
            }
            else
            {
                X = TempX;
                Y = TempY;
            }
            for (int i = 0; i < Nodes.Count; i++)
                Nodes[i].Translate(x, y, align, size);
        }

        public void Transform(float w, float h)
        {
            Width = w;
            Height = h;
        }

        public void Release()
        {
            Parent = null;
        }

        public void Add(Node node)
        {
            if (node.Parent != null)
                return;
            if (CanAdd())
            {
                node.Parent = this;
                Nodes.Add(node);
            }
        }

        public bool CanAdd()
        {
            if (Type == NodeType.Composite)
                return true;
            else if (Type == NodeType.Decorator && Nodes.Count == 0)
                return true;
            return false;
        }

        public void Remove()
        {
            if(Parent != null)
            {
                Parent.Nodes.Remove(this);
            }
        }

        public bool Contains(float px, float py)
        {
            float x = Width / 2;
            float y = Height / 2;
            if (px >= X - x && px <= X + x && py >= Y - y && py <= Y + y)
                return true;
            return false;
        }

        public bool ClickOnAdd(float px, float py)
        {
            if (!CanAdd())
                return false;
            float y = Height / 2;
            if (px >= X - 5 && px <= X + 5 && py >= Y + y && py <= Y + y + 10)
                return true;
            return false;
        }

        public virtual bool DoubleClick()
        {
            return false;
        }

        public void AddReference(Node node)
        {
            if (References == null)
                References = new List<Node>();
            if(!References.Contains(node))
                References.Add(node);
        }

        public void RemoveReference(Node node)
        {
            if (References == null)
                References = new List<Node>();
            References.Remove(node);
        }

        public virtual void ClearReferences()
        {
            if (References == null)
                References = new List<Node>();
            foreach (Node node in References)
            {
                node.RemoveReference(this);
            }
            References.Clear();
        }

        protected void PropagateStatus(double hash = 0)
        {
            if (References == null)
                References = new List<Node>();
            if (hash == 0)
                hash = new Random().NextDouble();
            if (hash == PropagateHash)
                return;
            PropagateHash = hash;
            foreach (Node node in References)
            {
                node.Status = Status;
                node.PropagateStatus(PropagateHash);
            }

        }

        public virtual bool KeyPress(char key)
        {
            int L = 17;
            if (IsEllipse)
                L = 10;
            if (Text == null)
                Text = "";
            if (key == '\b')
            {
                if (Text.Length > 0)
                {
                    Text = Text.Substring(0, Text.Length - 1);
                    return true;
                }
            }
            else if (key == '\r' && Icon == null && Text.Count((c) => { return c == '\n'; }) < 2)
            {
                Text += '\n';
                return true;
            }
            else if ((char.IsLetterOrDigit(key) || key == ' ' || char.IsPunctuation(key) || char.IsSymbol(key)) && Text.Split('\n').Last().Length < L)
            {
                Text += key;
                return true;
            }
            return false;
        }

        protected void Measure(int level, Dictionary<int, float> widths)
        {
            Level = level;
            if (widths.ContainsKey(level))
                widths[level] += Width + 20;
            else
                widths[level] = Width + 20;
            foreach(Node node in Nodes)
            {
                node.Measure(level + 1, widths);
            }
        }

        public virtual void AutoArrange()
        {
            NodesDistribute();
            NodesCollisionsCheck();
        }

        public void NodesDistribute()
        {
            if (Nodes.Count == 0)
                return;

            float W = Nodes.Sum((n) => { return n.Width; });
            W += 20 * (Nodes.Count - 1);

            float H = Nodes.Max((n) => { return n.Height; });

            float SW = X - W / 2;
            float SH = Y + Height / 2 + 20 + H / 2;

            for (int i = 0; i < Nodes.Count; i++)
            {
                SW += Nodes[i].Width / 2;
                Nodes[i].Move(SW, SH, false, 0);
                SW += Nodes[i].Width / 2 + 20;
                Nodes[i].NodesDistribute();
            }
        }

        public void NodesCollisionsCheck()
        {
            RectangleF rect = GetRect(10, 20);
            System.Diagnostics.Debug.WriteLine(rect);
        }

        private RectangleF GetRect(float margin, int distance)
        {
            if(Nodes.Count == 0)
                return new RectangleF(X - margin, Y - margin, Width + margin * 2, Height + margin * 2);
            else
            {
                List<RectangleF> rects = new List<RectangleF>();
                for(int i = 0; i < Nodes.Count; i++)
                {
                    rects.Add(Nodes[i].GetRect(margin, distance));
                }

                int mean;
                int m, M, x;
                while(Intersects(rects))
                {
                    mean = Nodes.Count / 2;
                    if (Nodes.Count % 2 == 0)
                    {
                        m = mean;
                        M = mean - 1;
                    }
                    else
                    {
                        m = mean;
                        M = mean;
                    }
                    for (int i = 0; i < Nodes.Count; i++)
                    {
                        if (i < m)
                            x = -(m - i);
                        else if (i > M)
                            x = i - M;
                        else
                            x = 0;
                        x *= distance;
                        Nodes[i].Translate(x, 0, false, distance);
                    }

                    for (int i = 0; i < Nodes.Count; i++)
                    {
                        rects[i] = Nodes[i].GetRect(margin, distance);
                    }
                }

                RectangleF rect = rects[0];
                for (int i = 1; i < Nodes.Count; i++)
                {
                    rect = RectangleF.Union(rect, rects[i]);
                }
                return rect;
            }
        }

        private bool Intersects(List<RectangleF> rects)
        {
            for(int i = 0; i < rects.Count; i++)
            {
                for (int j = 0; j < rects.Count; j++)
                {
                    if(i != j)
                    {
                        if (rects[i].IntersectsWith(rects[j]))
                            return true;
                    }
                }                    
            }
            return false;
        }

        public virtual bool Run(NodeStatus status = NodeStatus.Unknown)
        {
            if (status != NodeStatus.Unknown)
            {
                Status = status;
                return false;
            }

            if (Status == NodeStatus.None && status == NodeStatus.Unknown)
            {
                Status = NodeStatus.Success;
            }

            
            return true;
        }

        protected virtual Pen GetPen()
        {
            return LinePen;
        }

        public virtual void Draw(Graphics graphics)
        {
            float x = Width / 2;
            float y = Height / 2;

            if (IsEllipse)
            {
                graphics.DrawEllipse(GetPen(), X - x, Y - y, Width, Height);
                if (IsFocused)
                    graphics.FillEllipse(Brushes.LightGoldenrodYellow, X - x + 1, Y - y + 1, Width - 2, Height - 2);
                else
                    graphics.FillEllipse(Brushes.White, X - x + 1, Y - y + 1, Width - 2, Height - 2);
            }
            else
            {
                graphics.DrawRectangle(GetPen(), X - x, Y - y, Width, Height);
                if (IsFocused)
                    graphics.FillRectangle(Brushes.LightGoldenrodYellow, X - x + 1, Y - y + 1, Width - 2, Height - 2);
                else
                    graphics.FillRectangle(Brushes.White, X - x + 1, Y - y + 1, Width - 2, Height - 2);
            }
            if (DrawStatus)
            {
                if (Status == NodeStatus.Success || Status == NodeStatus.Running || Status == NodeStatus.Failure)
                {
                    if (IsEllipse)
                    {
                        graphics.FillRectangle((Status == NodeStatus.Success) ?
                                                SuccessPen.Brush :
                                                (Status == NodeStatus.Failure ? FailurePen.Brush : RunningPen.Brush),
                                                X - 5, Y - y + 3, 10, 10);
                    }
                    else
                    {
                        graphics.FillRectangle((Status == NodeStatus.Success) ?
                                                SuccessPen.Brush :
                                                (Status == NodeStatus.Failure ? FailurePen.Brush : RunningPen.Brush),
                                                X - x + 1, Y - y + 1, 10, 10);
                    }
                }
            }

            if(!(this is RootNode) && Text != null)
            {
                if(IsEllipse)
                    graphics.DrawString(Text, SystemFonts.MessageBoxFont, Brushes.Black, new RectangleF(X - x + 8, Y - y + 8, Width - 16, Height - 16), new StringFormat() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                else
                    graphics.DrawString(Text, SystemFonts.MessageBoxFont, Brushes.Black, X, Y - y + 8, new StringFormat() { Alignment = StringAlignment.Center });
            }
            if (Icon != null)
            {
                if(SmallIcon)
                    graphics.DrawImage(Icon, X - 6, Y - 6, 12, 12);
                else
                    graphics.DrawImage(Icon, X - 10, Y - 10, 20, 20);
            }
            if(IsFocused && CanAdd())
            {
                graphics.FillEllipse(LinePen.Brush, X - 5, Y + y, 10, 10);
            }

            if(Type == NodeType.Leaf && !IsEllipse)
            {
                graphics.DrawImage(ButtonIcon, X + x - 20, Y + y - 20, 16, 16);
            }

            float x2, y2;
            for(int i = 0; i < Nodes.Count; i++)
            {
                x2 = Nodes[i].X;
                y2 = Nodes[i].Y - Nodes[i].Height / 2;
                if(DrawStatus && Nodes[i].Status == NodeStatus.Success)
                    graphics.DrawLine(SuccessPen, X, Y + y, x2, y2);
                else if(DrawStatus && Nodes[i].Status == NodeStatus.Running)
                    graphics.DrawLine(RunningPen, X, Y + y, x2, y2);
                else if(DrawStatus && Nodes[i].Status == NodeStatus.Failure)
                    graphics.DrawLine(FailurePen, X, Y + y, x2, y2);
                else
                    graphics.DrawLine(LinePen, X, Y + y, x2, y2);
            }
        }

        public string Export()
        {
            XElement bt = Encode(this);
            XElement root = new XElement("root", bt);
            root.SetAttributeValue("main_tree_to_execute", "MainTree");
            return root.ToString();
        }

        private string EncodeID()
        {
            if (Text == null)
                return Id.ToString();
            else
            {
                TextInfo txtInfo = new CultureInfo("en-us", false).TextInfo;
                string ID = txtInfo.ToTitleCase(Text).Replace("_", String.Empty).Replace(" ", String.Empty).Replace("\n", String.Empty).
                    Replace(">", "_g_").Replace("<", "_l_").Replace("=", "_e_").Replace(".", "_d_").Replace("&", "_and_");
                return ID;
            }
        }

        private string EncodeName()
        {
            if (Text == null)
                return null;
            TextInfo txtInfo = new CultureInfo("en-us", false).TextInfo;
            return txtInfo.ToLower(Text).Replace("\n", "_b_").Replace(".", "_d_").Replace("&", "_and_").Replace(" ", "_");
        }

        public static Node Import(string xml)
        {
            try
            {
                XElement root = XElement.Parse(xml);
                if(root.Name.LocalName == "root")
                
                return Decode((XElement)root.Nodes().FirstOrDefault(), null);
            }
            catch(Exception ex)
            {
            }
            return null;
        }

        private static XElement Encode(Node node)
        {
            if (node.Tag == null)
            {
                node.Tag = Factory.FirstOrDefault(x => x.Value == node.GetType()).Key;
                if (node.Tag == null)
                    node.Tag = "Node";
            }

            XElement root = new XElement(node.Tag);
            root.SetAttributeValue("ID", node.EncodeID());
            string name = node.EncodeName();
            if (node != null)
                root.SetAttributeValue("name", name);
            if (node.Attributes != null)
            {
                foreach (string key in node.Attributes.Keys)
                {
                    root.SetAttributeValue(key, node.Attributes[key]);
                }
            }
            foreach(Node n in node.Nodes)
            {
                root.Add(Encode(n));
            }
            return root;
        }

        private static Node Decode(XElement root, Node rootNode)
        {
            string tag = root.Name.LocalName;

            Type type = Factory[tag];
            Node node = (Node)Activator.CreateInstance(type);
            XAttribute name = root.Attribute("name");
            if(name == null)
            {
                name = root.Attribute("ID");
            }

            if (rootNode == null)
                rootNode = node;

            root.SetAttributeValue("name", null);
            root.SetAttributeValue("ID", null);

            if (name != null)
            {
                string value = name.Value;
                TextInfo txtInfo = new CultureInfo("en-us", false).TextInfo;
                string Text = txtInfo.ToTitleCase(value.Replace("_b_", "\n").Replace("_d_", ".").Replace("_and_", "&").Replace("_", " ").
                    Replace("_g_", ">").Replace("_l_", "<").Replace("_e_", "="));
                node.Text = Text;
            }

            var attrs = root.Attributes();
            foreach (var attr in attrs)
            {
                node.Attributes[attr.Name.LocalName] = attr.Value;
            }

            foreach(var child in root.Elements())
            {
                Node nchild = Decode(child, rootNode);
                node.Add(nchild);
            }

            if(rootNode != null && rootNode != node)
            {
                if(rootNode is RootNode)
                    (rootNode as RootNode).AddOpen(node);
            }

            return node;
        }

        protected bool GenerateTex(ref string nodes)
        {
            string text;
            if (Text != null)
                text = Text.Replace("\n", " ");
            else
                text = "Root";
            if (Icon != null)
            {
                if (this is ConditionNode)
                {
                    text += @"";
                }
                else if (this is SuccessNode)
                {
                    text += @"\\$\checkmark$";
                }
                else if (this is FailureNode)
                {
                    text += @"\\$\times$";
                }
                else if (this is FlipperNode)
                {
                    text += @"\\$\pm$";
                }
                else if (this is InverterNode)
                {
                    text += @"\\$\leftrightarrow$";
                }
                else if (this is SelectorNode)
                {
                    text += @"\\$?$";
                }
                else if (this is SequenceNode)
                {
                    text += @"\\$\rightarrow$";
                }
                else
                {
                    text += @"\\$\Box$";
                }
            }
            else
                text += @"\\";
            if(IsEllipse)
                nodes += "[.\node [ellipse]("+Id+"){" + text + "};";
            else
                nodes += "[.{" + text + "}";
            if (Nodes.Count > 0)
                nodes += "\n";
            foreach (Node node in Nodes)
            {
                if (!node.GenerateTex(ref nodes))
                    return false;
            }

            nodes += " ]\n";
            return true;
        }

        public string GenerateTex()
        {
            string nodes = "";
            if(!GenerateTex(ref nodes))
            {
                return null;
            }

            string tex = @"% preamble
\usepackage{tikz-qtree}
\usetikzlibrary{ trees}
\usepackage{amssymb}


% document
\tikzset{font=\small,
level distance = 1.5cm,
sibling distance=4mm,
every node/.style =
    {
                top color = white,
               bottom color = white,
    shape=rectangle, rounded corners,
    minimum height = 10mm,
    draw = black!50,
    align = center,
    text depth = 0pt
    },
edge from parent /.style =
    {
                draw = blue!50
    }}

\centering
\begin{tikzpicture}[scale=1.0]
\Tree " + nodes + "\\end{tikzpicture}";

            return tex;
        }
    }
}
