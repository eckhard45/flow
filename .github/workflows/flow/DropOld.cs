/*
 * Created by SharpDevelop.
 * User: Eckhard
 * Date: 12.03.2020
 * Time: 13:12
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Diagnostics;
using System.Windows.Forms;

namespace flow
{
	partial class MainForm
	{
      //  private pictBox picbox3;	// die pictBox'en in flowpanel2 zum schieben
	

    // Handler für picBoxes in Panel2
    private void pictBox2_MouseDown(object sender, MouseEventArgs e)
    {
	pictBox  pb = (pictBox)sender;
	Debug.WriteLine("down pb2: " + pb.Datei);
	if (e.Button == MouseButtons.Left) {
	 	pb.Location = new Point(pb.Left + 80, pb.Top+100);
	} if (e.Button == MouseButtons.Right) {
		if ((pb.Left - 80) > 0 && (pb.Top-100) > 0)
	 	pb.Location = new Point(pb.Left - 80, pb.Top-100);
	}
		/***********
        if (img == null) return;
	if (wasDropped) {
		dist +=5;
    	picbox3 = new pictBox(pb.Tag.ToString(), "picbox2_" + dist.ToString());
		picbox3.Name = "picbox2_" + dist.ToString();
		picbox3.Size = new System.Drawing.Size(80, 100);
		picbox3.SizeMode = PictureBoxSizeMode.StretchImage;
		picbox3.ContextMenu = this.ContextMenu;
	    picbox3.Click += new EventHandler(picbox2_MouseClickUp);
		this.picbox3.ContextMenuStrip = this.contextMenuStrip1;
	    //pb.DragEnter += new DragEventHandler(pictureBox3_DragEnter);
	    //pb.DragDrop += new DragEventHandler(pictureBox3_DragDrop);
		*************/
    }

void pictureBox3_DragEnter(object sender, DragEventArgs e) {
	pictBox pb = (pictBox)sender;
	Debug.WriteLine("Enter: " + pb.Name);
	if (e.Data.GetDataPresent(pb.DataFormat)){
		e.Data.GetDataPresent(DataFormats.StringFormat);
        e.Effect = DragDropEffects.Copy;
        Program.dbg("DragEnter");
	}
        Debug.WriteLine("ccEnterX2: " + e.X +"," + e.Y);
    }

void pictureBox3_DragDrop(object sender, DragEventArgs e) {
	pictBox pb = (pictBox)sender;
	Debug.WriteLine("Drop: " + pb.Name);
    wasDropped = true;
	pb.Image = img;
	Program.dbg(pb.Image.ToString());
	pb.Datei = (string)e.Data.GetData(DataFormats.StringFormat);
	Program.dbg(pb.Datei.ToString());
}
		
	}
}
