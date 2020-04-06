/*
 * Created by SharpDevelop.
 * User: Eckhard
 * Date: 31.03.2020
 * Time: 16:24
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Drawing;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Collections.Generic;

namespace flow
{
	/// <summary>
	/// Description of Etappe.
	/// </summary>
	public partial class Etappe : Form
	{
		public Etappe()
		{
			//
			// The InitializeComponent() call is required for Windows Forms designer support.
			//
			InitializeComponent();
			
			//
			// TODO: Add constructor code after the InitializeComponent() call.
			//
		}
		
		IEnumerable<XElement> itemsID = flow.MainForm.itemsID;
		XElement xTree = flow.MainForm.xTree;
		
		private Form getMain(){
		foreach (Form form in Application.OpenForms)
        {
            if (form.GetType() == typeof(MainForm))
            {
                return form;
            }
        }
		return null;
		}
		
		
		private void Form_activated(object sender, EventArgs e){
        this.listBox1.MultiColumn = true;
        List<dynamic> dynList = new List<dynamic>() { };
		foreach (XElement myX in xTree.Descendants("etappe")){
			Program.dbg(myX.ToString());
		    dynList.Add( 
			            new List<dynamic>{ myX.Element("ID").Value, myX.Element("Titel").Value }
			) ;
        }
        this.listBox1.DataSource = dynList;
	}
		
		private void btOK_Click(object sender, EventArgs e) {
			Program.dbg(sender.ToString());
			foreach (char x in tbID.Text){
				if (!Char.IsDigit(x)){
					MessageBox.Show("Nur ganze Zahlen möglich!");
					return;
				} else {
					// prüfen, ob ID schon existiert:
					foreach (List<dynamic> element in listBox1.Items) {
						if (element[0] == tbID.Text){
							MessageBox.Show("ID existiert bereits!");
							return;
						}
					}
					// in MainForm.tbID einsetzen
					Form myF = getMain();
					lblFehler.Text = "";
					((MainForm)myF).setID(this.tbID.Text);
					//this.Dispose();
				}
			}
		}
		
		private void btCancel_Click(object sender, EventArgs e) {
			Program.dbg(sender.ToString());
			this.Dispose();
		}
}
}
