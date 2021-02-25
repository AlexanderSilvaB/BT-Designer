namespace Behavior_Tree_Designer
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.saveAsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.importBTToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportAsImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToLaTeXToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.exportToLateXToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.exitToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.editToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.redoToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.copyToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.cutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pasteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.autoArrangeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.viewToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem3 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripMenuItem();
            this.alignToGridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.antialiasingToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.runNowToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alwaysRunningToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tickToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripMenuItem();
            this.msToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.msToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.helpToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.aboutToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsMenu = new System.Windows.Forms.ToolStrip();
            this.btnSelector = new System.Windows.Forms.ToolStripButton();
            this.btnSequence = new System.Windows.Forms.ToolStripButton();
            this.btnParallel = new System.Windows.Forms.ToolStripButton();
            this.btInverter = new System.Windows.Forms.ToolStripButton();
            this.btSuccess = new System.Windows.Forms.ToolStripButton();
            this.btFailure = new System.Windows.Forms.ToolStripButton();
            this.btnCondition = new System.Windows.Forms.ToolStripButton();
            this.btnAction = new System.Windows.Forms.ToolStripButton();
            this.btnFlipper = new System.Windows.Forms.ToolStripButton();
            this.diagramPanel = new System.Windows.Forms.PictureBox();
            this.menuStrip1.SuspendLayout();
            this.optionsMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diagramPanel)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.editToolStripMenuItem,
            this.viewToolStripMenuItem,
            this.runToolStripMenuItem,
            this.helpToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(812, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.openToolStripMenuItem,
            this.saveToolStripMenuItem,
            this.saveAsToolStripMenuItem,
            this.toolStripSeparator4,
            this.importBTToolStripMenuItem,
            this.exportAsImageToolStripMenuItem,
            this.exportToLaTeXToolStripMenuItem1,
            this.exportToLateXToolStripMenuItem,
            this.toolStripSeparator1,
            this.exitToolStripMenuItem});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.N)));
            this.newToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // openToolStripMenuItem
            // 
            this.openToolStripMenuItem.Name = "openToolStripMenuItem";
            this.openToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.openToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.openToolStripMenuItem.Text = "Open";
            this.openToolStripMenuItem.Click += new System.EventHandler(this.openToolStripMenuItem_Click);
            // 
            // saveToolStripMenuItem
            // 
            this.saveToolStripMenuItem.Name = "saveToolStripMenuItem";
            this.saveToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.S)));
            this.saveToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.saveToolStripMenuItem.Text = "Save";
            this.saveToolStripMenuItem.Click += new System.EventHandler(this.saveToolStripMenuItem_Click);
            // 
            // saveAsToolStripMenuItem
            // 
            this.saveAsToolStripMenuItem.Name = "saveAsToolStripMenuItem";
            this.saveAsToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.S)));
            this.saveAsToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.saveAsToolStripMenuItem.Text = "Save as ...";
            this.saveAsToolStripMenuItem.Click += new System.EventHandler(this.saveAsToolStripMenuItem_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(293, 6);
            // 
            // importBTToolStripMenuItem
            // 
            this.importBTToolStripMenuItem.Name = "importBTToolStripMenuItem";
            this.importBTToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.I)));
            this.importBTToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.importBTToolStripMenuItem.Text = "Import BT";
            this.importBTToolStripMenuItem.Click += new System.EventHandler(this.importBTToolStripMenuItem_Click);
            // 
            // exportAsImageToolStripMenuItem
            // 
            this.exportAsImageToolStripMenuItem.Name = "exportAsImageToolStripMenuItem";
            this.exportAsImageToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.E)));
            this.exportAsImageToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.exportAsImageToolStripMenuItem.Text = "Export as image";
            this.exportAsImageToolStripMenuItem.Click += new System.EventHandler(this.exportAsImageToolStripMenuItem_Click);
            // 
            // exportToLaTeXToolStripMenuItem1
            // 
            this.exportToLaTeXToolStripMenuItem1.Name = "exportToLaTeXToolStripMenuItem1";
            this.exportToLaTeXToolStripMenuItem1.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.exportToLaTeXToolStripMenuItem1.Size = new System.Drawing.Size(296, 22);
            this.exportToLaTeXToolStripMenuItem1.Text = "Export to LaTeX";
            this.exportToLaTeXToolStripMenuItem1.Click += new System.EventHandler(this.exportToLaTeXToolStripMenuItem1_Click);
            // 
            // exportToLateXToolStripMenuItem
            // 
            this.exportToLateXToolStripMenuItem.Name = "exportToLateXToolStripMenuItem";
            this.exportToLateXToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Alt) 
            | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.E)));
            this.exportToLateXToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.exportToLateXToolStripMenuItem.Text = "Export selected to LaTeX";
            this.exportToLateXToolStripMenuItem.Click += new System.EventHandler(this.exportToLateXToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(293, 6);
            // 
            // exitToolStripMenuItem
            // 
            this.exitToolStripMenuItem.Name = "exitToolStripMenuItem";
            this.exitToolStripMenuItem.Size = new System.Drawing.Size(296, 22);
            this.exitToolStripMenuItem.Text = "Exit";
            this.exitToolStripMenuItem.Click += new System.EventHandler(this.exitToolStripMenuItem_Click);
            // 
            // editToolStripMenuItem
            // 
            this.editToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.undoToolStripMenuItem,
            this.redoToolStripMenuItem,
            this.toolStripSeparator5,
            this.copyToolStripMenuItem,
            this.cutToolStripMenuItem,
            this.pasteToolStripMenuItem,
            this.toolStripSeparator3,
            this.autoArrangeToolStripMenuItem});
            this.editToolStripMenuItem.Name = "editToolStripMenuItem";
            this.editToolStripMenuItem.Size = new System.Drawing.Size(39, 20);
            this.editToolStripMenuItem.Text = "Edit";
            // 
            // undoToolStripMenuItem
            // 
            this.undoToolStripMenuItem.Name = "undoToolStripMenuItem";
            this.undoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Z)));
            this.undoToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.undoToolStripMenuItem.Text = "Undo";
            this.undoToolStripMenuItem.Click += new System.EventHandler(this.undoToolStripMenuItem_Click);
            // 
            // redoToolStripMenuItem
            // 
            this.redoToolStripMenuItem.Name = "redoToolStripMenuItem";
            this.redoToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.Z)));
            this.redoToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.redoToolStripMenuItem.Text = "Redo";
            this.redoToolStripMenuItem.Click += new System.EventHandler(this.redoToolStripMenuItem_Click);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(182, 6);
            // 
            // copyToolStripMenuItem
            // 
            this.copyToolStripMenuItem.Name = "copyToolStripMenuItem";
            this.copyToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.C)));
            this.copyToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.copyToolStripMenuItem.Text = "Copy";
            this.copyToolStripMenuItem.Click += new System.EventHandler(this.copyToolStripMenuItem_Click);
            // 
            // cutToolStripMenuItem
            // 
            this.cutToolStripMenuItem.Name = "cutToolStripMenuItem";
            this.cutToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.X)));
            this.cutToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.cutToolStripMenuItem.Text = "Cut";
            this.cutToolStripMenuItem.Click += new System.EventHandler(this.cutToolStripMenuItem_Click);
            // 
            // pasteToolStripMenuItem
            // 
            this.pasteToolStripMenuItem.Name = "pasteToolStripMenuItem";
            this.pasteToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.V)));
            this.pasteToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.pasteToolStripMenuItem.Text = "Paste";
            this.pasteToolStripMenuItem.Click += new System.EventHandler(this.pasteToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(182, 6);
            // 
            // autoArrangeToolStripMenuItem
            // 
            this.autoArrangeToolStripMenuItem.Name = "autoArrangeToolStripMenuItem";
            this.autoArrangeToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.A)));
            this.autoArrangeToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
            this.autoArrangeToolStripMenuItem.Text = "Auto arrange";
            this.autoArrangeToolStripMenuItem.Click += new System.EventHandler(this.autoArrangeToolStripMenuItem_Click);
            // 
            // viewToolStripMenuItem
            // 
            this.viewToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.gridToolStripMenuItem,
            this.alignToGridToolStripMenuItem,
            this.toolStripSeparator2,
            this.antialiasingToolStripMenuItem});
            this.viewToolStripMenuItem.Name = "viewToolStripMenuItem";
            this.viewToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.viewToolStripMenuItem.Text = "View";
            // 
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.Checked = true;
            this.gridToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.gridToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem2,
            this.toolStripMenuItem3,
            this.toolStripMenuItem4});
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            this.gridToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.G)));
            this.gridToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.gridToolStripMenuItem.Text = "Grid";
            this.gridToolStripMenuItem.Click += new System.EventHandler(this.gridToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem2.Text = "10";
            this.toolStripMenuItem2.Click += new System.EventHandler(this.toolStripMenuItem2_Click);
            // 
            // toolStripMenuItem3
            // 
            this.toolStripMenuItem3.Checked = true;
            this.toolStripMenuItem3.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem3.Name = "toolStripMenuItem3";
            this.toolStripMenuItem3.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem3.Text = "20";
            this.toolStripMenuItem3.Click += new System.EventHandler(this.toolStripMenuItem3_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(86, 22);
            this.toolStripMenuItem4.Text = "40";
            this.toolStripMenuItem4.Click += new System.EventHandler(this.toolStripMenuItem4_Click);
            // 
            // alignToGridToolStripMenuItem
            // 
            this.alignToGridToolStripMenuItem.Checked = true;
            this.alignToGridToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.alignToGridToolStripMenuItem.Name = "alignToGridToolStripMenuItem";
            this.alignToGridToolStripMenuItem.ShortcutKeys = ((System.Windows.Forms.Keys)(((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Shift) 
            | System.Windows.Forms.Keys.G)));
            this.alignToGridToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.alignToGridToolStripMenuItem.Text = "Align to grid";
            this.alignToGridToolStripMenuItem.Click += new System.EventHandler(this.alignToGridToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(211, 6);
            // 
            // antialiasingToolStripMenuItem
            // 
            this.antialiasingToolStripMenuItem.Checked = true;
            this.antialiasingToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.antialiasingToolStripMenuItem.Name = "antialiasingToolStripMenuItem";
            this.antialiasingToolStripMenuItem.Size = new System.Drawing.Size(214, 22);
            this.antialiasingToolStripMenuItem.Text = "Anti-aliasing";
            this.antialiasingToolStripMenuItem.Click += new System.EventHandler(this.antialiasingToolStripMenuItem_Click);
            // 
            // runToolStripMenuItem
            // 
            this.runToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.runNowToolStripMenuItem,
            this.alwaysRunningToolStripMenuItem,
            this.tickToolStripMenuItem});
            this.runToolStripMenuItem.Name = "runToolStripMenuItem";
            this.runToolStripMenuItem.Size = new System.Drawing.Size(40, 20);
            this.runToolStripMenuItem.Text = "Run";
            // 
            // runNowToolStripMenuItem
            // 
            this.runNowToolStripMenuItem.Name = "runNowToolStripMenuItem";
            this.runNowToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.runNowToolStripMenuItem.Text = "Run now";
            this.runNowToolStripMenuItem.Click += new System.EventHandler(this.runNowToolStripMenuItem_Click);
            // 
            // alwaysRunningToolStripMenuItem
            // 
            this.alwaysRunningToolStripMenuItem.Name = "alwaysRunningToolStripMenuItem";
            this.alwaysRunningToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F5;
            this.alwaysRunningToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.alwaysRunningToolStripMenuItem.Text = "Always running";
            this.alwaysRunningToolStripMenuItem.Click += new System.EventHandler(this.alwaysRunningToolStripMenuItem_Click);
            // 
            // tickToolStripMenuItem
            // 
            this.tickToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem5,
            this.msToolStripMenuItem,
            this.msToolStripMenuItem1});
            this.tickToolStripMenuItem.Name = "tickToolStripMenuItem";
            this.tickToolStripMenuItem.Size = new System.Drawing.Size(175, 22);
            this.tickToolStripMenuItem.Text = "Tick";
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Checked = true;
            this.toolStripMenuItem5.CheckState = System.Windows.Forms.CheckState.Checked;
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(117, 22);
            this.toolStripMenuItem5.Text = "100 ms";
            this.toolStripMenuItem5.Click += new System.EventHandler(this.toolStripMenuItem5_Click);
            // 
            // msToolStripMenuItem
            // 
            this.msToolStripMenuItem.Name = "msToolStripMenuItem";
            this.msToolStripMenuItem.Size = new System.Drawing.Size(117, 22);
            this.msToolStripMenuItem.Text = "500 ms";
            this.msToolStripMenuItem.Click += new System.EventHandler(this.msToolStripMenuItem_Click);
            // 
            // msToolStripMenuItem1
            // 
            this.msToolStripMenuItem1.Name = "msToolStripMenuItem1";
            this.msToolStripMenuItem1.Size = new System.Drawing.Size(117, 22);
            this.msToolStripMenuItem1.Text = "1000 ms";
            this.msToolStripMenuItem1.Click += new System.EventHandler(this.msToolStripMenuItem1_Click);
            // 
            // helpToolStripMenuItem
            // 
            this.helpToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.aboutToolStripMenuItem});
            this.helpToolStripMenuItem.Name = "helpToolStripMenuItem";
            this.helpToolStripMenuItem.Size = new System.Drawing.Size(44, 20);
            this.helpToolStripMenuItem.Text = "Help";
            // 
            // aboutToolStripMenuItem
            // 
            this.aboutToolStripMenuItem.Name = "aboutToolStripMenuItem";
            this.aboutToolStripMenuItem.Size = new System.Drawing.Size(107, 22);
            this.aboutToolStripMenuItem.Text = "About";
            this.aboutToolStripMenuItem.Click += new System.EventHandler(this.aboutToolStripMenuItem_Click);
            // 
            // optionsMenu
            // 
            this.optionsMenu.AutoSize = false;
            this.optionsMenu.BackColor = System.Drawing.SystemColors.Control;
            this.optionsMenu.Dock = System.Windows.Forms.DockStyle.Right;
            this.optionsMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.btnSelector,
            this.btnSequence,
            this.btnParallel,
            this.btInverter,
            this.btSuccess,
            this.btFailure,
            this.btnCondition,
            this.btnAction,
            this.btnFlipper});
            this.optionsMenu.Location = new System.Drawing.Point(764, 24);
            this.optionsMenu.Name = "optionsMenu";
            this.optionsMenu.Size = new System.Drawing.Size(48, 474);
            this.optionsMenu.TabIndex = 2;
            // 
            // btnSelector
            // 
            this.btnSelector.AutoSize = false;
            this.btnSelector.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSelector.ForeColor = System.Drawing.SystemColors.ControlText;
            this.btnSelector.Image = global::Behavior_Tree_Designer.Properties.Resources.iconfinder_question_1608802;
            this.btnSelector.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSelector.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSelector.Name = "btnSelector";
            this.btnSelector.Size = new System.Drawing.Size(46, 32);
            this.btnSelector.Text = "Selector";
            this.btnSelector.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSelector.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnSelector.Click += new System.EventHandler(this.btnSelector_Click);
            // 
            // btnSequence
            // 
            this.btnSequence.AutoSize = false;
            this.btnSequence.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSequence.Image = global::Behavior_Tree_Designer.Properties.Resources.iconfinder_arrow_right_227601;
            this.btnSequence.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnSequence.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnSequence.Name = "btnSequence";
            this.btnSequence.Size = new System.Drawing.Size(46, 32);
            this.btnSequence.Text = "Sequence";
            this.btnSequence.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnSequence.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnSequence.Click += new System.EventHandler(this.btnSequence_Click);
            // 
            // btnParallel
            // 
            this.btnParallel.AutoSize = false;
            this.btnParallel.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnParallel.Image = global::Behavior_Tree_Designer.Properties.Resources.iconfinder_arrow_7_393270;
            this.btnParallel.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnParallel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnParallel.Name = "btnParallel";
            this.btnParallel.Size = new System.Drawing.Size(46, 32);
            this.btnParallel.Text = "Parallel";
            this.btnParallel.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnParallel.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnParallel.Click += new System.EventHandler(this.btnParallel_Click);
            // 
            // btInverter
            // 
            this.btInverter.AutoSize = false;
            this.btInverter.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btInverter.Image = global::Behavior_Tree_Designer.Properties.Resources.iconfinder_UnitedArrowUpDown_1031499__1_;
            this.btInverter.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btInverter.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btInverter.Name = "btInverter";
            this.btInverter.Size = new System.Drawing.Size(46, 32);
            this.btInverter.Text = "Inverter";
            this.btInverter.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btInverter.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btInverter.Click += new System.EventHandler(this.Inverter_Click);
            // 
            // btSuccess
            // 
            this.btSuccess.AutoSize = false;
            this.btSuccess.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btSuccess.Image = global::Behavior_Tree_Designer.Properties.Resources.iconfinder_true_check_accept_approve_2075831__1_;
            this.btSuccess.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btSuccess.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btSuccess.Name = "btSuccess";
            this.btSuccess.Size = new System.Drawing.Size(46, 32);
            this.btSuccess.Text = "Success";
            this.btSuccess.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btSuccess.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btSuccess.Click += new System.EventHandler(this.btTrue_Click);
            // 
            // btFailure
            // 
            this.btFailure.AutoSize = false;
            this.btFailure.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btFailure.Image = global::Behavior_Tree_Designer.Properties.Resources.iconfinder_false_cross_reject_decline_2075833;
            this.btFailure.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btFailure.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btFailure.Name = "btFailure";
            this.btFailure.Size = new System.Drawing.Size(46, 32);
            this.btFailure.Text = "Failure";
            this.btFailure.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btFailure.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btFailure.Click += new System.EventHandler(this.btFalse_Click);
            // 
            // btnCondition
            // 
            this.btnCondition.AutoSize = false;
            this.btnCondition.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnCondition.Image = global::Behavior_Tree_Designer.Properties.Resources.iconfinder_triangle_up_293707;
            this.btnCondition.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnCondition.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnCondition.Name = "btnCondition";
            this.btnCondition.Size = new System.Drawing.Size(46, 32);
            this.btnCondition.Text = "Condition";
            this.btnCondition.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnCondition.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnCondition.Click += new System.EventHandler(this.btnCondition_Click);
            // 
            // btnAction
            // 
            this.btnAction.AutoSize = false;
            this.btnAction.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAction.Image = global::Behavior_Tree_Designer.Properties.Resources.iconfinder_check_circle_outline_blank_326565;
            this.btnAction.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnAction.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnAction.Name = "btnAction";
            this.btnAction.Size = new System.Drawing.Size(46, 32);
            this.btnAction.Text = "Action";
            this.btnAction.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnAction.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnAction.Click += new System.EventHandler(this.btnAction_Click);
            // 
            // btnFlipper
            // 
            this.btnFlipper.AutoSize = false;
            this.btnFlipper.Font = new System.Drawing.Font("Segoe UI", 6.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFlipper.Image = global::Behavior_Tree_Designer.Properties.Resources.iconfinder_clock_226587;
            this.btnFlipper.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFlipper.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnFlipper.Name = "btnFlipper";
            this.btnFlipper.Size = new System.Drawing.Size(46, 32);
            this.btnFlipper.Text = "Flipper";
            this.btnFlipper.TextAlign = System.Drawing.ContentAlignment.BottomCenter;
            this.btnFlipper.TextImageRelation = System.Windows.Forms.TextImageRelation.Overlay;
            this.btnFlipper.Click += new System.EventHandler(this.btnFlipper_Click);
            // 
            // diagramPanel
            // 
            this.diagramPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.diagramPanel.Location = new System.Drawing.Point(0, 24);
            this.diagramPanel.Name = "diagramPanel";
            this.diagramPanel.Size = new System.Drawing.Size(764, 474);
            this.diagramPanel.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.diagramPanel.TabIndex = 3;
            this.diagramPanel.TabStop = false;
            this.diagramPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.diagramPanel_Paint);
            this.diagramPanel.DoubleClick += new System.EventHandler(this.diagramPanel_DoubleClick);
            this.diagramPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.diagramPanel_MouseDown);
            this.diagramPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.diagramPanel_MouseMove);
            this.diagramPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.diagramPanel_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(812, 498);
            this.Controls.Add(this.diagramPanel);
            this.Controls.Add(this.optionsMenu);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Behavior Tree Designer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.Form1_KeyDown);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Form1_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.optionsMenu.ResumeLayout(false);
            this.optionsMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.diagramPanel)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem saveAsToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem exitToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem editToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem copyToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem cutToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem pasteToolStripMenuItem;
        private System.Windows.Forms.ToolStrip optionsMenu;
        private System.Windows.Forms.ToolStripButton btnSelector;
        private System.Windows.Forms.ToolStripButton btnSequence;
        private System.Windows.Forms.ToolStripButton btnCondition;
        private System.Windows.Forms.ToolStripButton btnAction;
        private System.Windows.Forms.PictureBox diagramPanel;
        private System.Windows.Forms.ToolStripButton btFailure;
        private System.Windows.Forms.ToolStripMenuItem viewToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem2;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem3;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem alignToGridToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem autoArrangeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem exportAsImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem runNowToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alwaysRunningToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnFlipper;
        private System.Windows.Forms.ToolStripMenuItem antialiasingToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem importBTToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem undoToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem redoToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripMenuItem tickToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem5;
        private System.Windows.Forms.ToolStripMenuItem msToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem msToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem helpToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem aboutToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btInverter;
        private System.Windows.Forms.ToolStripButton btSuccess;
        private System.Windows.Forms.ToolStripMenuItem exportToLaTeXToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem exportToLateXToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton btnParallel;
    }
}

