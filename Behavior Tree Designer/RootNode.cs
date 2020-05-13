using Behavior_Tree_Designer.Properties;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Behavior_Tree_Designer
{
    [Serializable]
    public class RootNode : Node
    {
        private Image image;
        public List<Node> AllNodes { get; private set; }
        private Node SelectedNode;
        private bool Dragging;
        private bool Moving;
        private float DragX, DragRealX, DragY, DragRealY;
        public float MoveX { get; private set; }
        public float MoveY { get; private set; }
        public float Zoom { get; private set; }
        private bool CtrlEnabled;
        private bool Referencing;
        private bool running;
        public RootNode() : base(NodeType.Decorator)
        {
            Transform(Height, Height);
            Tag = "BehaviorTree";
            Text = "MainTree";
            image = Resources.iconfinder_block_326541;
            AllNodes = new List<Node>();
            SelectedNode = null;
            Dragging = false;
            Moving = false;
            DragX = DragY = 0;
            DragRealX = DragRealY = 0;
            MoveX = 0;
            MoveY = 0;
            Zoom = 1.0f;
            CtrlEnabled = false;
            Referencing = false;
            running = false;
            if (ButtonIcon == null)
            {
                ButtonIcon = Resources.iconfinder_check_circle_outline_blank_326565;
            }
        }

        public void AddOpen(Node node)
        {
            AllNodes.Add(node);
        }

        public void Detach()
        {
            if (SelectedNode != null && SelectedNode != this)
            {
                SelectedNode.Remove();
                SelectedNode.Release();
            }
        }

        public void Remove(bool onlyCurrent)
        {
            if(SelectedNode != null && SelectedNode != this)
            {
                RemoveFromOpen(SelectedNode, true, onlyCurrent);
                SelectedNode = null;
            }
        }

        private void RemoveFromOpen(Node node, bool inner, bool onlyCurrent)
        {
            if(inner)
                node.Remove();
            if (!onlyCurrent)
            {
                AllNodes.Remove(node);
                for (int i = 0; i < node.Nodes.Count; i++)
                {
                    RemoveFromOpen(node.Nodes[i], false, onlyCurrent);
                }
            }
            else
            {
                for (int i = 0; i < node.Nodes.Count; i++)
                {
                    node.Nodes[i].Release();
                }
                AllNodes.Remove(node);
            }
        }

        public override void Draw(Graphics graphics)
        {
            if (!running)
            {
                for (int i = 0; i < AllNodes.Count; i++)
                {
                    if (AllNodes[i].References != null)
                    {
                        foreach (Node node in AllNodes[i].References)
                        {
                            graphics.DrawLine(Pens.CornflowerBlue, AllNodes[i].X, AllNodes[i].Y, node.X, node.Y);
                        }
                    }
                }
            }

            if (Dragging)
            {
                if(Referencing)
                    graphics.DrawLine(LinePen, SelectedNode.X, SelectedNode.Y, DragX, DragY);
                else
                    graphics.DrawLine(LinePen, SelectedNode.X, SelectedNode.Y + SelectedNode.Height / 2 + 5, DragX, DragY);
            }

            base.Draw(graphics);

            float x = Width / 2;
            float y = Height / 2;
            graphics.DrawImage(image, X - x + 10, Y - y + 10, Width - 20, Height - 20);

            for (int i = 0; i < AllNodes.Count; i++)
                AllNodes[i].Draw(graphics);
        }

        private Node Select(float x, float y)
        {
            Node selected = null;
            for (int i = 0; i < AllNodes.Count; i++)
            {
                if (AllNodes[i].Contains(x, y))
                {
                    selected = AllNodes[i];
                    break;
                }
            }
            return selected;
        }

        private void SelectAndFocus(float x, float y)
        {
            SelectedNode = null;
            IsFocused = false;
            for (int i = 0; i < AllNodes.Count; i++)
            {
                AllNodes[i].IsFocused = false;
            }

            if (Contains(x, y))
                SelectedNode = this;
            else
            {
                for (int i = 0; i < AllNodes.Count; i++)
                {
                    if (AllNodes[i].Contains(x, y))
                    {
                        SelectedNode = AllNodes[i];
                        break;
                    }
                }
            }
            if(SelectedNode != null)
                SelectedNode.IsFocused = true;
        }

        public Node Selected()
        {
            return SelectedNode;
        }

        public void PointerStart(MouseEventArgs e)
        {
            float x = (e.X - MoveX) / Zoom;
            float y = (e.Y - MoveY) / Zoom;
            if (SelectedNode != null && SelectedNode.ClickOnAdd(x, y))
            {
                Dragging = true;
                DragX = x;
                DragY = y;
                DragRealX = e.X;
                DragRealY = e.Y;
            }
            else if(SelectedNode != null && SelectedNode.Type == NodeType.Leaf && CtrlEnabled)
            {
                Dragging = true;
                Referencing = true;
                DragX = x;
                DragY = y;
                DragRealX = e.X;
                DragRealY = e.Y;
            }
            else
            {
                SelectAndFocus(x, y);
                Moving = true;
                DragX = x;
                DragY = y;
                DragRealX = e.X;
                DragRealY = e.Y;
            }
        }

        public void PointerEnd(MouseEventArgs e)
        {
            float x = (e.X - MoveX) / Zoom;
            float y = (e.Y - MoveY) / Zoom;
            Dragging = false;
            Moving = false;
            CtrlEnabled = false;
            if (SelectedNode != null)
            {
                Node selected = Select(x, y);
                if (selected != null && selected != SelectedNode)
                {
                    if (Referencing)
                    {
                        //if (selected.GetType() == SelectedNode.GetType() )
                        //{
                            SelectedNode.AddReference(selected);
                            selected.AddReference(SelectedNode);
                        //}
                    }
                    else
                    {
                        if (SelectedNode.CanAdd())
                            SelectedNode.Add(selected);
                    }
                }
            }
            Referencing = false;
        }

        public bool PointerMove(MouseEventArgs e, int gridSize, bool align)
        {
            float x = (e.X - MoveX) / Zoom;
            float y = (e.Y - MoveY) / Zoom;
            if (Moving)
            {
                if (SelectedNode != null)
                {
                    SelectedNode.Translate(x - DragX, y - DragY, align, gridSize);
                }
                else
                {
                    //MoveX += e.X - DragRealX;
                    //MoveY += e.Y - DragRealY;
                }
            }
            DragX = x;
            DragY = y;
            DragRealX = e.X;
            DragRealY = e.Y;
            return Dragging || Moving;
        }

        public void Wheel(MouseEventArgs e)
        {
            if (Zoom == 0)
                Zoom = 1.0f;
            Zoom += (e.Delta / (float)SystemInformation.MouseWheelScrollDelta) / 100.0f;
            if (Zoom < 0.3f)
                Zoom = 0.3f;
            else if (Zoom > 2.0f)
                Zoom = 3.0f;
        }

        public override bool DoubleClick()
        {
            Node selected = Select(DragX, DragY);
            if(selected != null)
            {
                return selected.DoubleClick();
            }
            return false;
        }

        public override bool KeyPress(char key)
        {
            if(SelectedNode != null && SelectedNode != this)
            {
                return SelectedNode.KeyPress(key);
            }
            return false;
        }

        public override void ClearReferences()
        {
            if (SelectedNode != null && SelectedNode != this)
            {
                SelectedNode.ClearReferences();
            }
        }

        public void Ctrl(bool ctrl)
        {
            CtrlEnabled = ctrl;
        }

        public void Running(bool running)
        {
            this.running = running;
        }

        public void Run()
        {
            if(Nodes.Count > 0)
            {
                Nodes[0].Run();
                Status = Nodes[0].Status;
            }
        }
    }
}
