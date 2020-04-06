/*
 * Created by SharpDevelop.
 * User: Eckhard
 * Date: 31.03.2020
 * Time: 16:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
namespace flow
{
	partial class Etappe
	{
		/// <summary>
		/// Designer variable used to keep track of non-visual components.
		/// </summary>
		private System.ComponentModel.IContainer components = null;
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.ListBox listBox1;
		private System.Windows.Forms.Button btOK;
		private System.Windows.Forms.Button btCancel;
		private System.Windows.Forms.StatusStrip statusStrip1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.Label label3;
		private System.Windows.Forms.Label lblFehler;
		private System.Windows.Forms.TextBox tbID;
		
		/// <summary>
		/// Disposes resources used by the form.
		/// </summary>
		/// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
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
		/// not be able to load this method if it was changed manually.
		/// </summary>
		private void InitializeComponent()
		{
			this.label1 = new System.Windows.Forms.Label();
			this.tbID = new System.Windows.Forms.TextBox();
			this.listBox1 = new System.Windows.Forms.ListBox();
			this.btOK = new System.Windows.Forms.Button();
			this.btCancel = new System.Windows.Forms.Button();
			this.statusStrip1 = new System.Windows.Forms.StatusStrip();
			this.label2 = new System.Windows.Forms.Label();
			this.label3 = new System.Windows.Forms.Label();
			this.lblFehler = new System.Windows.Forms.Label();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.Location = new System.Drawing.Point(38, 40);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(100, 23);
			this.label1.TabIndex = 0;
			this.label1.Text = "neue Etappen ID:";
			// 
			// tbID
			// 
			this.tbID.Location = new System.Drawing.Point(128, 37);
			this.tbID.Name = "tbID";
			this.tbID.Size = new System.Drawing.Size(66, 20);
			this.tbID.TabIndex = 1;
			// 
			// listBox1
			// 
			this.listBox1.FormattingEnabled = true;
			this.listBox1.Location = new System.Drawing.Point(31, 90);
			this.listBox1.MultiColumn = true;
			this.listBox1.Name = "listBox1";
			this.listBox1.ScrollAlwaysVisible = true;
			this.listBox1.Size = new System.Drawing.Size(179, 147);
			this.listBox1.TabIndex = 3;
			// 
			// btOK
			// 
			this.btOK.Location = new System.Drawing.Point(271, 71);
			this.btOK.Name = "btOK";
			this.btOK.Size = new System.Drawing.Size(87, 31);
			this.btOK.TabIndex = 4;
			this.btOK.Text = "OK";
			this.btOK.UseVisualStyleBackColor = true;
			this.btOK.Click += new System.EventHandler(this.btOK_Click);
			// 
			// btCancel
			// 
			this.btCancel.Location = new System.Drawing.Point(271, 118);
			this.btCancel.Name = "btCancel";
			this.btCancel.Size = new System.Drawing.Size(86, 34);
			this.btCancel.TabIndex = 5;
			this.btCancel.Text = "abbrechen";
			this.btCancel.UseVisualStyleBackColor = true;
			this.btCancel.Click += new System.EventHandler(this.btCancel_Click);
			// 
			// statusStrip1
			// 
			this.statusStrip1.Location = new System.Drawing.Point(0, 240);
			this.statusStrip1.Name = "statusStrip1";
			this.statusStrip1.Size = new System.Drawing.Size(418, 22);
			this.statusStrip1.TabIndex = 6;
			this.statusStrip1.Text = "statusStrip1";
			// 
			// label2
			// 
			this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label2.Location = new System.Drawing.Point(18, 6);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(388, 25);
			this.label2.TabIndex = 7;
			this.label2.Text = "Wähle eine neue ID in der Abfolge der vorhandenen";
			// 
			// label3
			// 
			this.label3.Location = new System.Drawing.Point(31, 70);
			this.label3.Name = "label3";
			this.label3.Size = new System.Drawing.Size(100, 19);
			this.label3.TabIndex = 8;
			this.label3.Text = "existierende IDs:";
			// 
			// lblFehler
			// 
			this.lblFehler.AllowDrop = true;
			this.lblFehler.Location = new System.Drawing.Point(253, 31);
			this.lblFehler.Name = "lblFehler";
			this.lblFehler.Size = new System.Drawing.Size(104, 32);
			this.lblFehler.TabIndex = 9;
			// 
			// Etappe
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.ClientSize = new System.Drawing.Size(418, 262);
			this.Controls.Add(this.lblFehler);
			this.Controls.Add(this.label3);
			this.Controls.Add(this.label2);
			this.Controls.Add(this.statusStrip1);
			this.Controls.Add(this.btCancel);
			this.Controls.Add(this.btOK);
			this.Controls.Add(this.listBox1);
			this.Controls.Add(this.tbID);
			this.Controls.Add(this.label1);
			this.Name = "Etappe";
			this.Text = "neu Etappe anlegen";
			this.Activated += new System.EventHandler(this.Form_activated);
			this.ResumeLayout(false);
			this.PerformLayout();

		}
	}
}
