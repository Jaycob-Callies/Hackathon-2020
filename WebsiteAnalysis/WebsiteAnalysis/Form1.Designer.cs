namespace WebsiteAnalysis
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.domainTextBox = new System.Windows.Forms.TextBox();
            this.mapDomainButton = new System.Windows.Forms.Button();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.settingsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setDeliminatorsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.ampersandToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.equalsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.questionMarkStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.highlightDistantNodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.afterLinearForToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clicksLinearText = new System.Windows.Forms.ToolStripTextBox();
            this.afterXClicksFromRootToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.clicksFromRootText = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.searchSubDomainsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.setMaxNodesToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.setMaxNodesText = new System.Windows.Forms.ToolStripTextBox();
            this.shortestPathButton = new System.Windows.Forms.Button();
            this.destinationTextBox = new System.Windows.Forms.TextBox();
            this.treeView1 = new WebsiteAnalysis.URLTree();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // domainTextBox
            // 
            this.domainTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.domainTextBox.Location = new System.Drawing.Point(130, 27);
            this.domainTextBox.Name = "domainTextBox";
            this.domainTextBox.Size = new System.Drawing.Size(217, 20);
            this.domainTextBox.TabIndex = 0;
            this.domainTextBox.Text = "example.com";
            this.domainTextBox.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // mapDomainButton
            // 
            this.mapDomainButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.mapDomainButton.Location = new System.Drawing.Point(353, 27);
            this.mapDomainButton.Name = "mapDomainButton";
            this.mapDomainButton.Size = new System.Drawing.Size(79, 20);
            this.mapDomainButton.TabIndex = 1;
            this.mapDomainButton.Text = "Map Domain";
            this.mapDomainButton.UseVisualStyleBackColor = true;
            this.mapDomainButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.settingsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 3;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // settingsToolStripMenuItem
            // 
            this.settingsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setDeliminatorsToolStripMenuItem,
            this.toolStripSeparator1,
            this.highlightDistantNodesToolStripMenuItem,
            this.toolStripSeparator2,
            this.searchSubDomainsToolStripMenuItem,
            this.toolStripSeparator3,
            this.setMaxNodesToolStripMenuItem});
            this.settingsToolStripMenuItem.Name = "settingsToolStripMenuItem";
            this.settingsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.settingsToolStripMenuItem.Text = "Settings";
            // 
            // setDeliminatorsToolStripMenuItem
            // 
            this.setDeliminatorsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ampersandToolStripMenuItem,
            this.equalsToolStripMenuItem,
            this.questionMarkStripMenuItem});
            this.setDeliminatorsToolStripMenuItem.Name = "setDeliminatorsToolStripMenuItem";
            this.setDeliminatorsToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.setDeliminatorsToolStripMenuItem.Text = "Set Deliminators";
            // 
            // ampersandToolStripMenuItem
            // 
            this.ampersandToolStripMenuItem.Checked = true;
            this.ampersandToolStripMenuItem.CheckOnClick = true;
            this.ampersandToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.ampersandToolStripMenuItem.Name = "ampersandToolStripMenuItem";
            this.ampersandToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.ampersandToolStripMenuItem.Text = "Ampersand";
            this.ampersandToolStripMenuItem.Click += new System.EventHandler(this.ampToolStripMenuItem_Click);
            // 
            // equalsToolStripMenuItem
            // 
            this.equalsToolStripMenuItem.Checked = true;
            this.equalsToolStripMenuItem.CheckOnClick = true;
            this.equalsToolStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.equalsToolStripMenuItem.Name = "equalsToolStripMenuItem";
            this.equalsToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.equalsToolStripMenuItem.Text = "Equals";
            this.equalsToolStripMenuItem.Click += new System.EventHandler(this.equalsToolStripMenuItem_Click);
            // 
            // questionMarkStripMenuItem
            // 
            this.questionMarkStripMenuItem.Checked = true;
            this.questionMarkStripMenuItem.CheckOnClick = true;
            this.questionMarkStripMenuItem.CheckState = System.Windows.Forms.CheckState.Checked;
            this.questionMarkStripMenuItem.Name = "questionMarkStripMenuItem";
            this.questionMarkStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.questionMarkStripMenuItem.Text = "Question Mark";
            this.questionMarkStripMenuItem.Click += new System.EventHandler(this.questionMarkToolStripMenuItem_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(198, 6);
            // 
            // highlightDistantNodesToolStripMenuItem
            // 
            this.highlightDistantNodesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.afterLinearForToolStripMenuItem,
            this.afterXClicksFromRootToolStripMenuItem});
            this.highlightDistantNodesToolStripMenuItem.Name = "highlightDistantNodesToolStripMenuItem";
            this.highlightDistantNodesToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.highlightDistantNodesToolStripMenuItem.Text = "Highlight Distant Nodes";
            // 
            // afterLinearForToolStripMenuItem
            // 
            this.afterLinearForToolStripMenuItem.CheckOnClick = true;
            this.afterLinearForToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clicksLinearText});
            this.afterLinearForToolStripMenuItem.Name = "afterLinearForToolStripMenuItem";
            this.afterLinearForToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.afterLinearForToolStripMenuItem.Text = "After Linear for x Clicks";
            this.afterLinearForToolStripMenuItem.Click += new System.EventHandler(this.afterLinearForToolStripMenuItem_Click);
            // 
            // clicksLinearText
            // 
            this.clicksLinearText.AcceptsReturn = true;
            this.clicksLinearText.Name = "clicksLinearText";
            this.clicksLinearText.Size = new System.Drawing.Size(200, 23);
            this.clicksLinearText.Text = "3";
            this.clicksLinearText.TextChanged += new System.EventHandler(this.linearText_Leave);
            // 
            // afterXClicksFromRootToolStripMenuItem
            // 
            this.afterXClicksFromRootToolStripMenuItem.CheckOnClick = true;
            this.afterXClicksFromRootToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.clicksFromRootText});
            this.afterXClicksFromRootToolStripMenuItem.Name = "afterXClicksFromRootToolStripMenuItem";
            this.afterXClicksFromRootToolStripMenuItem.Size = new System.Drawing.Size(200, 22);
            this.afterXClicksFromRootToolStripMenuItem.Text = "After x Clicks from Root";
            this.afterXClicksFromRootToolStripMenuItem.Click += new System.EventHandler(this.afterXClicksFromRootToolStripMenuItem_Click);
            // 
            // clicksFromRootText
            // 
            this.clicksFromRootText.AcceptsReturn = true;
            this.clicksFromRootText.Name = "clicksFromRootText";
            this.clicksFromRootText.Size = new System.Drawing.Size(200, 23);
            this.clicksFromRootText.Text = "5";
            this.clicksFromRootText.TextChanged += new System.EventHandler(this.clicksFromRootText_Leave);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(198, 6);
            // 
            // searchSubDomainsToolStripMenuItem
            // 
            this.searchSubDomainsToolStripMenuItem.CheckOnClick = true;
            this.searchSubDomainsToolStripMenuItem.Name = "searchSubDomainsToolStripMenuItem";
            this.searchSubDomainsToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.searchSubDomainsToolStripMenuItem.Text = "Search SubDomains";
            this.searchSubDomainsToolStripMenuItem.Click += new System.EventHandler(this.searchSubDomainsToolStripMenuItem_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(198, 6);
            // 
            // setMaxNodesToolStripMenuItem
            // 
            this.setMaxNodesToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.setMaxNodesText});
            this.setMaxNodesToolStripMenuItem.Name = "setMaxNodesToolStripMenuItem";
            this.setMaxNodesToolStripMenuItem.Size = new System.Drawing.Size(201, 22);
            this.setMaxNodesToolStripMenuItem.Text = "Set Max Nodes";
            // 
            // setMaxNodesText
            // 
            this.setMaxNodesText.AcceptsReturn = true;
            this.setMaxNodesText.Name = "setMaxNodesText";
            this.setMaxNodesText.Size = new System.Drawing.Size(180, 23);
            this.setMaxNodesText.Text = "1000";
            this.setMaxNodesText.TextChanged += new System.EventHandler(this.setMaxNodesText_Leave);
            // 
            // shortestPathButton
            // 
            this.shortestPathButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.shortestPathButton.Location = new System.Drawing.Point(661, 27);
            this.shortestPathButton.Name = "shortestPathButton";
            this.shortestPathButton.Size = new System.Drawing.Size(127, 20);
            this.shortestPathButton.TabIndex = 5;
            this.shortestPathButton.Text = "Calculate Shortest Path ";
            this.shortestPathButton.UseVisualStyleBackColor = true;
            this.shortestPathButton.Click += new System.EventHandler(this.shortestPathButton_Click);
            // 
            // destinationTextBox
            // 
            this.destinationTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.destinationTextBox.Location = new System.Drawing.Point(438, 27);
            this.destinationTextBox.Name = "destinationTextBox";
            this.destinationTextBox.Size = new System.Drawing.Size(217, 20);
            this.destinationTextBox.TabIndex = 4;
            this.destinationTextBox.Text = "example.com";
            // 
            // treeView1
            // 
            this.treeView1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.treeView1.Location = new System.Drawing.Point(12, 53);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(776, 385);
            this.treeView1.TabIndex = 2;
            this.treeView1.MouseDoubleClick += new System.Windows.Forms.MouseEventHandler(this.treeView1_AfterSelect);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.shortestPathButton);
            this.Controls.Add(this.destinationTextBox);
            this.Controls.Add(this.treeView1);
            this.Controls.Add(this.mapDomainButton);
            this.Controls.Add(this.domainTextBox);
            this.Controls.Add(this.menuStrip1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "Form1";
            this.Text = "Domain Analyzer";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox domainTextBox;
        private System.Windows.Forms.Button mapDomainButton;
        private WebsiteAnalysis.URLTree treeView1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem settingsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem setDeliminatorsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem searchSubDomainsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ampersandToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem equalsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem questionMarkStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem highlightDistantNodesToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afterLinearForToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem afterXClicksFromRootToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox clicksLinearText;
        private System.Windows.Forms.ToolStripTextBox clicksFromRootText;
        private System.Windows.Forms.Button shortestPathButton;
        private System.Windows.Forms.TextBox destinationTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripMenuItem setMaxNodesToolStripMenuItem;
        private System.Windows.Forms.ToolStripTextBox setMaxNodesText;
    }
}

