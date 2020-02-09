using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Behavior_Tree_Designer
{
    public partial class Form1 : Form
    {
        private Timer timer;
        RootNode root;
        string fileName;
        bool saved;
        string titleBase;
        bool drawGrid;
        int gridSize;
        bool alignGrid;
        bool antiAlias;
        public Form1()
        {
            InitializeComponent();

            titleBase = Text;

            root = null;

            fileName = null;
            saved = true;
            drawGrid = true;
            gridSize = 10;
            alignGrid = true;
            antiAlias = false;

            diagramPanel.MouseWheel += DiagramPanel_MouseWheel;

            timer = new Timer();
            timer.Interval = 1000;
            timer.Tick += Timer_Tick;
            if(Node.DrawStatus)
                timer.Start();
        }

        private void DiagramPanel_MouseWheel(object sender, MouseEventArgs e)
        {
            if (root != null)
                root.Wheel(e);
            diagramPanel.Invalidate();
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            root.Run();
            diagramPanel.Invalidate();
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void diagramPanel_Paint(object sender, PaintEventArgs e)
        {
            if(root == null)
            {
                root = new RootNode();
                root.Move(e.ClipRectangle.Width / 2, root.Height, alignGrid, gridSize);
            }

            string title;
            if (fileName != null)
                title = fileName;
            else
                title = "Untitled.bt";
            if (!saved)
                title = "*" + title;

            Text = titleBase + " - " + title;

            if (antiAlias)
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            else
                e.Graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
            
            if(root.Zoom > 0)
                e.Graphics.ScaleTransform(root.Zoom, root.Zoom);
            e.Graphics.TranslateTransform(root.MoveX, root.MoveY);

            e.Graphics.Clear(Color.White);
            if(drawGrid)
            {
                DrawGrid(e.Graphics);
            }
            root.Draw(e.Graphics);
        }

        private void btnSelector_Click(object sender, EventArgs e)
        {
            root.AddOpen(new SelectorNode());
            diagramPanel.Invalidate();
            saved = false;
        }

        private void btnSequence_Click(object sender, EventArgs e)
        {
            root.AddOpen(new SequenceNode());
            diagramPanel.Invalidate();
            saved = false;
        }

        private void btnCondition_Click(object sender, EventArgs e)
        {
            root.AddOpen(new ConditionNode());
            diagramPanel.Invalidate();
            saved = false;
        }

        private void btnAction_Click(object sender, EventArgs e)
        {
            root.AddOpen(new ActionNode());
            diagramPanel.Invalidate();
            saved = false;
        }
        private void Inverter_Click(object sender, EventArgs e)
        {
            root.AddOpen(new InverterNode());
            diagramPanel.Invalidate();
            saved = false;
        }

        private void btnFlipper_Click(object sender, EventArgs e)
        {
            root.AddOpen(new FlipperNode());
            diagramPanel.Invalidate();
            saved = false;
        }

        private void diagramPanel_MouseDown(object sender, MouseEventArgs e)
        {
            if (root != null)
            {
                root.PointerStart(e);
                diagramPanel.Invalidate();
                saved = false;
            }
        }

        private void diagramPanel_MouseMove(object sender, MouseEventArgs e)
        {
            if (root != null)
                if (root.PointerMove(e, gridSize, alignGrid))
                {
                    diagramPanel.Invalidate();
                    saved = false;
                }
        }

        private void diagramPanel_MouseUp(object sender, MouseEventArgs e)
        {
            if (root != null)
            {
                root.PointerEnd(e);
                diagramPanel.Invalidate();
                saved = false;
            }
        }

        private void diagramPanel_DoubleClick(object sender, EventArgs e)
        {
            if (root != null)
            {
                if (root.DoubleClick())
                {
                    diagramPanel.Invalidate();
                    saved = false;
                }
            }
        }

        private void Form1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if(root != null)
            {
                e.Handled = root.KeyPress(e.KeyChar);
                if (e.Handled)
                {
                    diagramPanel.Invalidate();
                    saved = false;
                }
            }
        }

        private void Form1_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.KeyCode == Keys.Delete)
            {
                if(root != null)
                {
                    root.Remove();
                    diagramPanel.Invalidate();
                }
            }
        }

        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (fileName != null)
                Save();
            else
                saveAsToolStripMenuItem_Click(sender, e);
        }

        private void saveAsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "BT files (*.bt)|*.bt";
            dialog.FilterIndex = 0;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileName = dialog.FileName;
                Save();
            }
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (!saved)
            {
                DialogResult result = MessageBox.Show("There are unsaved changes. Do you want to save before opening a new behavior tree?", "Unsaved changes", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                    saveToolStripMenuItem_Click(sender, e);
                else if (result == DialogResult.Cancel)
                    return;
            }

            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "BT files (*.bt)|*.bt";
            dialog.FilterIndex = 0;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                fileName = dialog.FileName;
                Open();
            }
        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(!saved)
            {
                DialogResult result = MessageBox.Show("There are unsaved changes. Do you want to save before creating a new behavior tree?", "Unsaved changes", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                    saveToolStripMenuItem_Click(sender, e);
                else if (result == DialogResult.Cancel)
                    return;
            }
            root = null;
            saved = true;
            fileName = null;
            diagramPanel.Invalidate();
        }

        private void Save()
        {
            if (fileName == null)
                return;
            if (Write(fileName))
            {
                saved = true;
                diagramPanel.Invalidate();
            }
            else
            {
                MessageBox.Show("Failed to save the BT file.");
            }
        }

        private void Open()
        {
            if (fileName == null)
                return;
            RootNode root = Read(fileName);
            if (root != null)
            {
                this.root = root;
                saved = true;
                this.root.Translate(diagramPanel.Width / 2 - this.root.X, this.root.Height, alignGrid, gridSize);
                diagramPanel.Invalidate();
            }
            else
            {
                MessageBox.Show("Failed to open the BT file.");
            }
        }

        RootNode Read(string fileName)
        {
            try
            {
                Stream stream = new FileStream(fileName, FileMode.Open);
                BinaryFormatter b = new BinaryFormatter();
                RootNode root = (RootNode)b.Deserialize(stream);
                stream.Close();
                return root;

            }
            catch (Exception ex)
            {
            }
            return null;
        }

        bool Write(string fileName)
        {
            try
            {
                Stream stream = new FileStream(fileName, FileMode.OpenOrCreate);
                BinaryFormatter b = new BinaryFormatter();
                b.Serialize(stream, root);
                stream.Close();
                return true;
            }
            catch (Exception ex)
            { }
            return false;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!saved)
            {
                DialogResult result = MessageBox.Show("There are unsaved changes. Do you want to save before exiting?", "Unsaved changes", MessageBoxButtons.YesNoCancel);
                if (result == DialogResult.Yes)
                    saveToolStripMenuItem_Click(sender, e);
                else if (result == DialogResult.Cancel)
                    e.Cancel = true;
            }
        }

        private void gridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            drawGrid = !drawGrid;
            gridToolStripMenuItem.Checked = drawGrid;
            diagramPanel.Invalidate();
        }

        private void DrawGrid(Graphics graphics)
        {
            for(int x = gridSize; x < graphics.ClipBounds.Width; x += gridSize)
            {
                graphics.DrawLine(Pens.Silver, x, 0, x, graphics.ClipBounds.Height);
            }
            for (int y = gridSize; y < graphics.ClipBounds.Height; y += gridSize)
            {
                graphics.DrawLine(Pens.Silver, 0, y, graphics.ClipBounds.Width, y);
            }
        }

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            gridSize = 10;
            toolStripMenuItem2.Checked = true;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = false;
            diagramPanel.Invalidate();
        }

        private void toolStripMenuItem3_Click(object sender, EventArgs e)
        {
            gridSize = 20;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = true;
            toolStripMenuItem4.Checked = false;
            diagramPanel.Invalidate();
        }

        private void toolStripMenuItem4_Click(object sender, EventArgs e)
        {
            gridSize = 40;
            toolStripMenuItem2.Checked = false;
            toolStripMenuItem3.Checked = false;
            toolStripMenuItem4.Checked = true;
            diagramPanel.Invalidate();
        }

        private void alignToGridToolStripMenuItem_Click(object sender, EventArgs e)
        {
            alignGrid = !alignGrid;
            alignToGridToolStripMenuItem.Checked = alignGrid;
        }

        private void autoArrangeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (root != null)
            {
                root.Move(diagramPanel.Width / 2, root.Height, alignGrid, gridSize);
                root.AutoArrange();
                diagramPanel.Invalidate();
            }
        }

        private void exportAsImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(timer.Enabled)
                timer.Stop();
            antiAlias = true;
            SaveFileDialog dialog = new SaveFileDialog();
            dialog.Filter = "PNG files (*.png)|*.png";
            dialog.FilterIndex = 0;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                Bitmap newBitmap = new Bitmap(diagramPanel.Width, diagramPanel.Height);
                diagramPanel.DrawToBitmap(newBitmap, new Rectangle(0, 0, diagramPanel.Width, diagramPanel.Height));
                newBitmap.Save(dialog.FileName);
            }
            if(Node.DrawStatus)
                timer.Start();
            antiAlias = antialiasingToolStripMenuItem.Checked;
        }

        private void runNowToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(root != null)
            {
                root.Run();
                Node.DrawStatus = true;
                diagramPanel.Invalidate();
                if(!timer.Enabled)
                    Node.DrawStatus = false;
            }
        }

        private void alwaysRunningToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Node.DrawStatus = !Node.DrawStatus;
            alwaysRunningToolStripMenuItem.Checked = Node.DrawStatus;
            if (Node.DrawStatus && !timer.Enabled)
                timer.Start();
            else if (!Node.DrawStatus && timer.Enabled)
                timer.Stop();
            diagramPanel.Invalidate();
        }

        private void antialiasingToolStripMenuItem_Click(object sender, EventArgs e)
        {
            antiAlias = !antiAlias;
            antialiasingToolStripMenuItem.Checked = antiAlias;
            diagramPanel.Invalidate();
        }

        private void importBTToolStripMenuItem_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "BT files (*.bt)|*.bt";
            dialog.FilterIndex = 0;
            dialog.RestoreDirectory = true;
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                RootNode r = Read(dialog.FileName);
                if(r != null)
                {
                    foreach (Node node in r.AllNodes)
                    {
                        if (node.Parent == r)
                        {
                            node.Release();
                        }
                        root.AddOpen(node);
                    }
                    diagramPanel.Invalidate();
                }
                else
                {
                    MessageBox.Show("Failed to import the BT file.");
                }
            }
        }

        private void undoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yey");
        }

        private void redoToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yey");
        }

        private void copyToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yey");
        }

        private void cutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yey");
        }

        private void pasteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Not implemented yey");
        }

        private void toolStripMenuItem5_Click(object sender, EventArgs e)
        {
            timer.Interval = 100;
            toolStripMenuItem5.Checked = true;
            msToolStripMenuItem.Checked = false;
            msToolStripMenuItem1.Checked = false;
        }

        private void msToolStripMenuItem_Click(object sender, EventArgs e)
        {
            timer.Interval = 500;
            toolStripMenuItem5.Checked = false;
            msToolStripMenuItem.Checked = true;
            msToolStripMenuItem1.Checked = false;
        }

        private void msToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            timer.Interval = 1000;
            toolStripMenuItem5.Checked = false;
            msToolStripMenuItem.Checked = false;
            msToolStripMenuItem1.Checked = true;
        }
    }
}
