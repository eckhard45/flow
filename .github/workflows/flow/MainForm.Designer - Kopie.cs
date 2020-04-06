/*
 * Created by SharpDevelop.
 * User: Eckhard
 * Date: 23.02.2020
 * Time: 16:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace flow
{
	partial class MainForm
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		/// 
    private System.Windows.Forms.FlowLayoutPanel FlowLayoutPanel1;
    private System.Windows.Forms.CheckBox wrapContentsCheckBox;
    private System.Windows.Forms.RadioButton flowTopDownBtn;
    private System.Windows.Forms.RadioButton flowBottomUpBtn;
    private System.Windows.Forms.RadioButton flowLeftToRight;
    private System.Windows.Forms.RadioButton flowRightToLeftBtn;
    private System.Windows.Forms.Button Button2;
    private System.Windows.Forms.Button Button3;
    private System.Windows.Forms.Button Button4;
    private System.Windows.Forms.MenuStrip menuStrip1;
    private System.Windows.Forms.ToolStripMenuItem dateiToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem öffnenToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem neuToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem speichernToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem ansichtToolStripMenuItem;
    private System.Windows.Forms.ListBox listBox1;
    private System.Windows.Forms.OpenFileDialog openFileDialog1;
    public System.Windows.Forms.Panel flowLayoutPanel2;
    private System.Windows.Forms.ToolStripMenuItem clearItemToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem clearPlaneToolStripMenuItem;
    private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
    private System.Windows.Forms.ToolStripMenuItem itemLöschenToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem bildDrehenToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem schiebenToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem alleLöschenToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem attrToolStripMenuItem;
    private System.Windows.Forms.TextBox tbDescr;
    private System.Windows.Forms.Label label13;
    private System.Windows.Forms.TextBox tbKarte;
    private System.Windows.Forms.Label label12;
    private System.Windows.Forms.TextBox tbZeit;
    private System.Windows.Forms.Label label11;
    private System.Windows.Forms.TextBox tbTitel;
    private System.Windows.Forms.Label label10;
    private System.Windows.Forms.TextBox tbID;
    private System.Windows.Forms.StatusStrip statusStrip1;
	private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
    private System.Windows.Forms.GroupBox groupBox1;
    private System.Windows.Forms.GroupBox groupBox2;
    private System.Windows.Forms.Label label1;
    private System.Windows.Forms.HScrollBar hScrollBar1;
    private System.Windows.Forms.Label label2;
    private System.Windows.Forms.Label label3;
    private System.Windows.Forms.Label label4;
    private System.Windows.Forms.ToolStripMenuItem xmlToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem xMLNeuToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem xMLÖffnenToolStripMenuItem;
    private System.Windows.Forms.ToolStripMenuItem xMLEditierenToolStripMenuItem;
	private System.Windows.Forms.TextBox tbPfad;
    private System.Windows.Forms.TextBox tbFTitel;
    private System.Windows.Forms.TextBox tbFName;
    private System.Windows.Forms.Label label5;
    private System.Windows.Forms.TextBox tbFDescr;
    private System.Windows.Forms.Button btLast;
    private System.Windows.Forms.ToolStripMenuItem neueBilderSchiebenToolStripMenuItem;

    //Required by the Windows Form Designer
		protected override void Dispose(bool disposing)
		{
			if (disposing) {
				if (components != null) {
					components.Dispose();
				}
			}
			base.Dispose(disposing);
		}
		
		/// <summary>
		/// This method is required for Windows Forms designer support.
		/// Do not change the method contents inside the source code editor. The Forms designer might
	private void InitializeComponent()
	{
		this.components = new System.ComponentModel.Container();
		this.FlowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
		this.Button2 = new System.Windows.Forms.Button();
		this.Button3 = new System.Windows.Forms.Button();
		this.Button4 = new System.Windows.Forms.Button();
		this.wrapContentsCheckBox = new System.Windows.Forms.CheckBox();
		this.flowTopDownBtn = new System.Windows.Forms.RadioButton();
		this.flowBottomUpBtn = new System.Windows.Forms.RadioButton();
		this.flowLeftToRight = new System.Windows.Forms.RadioButton();
		this.flowRightToLeftBtn = new System.Windows.Forms.RadioButton();
		this.menuStrip1 = new System.Windows.Forms.MenuStrip();
		this.dateiToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.öffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.neuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.speichernToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.xmlToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.xMLNeuToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.xMLÖffnenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.xMLEditierenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.ansichtToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.neueBilderSchiebenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
		this.listBox1 = new System.Windows.Forms.ListBox();
		this.flowLayoutPanel2 = new System.Windows.Forms.Panel();
		this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
		this.itemLöschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.bildDrehenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.alleLöschenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.schiebenToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.attrToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.clearItemToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.clearPlaneToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
		this.groupBox1 = new System.Windows.Forms.GroupBox();
		this.btLast = new System.Windows.Forms.Button();
		this.hScrollBar1 = new System.Windows.Forms.HScrollBar();
		this.tbDescr = new System.Windows.Forms.TextBox();
		this.label13 = new System.Windows.Forms.Label();
		this.tbKarte = new System.Windows.Forms.TextBox();
		this.label12 = new System.Windows.Forms.Label();
		this.tbZeit = new System.Windows.Forms.TextBox();
		this.label11 = new System.Windows.Forms.Label();
		this.tbTitel = new System.Windows.Forms.TextBox();
		this.label10 = new System.Windows.Forms.Label();
		this.tbID = new System.Windows.Forms.TextBox();
		this.label1 = new System.Windows.Forms.Label();
		this.groupBox2 = new System.Windows.Forms.GroupBox();
		this.label5 = new System.Windows.Forms.Label();
		this.tbFDescr = new System.Windows.Forms.TextBox();
		this.tbPfad = new System.Windows.Forms.TextBox();
		this.label2 = new System.Windows.Forms.Label();
		this.tbFTitel = new System.Windows.Forms.TextBox();
		this.label3 = new System.Windows.Forms.Label();
		this.tbFName = new System.Windows.Forms.TextBox();
		this.label4 = new System.Windows.Forms.Label();
		this.statusStrip1 = new System.Windows.Forms.StatusStrip();
		this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
		this.menuStrip1.SuspendLayout();
		this.contextMenuStrip1.SuspendLayout();
		this.groupBox1.SuspendLayout();
		this.groupBox2.SuspendLayout();
		this.statusStrip1.SuspendLayout();
		this.SuspendLayout();
		// 
		// FlowLayoutPanel1
		// 
		this.FlowLayoutPanel1.AutoScroll = true;
		this.FlowLayoutPanel1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.FlowLayoutPanel1.Location = new System.Drawing.Point(253, 306);
		this.FlowLayoutPanel1.Name = "FlowLayoutPanel1";
		this.FlowLayoutPanel1.Size = new System.Drawing.Size(869, 189);
		this.FlowLayoutPanel1.TabIndex = 0;
		// 
		// Button2
		// 
		this.Button2.Location = new System.Drawing.Point(84, 3);
		this.Button2.Name = "Button2";
		this.Button2.Size = new System.Drawing.Size(75, 23);
		this.Button2.TabIndex = 1;
		this.Button2.Text = "Button2";
		// 
		// Button3
		// 
		this.Button3.Location = new System.Drawing.Point(3, 32);
		this.Button3.Name = "Button3";
		this.Button3.Size = new System.Drawing.Size(75, 23);
		this.Button3.TabIndex = 2;
		this.Button3.Text = "Button3";
		// 
		// Button4
		// 
		this.Button4.Location = new System.Drawing.Point(84, 32);
		this.Button4.Name = "Button4";
		this.Button4.Size = new System.Drawing.Size(75, 23);
		this.Button4.TabIndex = 3;
		this.Button4.Text = "Button4";
		// 
		// wrapContentsCheckBox
		// 
		this.wrapContentsCheckBox.Location = new System.Drawing.Point(656, 513);
		this.wrapContentsCheckBox.Name = "wrapContentsCheckBox";
		this.wrapContentsCheckBox.Size = new System.Drawing.Size(87, 24);
		this.wrapContentsCheckBox.TabIndex = 1;
		this.wrapContentsCheckBox.Text = "Wrap";
		this.wrapContentsCheckBox.CheckedChanged += new System.EventHandler(this.wrapContentsCheckBox_CheckedChanged);
		// 
		// flowTopDownBtn
		// 
		this.flowTopDownBtn.Location = new System.Drawing.Point(749, 513);
		this.flowTopDownBtn.Name = "flowTopDownBtn";
		this.flowTopDownBtn.Size = new System.Drawing.Size(104, 24);
		this.flowTopDownBtn.TabIndex = 2;
		this.flowTopDownBtn.Text = "Flow TopDown";
		this.flowTopDownBtn.CheckedChanged += new System.EventHandler(this.flowTopDownBtn_CheckedChanged);
		// 
		// flowBottomUpBtn
		// 
		this.flowBottomUpBtn.Location = new System.Drawing.Point(916, 513);
		this.flowBottomUpBtn.Name = "flowBottomUpBtn";
		this.flowBottomUpBtn.Size = new System.Drawing.Size(104, 24);
		this.flowBottomUpBtn.TabIndex = 3;
		this.flowBottomUpBtn.Text = "Flow BottomUp";
		this.flowBottomUpBtn.CheckedChanged += new System.EventHandler(this.flowBottomUpBtn_CheckedChanged);
		// 
		// flowLeftToRight
		// 
		this.flowLeftToRight.Location = new System.Drawing.Point(860, 513);
		this.flowLeftToRight.Name = "flowLeftToRight";
		this.flowLeftToRight.Size = new System.Drawing.Size(49, 24);
		this.flowLeftToRight.TabIndex = 4;
		this.flowLeftToRight.Text = "Flow LeftToRight";
		this.flowLeftToRight.CheckedChanged += new System.EventHandler(this.flowLeftToRight_CheckedChanged);
		// 
		// flowRightToLeftBtn
		// 
		this.flowRightToLeftBtn.Location = new System.Drawing.Point(1027, 513);
		this.flowRightToLeftBtn.Name = "flowRightToLeftBtn";
		this.flowRightToLeftBtn.Size = new System.Drawing.Size(96, 24);
		this.flowRightToLeftBtn.TabIndex = 5;
		this.flowRightToLeftBtn.Text = "Flow RightToLeft";
		this.flowRightToLeftBtn.CheckedChanged += new System.EventHandler(this.flowRightToLeftBtn_CheckedChanged);
		// 
		// menuStrip1
		// 
		this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.dateiToolStripMenuItem,
			this.xmlToolStripMenuItem,
			this.ansichtToolStripMenuItem});
		this.menuStrip1.Location = new System.Drawing.Point(0, 0);
		this.menuStrip1.Name = "menuStrip1";
		this.menuStrip1.Size = new System.Drawing.Size(742, 24);
		this.menuStrip1.TabIndex = 6;
		this.menuStrip1.Text = "menuStrip1";
		// 
		// dateiToolStripMenuItem
		// 
		this.dateiToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.öffnenToolStripMenuItem,
			this.neuToolStripMenuItem,
			this.speichernToolStripMenuItem});
		this.dateiToolStripMenuItem.Name = "dateiToolStripMenuItem";
		this.dateiToolStripMenuItem.Size = new System.Drawing.Size(46, 20);
		this.dateiToolStripMenuItem.Text = "Datei";
		// 
		// öffnenToolStripMenuItem
		// 
		this.öffnenToolStripMenuItem.Name = "öffnenToolStripMenuItem";
		this.öffnenToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
		this.öffnenToolStripMenuItem.Text = "öffnen";
		this.öffnenToolStripMenuItem.Click += new System.EventHandler(this.oeffnen_Click);
		// 
		// neuToolStripMenuItem
		// 
		this.neuToolStripMenuItem.Name = "neuToolStripMenuItem";
		this.neuToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
		this.neuToolStripMenuItem.Text = "neu";
		// 
		// speichernToolStripMenuItem
		// 
		this.speichernToolStripMenuItem.Name = "speichernToolStripMenuItem";
		this.speichernToolStripMenuItem.Size = new System.Drawing.Size(125, 22);
		this.speichernToolStripMenuItem.Text = "speichern";
		// 
		// xmlToolStripMenuItem
		// 
		this.xmlToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.xMLNeuToolStripMenuItem,
			this.xMLÖffnenToolStripMenuItem,
			this.xMLEditierenToolStripMenuItem});
		this.xmlToolStripMenuItem.Name = "xmlToolStripMenuItem";
		this.xmlToolStripMenuItem.Size = new System.Drawing.Size(43, 20);
		this.xmlToolStripMenuItem.Text = "XML";
		// 
		// xMLNeuToolStripMenuItem
		// 
		this.xMLNeuToolStripMenuItem.Name = "xMLNeuToolStripMenuItem";
		this.xMLNeuToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
		this.xMLNeuToolStripMenuItem.Text = "XML neu";
		// 
		// xMLÖffnenToolStripMenuItem
		// 
		this.xMLÖffnenToolStripMenuItem.Name = "xMLÖffnenToolStripMenuItem";
		this.xMLÖffnenToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
		this.xMLÖffnenToolStripMenuItem.Text = "XML öffnen";
		this.xMLÖffnenToolStripMenuItem.Click += new System.EventHandler(this.xmlOpen_Click);
		// 
		// xMLEditierenToolStripMenuItem
		// 
		this.xMLEditierenToolStripMenuItem.Name = "xMLEditierenToolStripMenuItem";
		this.xMLEditierenToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
		this.xMLEditierenToolStripMenuItem.Text = "XML editieren";
		// 
		// ansichtToolStripMenuItem
		// 
		this.ansichtToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.neueBilderSchiebenToolStripMenuItem});
		this.ansichtToolStripMenuItem.Name = "ansichtToolStripMenuItem";
		this.ansichtToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
		this.ansichtToolStripMenuItem.Text = "Ansicht";
		// 
		// neueBilderSchiebenToolStripMenuItem
		// 
		this.neueBilderSchiebenToolStripMenuItem.Name = "neueBilderSchiebenToolStripMenuItem";
		this.neueBilderSchiebenToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
		this.neueBilderSchiebenToolStripMenuItem.Text = "neue Bilder schieben";
		this.neueBilderSchiebenToolStripMenuItem.Click += new System.EventHandler(this.neue_Bilder);
		// 
		// listBox1
		// 
		this.listBox1.FormattingEnabled = true;
		this.listBox1.Location = new System.Drawing.Point(22, 27);
		this.listBox1.Name = "listBox1";
		this.listBox1.Size = new System.Drawing.Size(221, 56);
		this.listBox1.TabIndex = 7;
		this.listBox1.SelectedIndexChanged += new System.EventHandler(this.selListbox);
		// 
		// flowLayoutPanel2
		// 
		this.flowLayoutPanel2.AutoScroll = true;
		this.flowLayoutPanel2.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
		this.flowLayoutPanel2.ContextMenuStrip = this.contextMenuStrip1;
		this.flowLayoutPanel2.Location = new System.Drawing.Point(253, 27);
		this.flowLayoutPanel2.Name = "flowLayoutPanel2";
		this.flowLayoutPanel2.Size = new System.Drawing.Size(869, 266);
		this.flowLayoutPanel2.TabIndex = 8;
		// 
		// contextMenuStrip1
		// 
		this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.itemLöschenToolStripMenuItem,
			this.bildDrehenToolStripMenuItem,
			this.alleLöschenToolStripMenuItem,
			this.schiebenToolStripMenuItem,
			this.attrToolStripMenuItem});
		this.contextMenuStrip1.Name = "contextMenuStrip1";
		this.contextMenuStrip1.Size = new System.Drawing.Size(186, 114);
		// 
		// itemLöschenToolStripMenuItem
		// 
		this.itemLöschenToolStripMenuItem.Name = "itemLöschenToolStripMenuItem";
		this.itemLöschenToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
		this.itemLöschenToolStripMenuItem.Text = "Item löschen";
		this.itemLöschenToolStripMenuItem.Click += new System.EventHandler(this.itemloeschen_Click);
		// 
		// bildDrehenToolStripMenuItem
		// 
		this.bildDrehenToolStripMenuItem.Name = "bildDrehenToolStripMenuItem";
		this.bildDrehenToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
		this.bildDrehenToolStripMenuItem.Text = "Bild drehen";
		this.bildDrehenToolStripMenuItem.Click += new System.EventHandler(this.picbox_Flip);
		// 
		// alleLöschenToolStripMenuItem
		// 
		this.alleLöschenToolStripMenuItem.Name = "alleLöschenToolStripMenuItem";
		this.alleLöschenToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
		this.alleLöschenToolStripMenuItem.Text = "alle löschen";
		this.alleLöschenToolStripMenuItem.Click += new System.EventHandler(this.alleloeschen_Click);
		// 
		// schiebenToolStripMenuItem
		// 
		this.schiebenToolStripMenuItem.Name = "schiebenToolStripMenuItem";
		this.schiebenToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
		this.schiebenToolStripMenuItem.Text = "schieben nach rechts";
		this.schiebenToolStripMenuItem.Click += new System.EventHandler(this.schieben_Click);
		// 
		// attrToolStripMenuItem
		// 
		this.attrToolStripMenuItem.Name = "attrToolStripMenuItem";
		this.attrToolStripMenuItem.Size = new System.Drawing.Size(185, 22);
		this.attrToolStripMenuItem.Text = "Eigenschaften";
		this.attrToolStripMenuItem.Visible = false;
		this.attrToolStripMenuItem.Click += new System.EventHandler(this.att_Click);
		// 
		// clearItemToolStripMenuItem
		// 
		this.clearItemToolStripMenuItem.Name = "clearItemToolStripMenuItem";
		this.clearItemToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
		// 
		// clearPlaneToolStripMenuItem
		// 
		this.clearPlaneToolStripMenuItem.Name = "clearPlaneToolStripMenuItem";
		this.clearPlaneToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
		// 
		// groupBox1
		// 
		this.groupBox1.Controls.Add(this.btLast);
		this.groupBox1.Controls.Add(this.hScrollBar1);
		this.groupBox1.Controls.Add(this.tbDescr);
		this.groupBox1.Controls.Add(this.label13);
		this.groupBox1.Controls.Add(this.tbKarte);
		this.groupBox1.Controls.Add(this.label12);
		this.groupBox1.Controls.Add(this.tbZeit);
		this.groupBox1.Controls.Add(this.label11);
		this.groupBox1.Controls.Add(this.tbTitel);
		this.groupBox1.Controls.Add(this.label10);
		this.groupBox1.Controls.Add(this.tbID);
		this.groupBox1.Controls.Add(this.label1);
		this.groupBox1.Location = new System.Drawing.Point(25, 96);
		this.groupBox1.Name = "groupBox1";
		this.groupBox1.Size = new System.Drawing.Size(218, 243);
		this.groupBox1.TabIndex = 9;
		this.groupBox1.TabStop = false;
		this.groupBox1.Text = "Beschreibung Etappen:";
		// 
		// btLast
		// 
		this.btLast.Location = new System.Drawing.Point(180, 19);
		this.btLast.Name = "btLast";
		this.btLast.Size = new System.Drawing.Size(29, 20);
		this.btLast.TabIndex = 36;
		this.btLast.Text = ">>";
		this.btLast.UseVisualStyleBackColor = true;
		this.btLast.Click += new System.EventHandler(this.btLast_Click);
		// 
		// hScrollBar1
		// 
		this.hScrollBar1.LargeChange = 5;
		this.hScrollBar1.Location = new System.Drawing.Point(119, 18);
		this.hScrollBar1.Minimum = 1;
		this.hScrollBar1.Name = "hScrollBar1";
		this.hScrollBar1.ScaleScrollBarForDpiChange = false;
		this.hScrollBar1.Size = new System.Drawing.Size(55, 20);
		this.hScrollBar1.TabIndex = 35;
		this.hScrollBar1.Value = 1;
		//this.hScrollBar1.ValueChanged += new System.EventHandler(this.doScroll);
		// 
		// tbDescr
		// 
		this.tbDescr.Location = new System.Drawing.Point(62, 118);
		this.tbDescr.Multiline = true;
		this.tbDescr.Name = "tbDescr";
		this.tbDescr.Size = new System.Drawing.Size(147, 119);
		this.tbDescr.TabIndex = 34;
		//this.tbDescr.Leave += new System.EventHandler(this.textChanged);
		// 
		// label13
		// 
		this.label13.Location = new System.Drawing.Point(9, 120);
		this.label13.Name = "label13";
		this.label13.Size = new System.Drawing.Size(47, 20);
		this.label13.TabIndex = 33;
		this.label13.Text = "Text";
		this.label13.TextAlign = System.Drawing.ContentAlignment.TopRight;
		// 
		// tbKarte
		// 
		this.tbKarte.Location = new System.Drawing.Point(62, 92);
		this.tbKarte.Name = "tbKarte";
		this.tbKarte.Size = new System.Drawing.Size(147, 20);
		this.tbKarte.TabIndex = 32;
		//this.tbKarte.Leave += new System.EventHandler(this.textChanged);
		// 
		// label12
		// 
		this.label12.Location = new System.Drawing.Point(9, 95);
		this.label12.Name = "label12";
		this.label12.Size = new System.Drawing.Size(47, 20);
		this.label12.TabIndex = 31;
		this.label12.Text = "KarteID";
		this.label12.TextAlign = System.Drawing.ContentAlignment.TopRight;
		// 
		// tbZeit
		// 
		this.tbZeit.Location = new System.Drawing.Point(62, 66);
		this.tbZeit.Name = "tbZeit";
		this.tbZeit.Size = new System.Drawing.Size(147, 20);
		this.tbZeit.TabIndex = 30;
		//this.tbZeit.Leave += new System.EventHandler(this.textChanged);
		// 
		// label11
		// 
		this.label11.Location = new System.Drawing.Point(9, 68);
		this.label11.Name = "label11";
		this.label11.Size = new System.Drawing.Size(47, 20);
		this.label11.TabIndex = 29;
		this.label11.Text = "Zeit";
		this.label11.TextAlign = System.Drawing.ContentAlignment.TopRight;
		// 
		// tbTitel
		// 
		this.tbTitel.Location = new System.Drawing.Point(62, 40);
		this.tbTitel.Name = "tbTitel";
		this.tbTitel.Size = new System.Drawing.Size(147, 20);
		this.tbTitel.TabIndex = 28;
		//this.tbTitel.Leave += new System.EventHandler(this.textChanged);
		// 
		// label10
		// 
		this.label10.Location = new System.Drawing.Point(9, 42);
		this.label10.Name = "label10";
		this.label10.Size = new System.Drawing.Size(47, 20);
		this.label10.TabIndex = 27;
		this.label10.Text = "Titel";
		this.label10.TextAlign = System.Drawing.ContentAlignment.TopRight;
		// 
		// tbID
		// 
		this.tbID.Enabled = false;
		this.tbID.Location = new System.Drawing.Point(62, 16);
		this.tbID.Name = "tbID";
		this.tbID.Size = new System.Drawing.Size(54, 20);
		this.tbID.TabIndex = 1;
		// 
		// label1
		// 
		this.label1.Location = new System.Drawing.Point(9, 18);
		this.label1.Name = "label1";
		this.label1.Size = new System.Drawing.Size(47, 20);
		this.label1.TabIndex = 0;
		this.label1.Text = "ID";
		this.label1.TextAlign = System.Drawing.ContentAlignment.TopRight;
		// 
		// groupBox2
		// 
		this.groupBox2.Controls.Add(this.label5);
		this.groupBox2.Controls.Add(this.tbFDescr);
		this.groupBox2.Controls.Add(this.tbPfad);
		this.groupBox2.Controls.Add(this.label2);
		this.groupBox2.Controls.Add(this.tbFTitel);
		this.groupBox2.Controls.Add(this.label3);
		this.groupBox2.Controls.Add(this.tbFName);
		this.groupBox2.Controls.Add(this.label4);
		this.groupBox2.Location = new System.Drawing.Point(25, 345);
		this.groupBox2.Name = "groupBox2";
		this.groupBox2.Size = new System.Drawing.Size(218, 171);
		this.groupBox2.TabIndex = 10;
		this.groupBox2.TabStop = false;
		this.groupBox2.Text = "Beschreibung Fotos:";
		// 
		// label5
		// 
		this.label5.Location = new System.Drawing.Point(9, 100);
		this.label5.Name = "label5";
		this.label5.Size = new System.Drawing.Size(47, 20);
		this.label5.TabIndex = 34;
		this.label5.Text = "Text";
		this.label5.TextAlign = System.Drawing.ContentAlignment.TopRight;
		// 
		// tbFDescr
		// 
		this.tbFDescr.Location = new System.Drawing.Point(62, 97);
		this.tbFDescr.Multiline = true;
		this.tbFDescr.Name = "tbFDescr";
		this.tbFDescr.Size = new System.Drawing.Size(147, 74);
		this.tbFDescr.TabIndex = 35;
		// 
		// tbPfad
		// 
		this.tbPfad.Location = new System.Drawing.Point(62, 19);
		this.tbPfad.Name = "tbPfad";
		this.tbPfad.Size = new System.Drawing.Size(147, 20);
		this.tbPfad.TabIndex = 36;
		this.tbPfad.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
		// 
		// label2
		// 
		this.label2.Location = new System.Drawing.Point(9, 21);
		this.label2.Name = "label2";
		this.label2.Size = new System.Drawing.Size(47, 18);
		this.label2.TabIndex = 35;
		this.label2.Text = "Pfad";
		this.label2.TextAlign = System.Drawing.ContentAlignment.TopRight;
		// 
		// tbFTitel
		// 
		this.tbFTitel.Location = new System.Drawing.Point(62, 71);
		this.tbFTitel.Name = "tbFTitel";
		this.tbFTitel.Size = new System.Drawing.Size(147, 20);
		this.tbFTitel.TabIndex = 34;
		//this.tbFTitel.Leave += new System.EventHandler(this.textChanged);
		// 
		// label3
		// 
		this.label3.Location = new System.Drawing.Point(9, 74);
		this.label3.Name = "label3";
		this.label3.Size = new System.Drawing.Size(47, 18);
		this.label3.TabIndex = 33;
		this.label3.Text = "Titel";
		this.label3.TextAlign = System.Drawing.ContentAlignment.TopRight;
		// 
		// tbFName
		// 
		this.tbFName.Location = new System.Drawing.Point(62, 45);
		this.tbFName.Name = "tbFName";
		this.tbFName.Size = new System.Drawing.Size(147, 20);
		this.tbFName.TabIndex = 32;
		this.tbFName.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
		//this.tbFName.Leave += new System.EventHandler(this.textChanged);
		// 
		// label4
		// 
		this.label4.Location = new System.Drawing.Point(9, 47);
		this.label4.Name = "label4";
		this.label4.Size = new System.Drawing.Size(47, 18);
		this.label4.TabIndex = 31;
		this.label4.Text = "Name";
		this.label4.TextAlign = System.Drawing.ContentAlignment.TopRight;
		// 
		// statusStrip1
		// 
		this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
			this.toolStripStatusLabel1});
		this.statusStrip1.Location = new System.Drawing.Point(0, 443);
		this.statusStrip1.Name = "statusStrip1";
		this.statusStrip1.Size = new System.Drawing.Size(742, 22);
		this.statusStrip1.TabIndex = 11;
		this.statusStrip1.Text = "statusStrip1";
		// 
		// toolStripStatusLabel1
		// 
		this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
		this.toolStripStatusLabel1.Size = new System.Drawing.Size(118, 17);
		this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
		// 
		// MainForm
		// 
		this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
		this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
		this.ClientSize = new System.Drawing.Size(742, 465);
		this.Controls.Add(this.statusStrip1);
		this.Controls.Add(this.groupBox2);
		this.Controls.Add(this.groupBox1);
		this.Controls.Add(this.flowLayoutPanel2);
		this.Controls.Add(this.listBox1);
		this.Controls.Add(this.flowRightToLeftBtn);
		this.Controls.Add(this.flowLeftToRight);
		this.Controls.Add(this.flowBottomUpBtn);
		this.Controls.Add(this.flowTopDownBtn);
		this.Controls.Add(this.wrapContentsCheckBox);
		this.Controls.Add(this.FlowLayoutPanel1);
		this.Controls.Add(this.menuStrip1);
		this.MainMenuStrip = this.menuStrip1;
		this.Name = "MainForm";
		this.Text = "Beschreibung Etappen/Abschnitte/Phasen";
		this.menuStrip1.ResumeLayout(false);
		this.menuStrip1.PerformLayout();
		this.contextMenuStrip1.ResumeLayout(false);
		this.groupBox1.ResumeLayout(false);
		this.groupBox1.PerformLayout();
		this.groupBox2.ResumeLayout(false);
		this.groupBox2.PerformLayout();
		this.statusStrip1.ResumeLayout(false);
		this.statusStrip1.PerformLayout();
		this.ResumeLayout(false);
		this.PerformLayout();

	}// 

		}

	}
