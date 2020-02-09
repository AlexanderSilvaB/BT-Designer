using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Behavior_Tree_Designer
{
    [Serializable]
    public class Node
    {
        public int Id { get; private set; }
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
            Status = NodeStatus.Success;
            Nodes = new List<Node>();
            Parent = null;
            if(LinePen == null)
            {
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

        public virtual bool KeyPress(char key)
        {
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
            else if ((char.IsLetterOrDigit(key) || key == ' ' || char.IsPunctuation(key) || char.IsSymbol(key)) && Text.Split('\n').Last().Length < 16)
            {
                Text += key;
                return true;
            }
            return false;
        }

        public virtual void AutoArrange()
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
                Nodes[i].AutoArrange();
            }
        }

        public virtual void Run()
        {
        }

        protected virtual Pen GetPen()
        {
            return LinePen;
        }

        public virtual void Draw(Graphics graphics)
        {
            float x = Width / 2;
            float y = Height / 2;
            graphics.DrawRectangle(GetPen(), X - x, Y - y, Width, Height);
            if(IsFocused)
                graphics.FillRectangle(Brushes.LightGoldenrodYellow, X - x + 1, Y - y + 1, Width - 2, Height - 2);
            else
                graphics.FillRectangle(Brushes.White, X - x + 1, Y - y + 1, Width - 2, Height - 2);
            if (DrawStatus)
            {
                graphics.FillRectangle((Status == NodeStatus.Success) ?
                                        SuccessPen.Brush :
                                        (Status == NodeStatus.Failure ? FailurePen.Brush : RunningPen.Brush),
                                        X - x + 1, Y - y + 1, 10, 10);
            }

            if(Text != null)
            {
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

            float x2, y2;
            for(int i = 0; i < Nodes.Count; i++)
            {
                x2 = Nodes[i].X;
                y2 = Nodes[i].Y - Nodes[i].Height / 2;
                graphics.DrawLine(LinePen, X, Y + y, x2, y2);
            }
        }
    }
}
