/*
 * Created by SharpDevelop.
 * User: Eckhard
 * Date: 23.02.2020
 * Time: 16:02
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */
using System;
using System.Collections.Generic;
using System.Collections;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Linq;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Reflection;
using System.IO;
using System.Text;
namespace flow
{
	/// <summary>
	/// Description of MainForm.
	/// </summary>
    
	public  partial class MainForm : Form
	{
		private string arbeitsverzeichnis = "";
		private string XMLfile = "";
		private bool up = true;	// die Richtung, in die gescrollt wurde
		private Point dist = new Point(3,3);
		private int nr = 1;
        private PictureBox picbox;	// die PictureBox'en in flowpanel1
        private pictBox picbox2;	// die pictBox'en in flowpanel2
        private pictBox actPicBox;	// die fokussierte pictBox in flowpanel2
        private pictBox movingPB;	// die zu verschiebende picBox
        private bool picBsChanged;	// eine der pictBox wurde geändert
        private Image img;		//das Image, das mit drag-drop transportiert wird
        private bool wasDropped = true;
        private Point neueLoc = new Point(0,0); // pictBox.Location vor Verschieben
        private Point alteLoc = new Point(0,0);	// nach Verschieben
	    private string strID = "1"; 	// aktuell angezeigte ID einer <row>/<etappe>
	    private int nextID;				// beim Scrollen (vor oder zurück) nächste ID
	    private string firstID = "0";
	    private string lastID = "10";
	    public static System.Xml.Linq.XElement xTree = null;
		public static IEnumerable<XElement> itemsID = null;	// aktuelle XML für Etappe mit strID
		private XElement fotos;			// Fotos einer Etapppe
		private bool geaendert = false;	// Änderungen haben stattgefunden

		
		public MainForm()
		{
		InitializeComponent();
		}

    private void wrapContentsCheckBox_CheckedChanged(
        System.Object sender, 
        System.EventArgs e)
    {
        this.FlowLayoutPanel1.WrapContents = 
            this.wrapContentsCheckBox.Checked;
    }

    private void flowTopDownBtn_CheckedChanged(
        System.Object sender, 
        System.EventArgs e)
    {
        this.FlowLayoutPanel1.FlowDirection = FlowDirection.TopDown;
    }

    private void flowBottomUpBtn_CheckedChanged(
        System.Object sender, 
        System.EventArgs e)
    {
        this.FlowLayoutPanel1.FlowDirection = FlowDirection.BottomUp;
    }

    private void flowLeftToRight_CheckedChanged(
        System.Object sender, 
        System.EventArgs e)
    {
        this.FlowLayoutPanel1.FlowDirection = FlowDirection.LeftToRight;
    }

    private void flowRightToLeftBtn_CheckedChanged(
        System.Object sender, 
        System.EventArgs e)
    {
        this.FlowLayoutPanel1.FlowDirection = FlowDirection.RightToLeft;
    }
		
private void xmlOpen_Click(object sender, EventArgs e){
	Program.dbg("xmlOpen_Click: ");
    //openFileDialog1.Multiselect = true ;
    openFileDialog1.InitialDirectory = Application.ExecutablePath;
    if(openFileDialog1.ShowDialog() == DialogResult.OK)
    {
		this.toolStripStatusLabel1.Text =  openFileDialog1.FileName + " gelesen" ;  
		arbeitsverzeichnis = Path.GetDirectoryName(openFileDialog1.FileName);
		Program.dbg("Verz: " + arbeitsverzeichnis);
		XMLfile = openFileDialog1.FileName;
		readXML(openFileDialog1.FileName);
		this.toolStripStatusLabel1.Text = "geöffnet: " + openFileDialog1.FileName  ;
		}
}
		
private void readXML (string filename)
    {
   // Create and load the XML document.
   // XmlDocument doc = new XmlDocument();
   // doc.Load("xTree.xml");

    // Create an XmlNodeReader using the XML document.
    //XmlNodeReader nodeReader = new XmlNodeReader(doc);

    // Set the validation settings on the XmlReaderSettings object.
    XmlReaderSettings settings = new XmlReaderSettings();
    settings.ValidationType = ValidationType.Schema;
    settings.ValidationEventHandler += new ValidationEventHandler (ValidationCallBack);
   xTree = new XElement("root","");
   // Parse the XML file.
	try{
	xTree = XElement.Load(filename);
	} catch (Exception evt) {
    	this.toolStripStatusLabel1.Text = evt.Message + "\nenthält keine XML Daten";
    	return;
    } 
	keineEingaben();		// alle Leave-Handler und hscrollbar deaktivieren
   this.toolStripStatusLabel1.Text =  " xTree gelesen" ;
	sortEtappen();
	XElement lastelem = xTree.Descendants("etappe").Last();
	strID = lastelem.Element("ID").Value;
	lastID = strID;
	XElement firstelem = xTree.Descendants().First();
	strID = firstelem.Element("ID").Value;
	tbID.Text = strID;
	int i = int.Parse(strID);
	hScrollBar1.Value = i;
	btFirst_Click(null,null);	
	alleEingaben();	// alle Leave-Handler und hscrollbar setzen

}

  
// Display any validation errors.
private static void ValidationCallBack(object sender, ValidationEventArgs e) {
    MessageBox.Show("Validation Error: {0}", e.Message);
}    
		
        // Find an image.
        private void oeffnen_Click (object sender, System.EventArgs e)
        {
            openFileDialog1.Multiselect = true ;
            if(openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                if (openFileDialog1.FileNames != null)
                {
                    for(int i =0 ; i < openFileDialog1.FileNames.Length ; i++ )
                    {
                       try {
                    		addImage(openFileDialog1.FileNames[i]);
                    		this.toolStripStatusLabel1.Text = "geöffnet: " + openFileDialog1.FileNames[i]  ;
			        	} catch(OutOfMemoryException evt) {
		            		MessageBox.Show(evt.Message);
		            	}
 
                    }
                 	 this.toolStripStatusLabel1.Text =  openFileDialog1.FileNames.Length + " Dateien gelesen" ;  
                }
                else
                {
                    addImage(openFileDialog1.FileName);
 		        	this.toolStripStatusLabel1.Text = "geöffnet: " + openFileDialog1.FileName  ;
               }

            }
        }
        
        
    private void addImage(string imageToLoad)
    {
        if (imageToLoad != "")
        {
			/************
        	foreach (Control ctrl in FlowLayoutPanel1.Controls) {
            	Debug.WriteLine(ctrl.Name);
        	}
        	**************/
			picbox = new PictureBox();
			picbox.Name = "pb_" + imageToLoad.Substring(imageToLoad.Length-9);
			picbox.Size = new System.Drawing.Size(80, 100);
			picbox.SizeMode = PictureBoxSizeMode.StretchImage;
			
			img = (Bitmap)Bitmap.FromFile(imageToLoad);
			picbox.Image = img;
			picbox.Tag = imageToLoad;
			picbox.AllowDrop = true;
			wasDropped = true;
			picbox.MouseDown += new MouseEventHandler(picturebox_MouseDown);
			this.FlowLayoutPanel1.Controls.Add(picbox);
        }
    }
	// von Form etappe gerufen
    public  void setID(string toSet){
    	//tbID.Enabled = true;
    	tbID.Text = toSet;
    	alleloeschen_Click(null, null);	// löscht nur picBox-Einträge
    	tbTitel.Text = "neue Etappe";
    	tbZeit.Text = "";
    	tbKarte.Text = "";
    	tbDescr.Text = "";
    	hScrollBar1.Value = int.Parse(toSet);
    	alleEingaben();
    	Activate();
    }
    
// Handler für PictureBoxes in Panel1    
private void picturebox_MouseDown(System.Object sender, MouseEventArgs  e){
	PictureBox pb = (PictureBox)sender;
	Debug.WriteLine("down: " + pb.Tag);
        img = pb.Image;
        if (img == null) return;
        DoDragDrop(pb.Tag, DragDropEffects.Copy);
	if (wasDropped) {
    	picbox2 = machNeuePB(pb.Tag.ToString(), "picbox2_neu", false);
    	picbox2.Name = "picbox2_" + (nr*10).ToString();
    	picbox2.Location = neueLoc;
		this.flowLayoutPanel2.Controls.Add(picbox2);
		nr++;
	    wasDropped = false;
	}
}
    
private void picbox2_MouseClickUp(System.Object sender, EventArgs  e){
	pictBox pb = (pictBox)sender;
	Debug.WriteLine("picbox2_MouseClickUp: " + pb.Titel + "\t" + pb.TabIndex.ToString());
	picbox_Click(pb, flowLayoutPanel2);
	if (pb.Datei.Length>25)
		this.tbPfad.Text = "..." + pb.Datei.Substring(pb.Datei.Length-25);
	else this.tbPfad.Text = pb.Datei;
	this.tbFTitel.Text = pb.Titel;
	this.tbFName.Text = pb.Name;
	this.tbFDescr.Text = pb.Descr;
    pb.MouseDown += new MouseEventHandler(pictBox2_MouseDown);
}

void pictureBox2_DragEnter(object sender, DragEventArgs e) {
	pictBox pb = (pictBox)sender;
	Debug.WriteLine("Enter: " + pb.Name);
//	if (e.Data.GetDataPresent(pb.DataFormat)){
	e.Data.GetDataPresent(DataFormats.StringFormat);
        e.Effect = DragDropEffects.Copy;
        Debug.WriteLine("Enter: " + e.X +"," + e.Y);
//	} else {
//        Debug.WriteLine("EnterElse: " + e.X +"," + e.Y);
//	}
}


    private void selListbox(object sender, EventArgs e){
    	ListBox lb = (ListBox)sender;
    	Debug.WriteLine("selList: " + sender.ToString());
    	foreach (pictBox ctrl in flowLayoutPanel2.Controls) {
    		
    		if ((ctrl.Datei != null)
    		    	&& (ctrl.Datei.ToString() == lb.SelectedItem.ToString())
    		    	&& (ctrl.Image != null)) {
    			picbox_Click((pictBox)ctrl, flowLayoutPanel2);
    		}
    	}
    }
    
private void picbox_Click(pictBox pb, Panel fp )
{ 
	Debug.WriteLine("selected: " + pb.Datei);
	foreach (Control ctrl in fp.Controls) {
		if (ctrl.GetType() == typeof(pictBox)) {
		    	((pictBox)ctrl).BorderStyle = BorderStyle.None;
		    	((pictBox)ctrl).Padding = new Padding(0);
		    	((pictBox)ctrl).BackColor = Color.Transparent;
			    ((pictBox)ctrl).MouseDown -= new MouseEventHandler(pictBox2_MouseDown);
		}
	}
	pb.Select();
	pb.BorderStyle = BorderStyle.Fixed3D;
	pb.BackColor = System.Drawing.Color.Blue;
	pb.Padding = new Padding(4);
	actPicBox = pb;
	this.tbPfad.Text = actPicBox.Datei;
	this.tbFDescr.Text = actPicBox.Descr;
	this.tbFTitel.Text = actPicBox.Titel;
	this.tbFName.Text = actPicBox.Name;
	Program.dbg(pb.Datei);
}

// nicht aufgerufen:
private void textChanged(object sender, EventArgs e)
{
    ((TextBox)sender).Tag = "true" ; //true: die TextBoxen wurde geändert - 
									//alle programmgesteuerten Änderungen setzen wieder auf "false"
		switch (((TextBox)sender).Name) {
		case "tbID":
			this.tbID.Tag = "true";
			break;
		case "tbTitel":
			this.tbTitel.Tag = "true";
			break;
		case "tbZeit":
			this.tbZeit.Tag = "true";
			break;
		case "tbKarte":
			this.tbKarte.Tag = "true";
			break;
		case "tbDescr":
			this.tbDescr.Tag = "true";
			break;
		case "tbFName":
			actPicBox.Name = this.tbFName.Text;
			break;
		case "tbFTitel":
			actPicBox.Titel = this.tbFTitel.Text;
			break;
		case "tbFDescr":
			actPicBox.Descr = this.tbFDescr.Text ; 
			break;
		default:
			this.tbFName.Text = "";
			this.tbFTitel.Text = "";
			this.tbFDescr.Text = "";
			break;
	}
	picBsChanged = true;
}

private void alleAufNeu(bool mitLoeschen = false) {
	if (mitLoeschen){
		tbTitel.Text = "";
		tbZeit.Text = "";
		tbKarte.Tag = "";
		tbDescr.Text = "";
		
		tbFName.Tag = ""; 
		tbFTitel.Tag = ""; 
	}
		picBsChanged = false;
		geaendert = false;
}

void IDchanged(object sender, EventArgs e){
	string sStr = ((TextBox)sender).Text;
	Program.dbg(((TextBox)sender).Name);
	geaendert = true;
	picBsChanged = true;
	// Texte der Fotos müssen in die picBoxes geschrieben werden:
	foreach (pictBox pb in flowLayoutPanel2.Controls) {
		if (pb.BackColor == Color.Blue) {
			pb.Descr = this.tbFDescr.Text;
			pb.Titel = this.tbFTitel.Text;
			pb.Name = this.tbFName.Text;
			break;
		}
	}
	this.toolStripStatusLabel1.Text = "geändert ID: " + strID;
}

private int allemalen(IEnumerable<XElement> items){
	int rWert = items.Elements().Count();
	foreach (var foto in items.Elements("foto")) {
		Program.dbg(foto.Name.ToString());
	
	}
	return rWert;
}

private void saveNodeData(string thisID){
	//IEnumerable<XElement> items  = getIDNodes(thisID);

	if (xTree == null){
		xTree = new XElement("root", "");
	}
	XElement xEtappe = makeNewXEtappe(thisID);
	if (!(geaendert || picBsChanged)) return;
		
/**********
	// Etappe hinzufügen oder ersetzen ?
	DialogResult result = new DialogResult();
	if (etappeExist(xEtappe))
		{result = MessageBox.Show("Etappe existiert schon - überschreiben?",
                                   "Etappe existiert", MessageBoxButtons.YesNoCancel );
		switch (result) {
			case DialogResult.Yes:
				break;
			case DialogResult.No:
				return;
			case DialogResult.Cancel:
				return;
		} 
	} else {
**********/	
if (etappeExist(xEtappe)) {	// etappeExist erzeugt ggf. itemsID
	// etappe überschreiben:
	foreach (XElement xelem in xTree.Elements()) {
		if (xelem.Element("ID").Value == thisID) {
			xelem.ReplaceWith(xEtappe);
			continue;	// nur einmal, IDs sind eindeutig
		}
	}
} else { xTree.Add(xEtappe);}
xTree.Save(XMLfile);
picBsChanged = false;
geaendert = false;
}

private bool etappeExist( XElement etappe) {
// input would be your edited XML, this is just sample data to illustrate
string thisID  = etappe.Element("ID").Value;
if (thisID != null && thisID != "") {
	itemsID = from record in xTree.Descendants("etappe")
	        where record.Element("ID").Value.Equals(thisID)
	        select record;	
	int rWert = itemsID.Elements().Count();
	if (rWert>0) return true;
}
return false;
}

void updateFotos() {
	foreach (pictBox ctrl in flowLayoutPanel2.Controls) {
		if (ctrl.Image != null) {
			foreach (XElement elem in fotos.Elements()) {
				if (elem.Element("Pfad").Value == ctrl.Datei) {
					elem.Element("Name").Value = ctrl.Name;
					elem.Element("Titel").Value = ctrl.Titel;
					elem.Element("Desc").Value = ctrl.Descr;
				}
			}
		}
	}
}

/************* aus aktueller Anzeige xEtappe erzeugen:****************/
private XElement makeNewXEtappe(string ID) {
	fotos = new XElement("fotos","");
	foreach (pictBox picbox in flowLayoutPanel2.Controls) {
		if (!(picbox.Image == null || picbox.Name == "Leerbild")) {
			XElement foto = new XElement("foto",
				new XElement("Titel", picbox.Titel),
				new XElement("Name", picbox.Name),
				new XElement("Pfad", picbox.Datei),
				new XElement("Desc", picbox.Descr));
				fotos.Add(foto);
		}
	}
	XElement etappe =  new XElement("etappe",  
        new XElement("ID", ID),   
        new XElement("Zeit", tbZeit.Text),
        new XElement("Titel", tbTitel.Text),
        new XElement("IDKarte", tbKarte.Text),
        new XElement("Descr", tbDescr.Text),
       fotos);
	return etappe;
}

private IEnumerable<XElement> getIDNodes( string thisID){
XElement root = xTree;
// aktuelle XML=itemsID für thisID nutzen, falls vorhanden
if (itemsID !=null) {
	foreach (var element in itemsID.Elements("ID")) {
		if (element.Value == thisID)
		return itemsID;
	}
} 
else { 
	return null;
}
XElement et = new XElement("etappe", "");
itemsID = new List<XElement>();
//itemsID.AppendChild(et);
itemsID = from record in root.Descendants("etappe")
        where record.Element("ID").Value.Equals(thisID)
        select record;	
        
//String str =   PrintXML(itemsID.Elements().);
foreach (var element in itemsID) {
	Program.dbg( element.Name.ToString() );
}
return itemsID;
}


private DialogResult abfrageSichern() {
    string message = "Änderungen speichern ?";
	string caption = "Diese Etappe sichern";
    MessageBoxButtons buttons = MessageBoxButtons.YesNoCancel;
    DialogResult antwort = MessageBox.Show(message, caption, buttons);
    return antwort;
}
private void keineEingaben(){
	this.tbID.Leave -= new System.EventHandler(this.IDchanged);
	this.tbTitel.Leave -= new System.EventHandler(this.IDchanged);
	this.tbZeit.Leave -= new System.EventHandler(this.IDchanged);
	this.tbKarte.Leave -= new System.EventHandler(this.IDchanged);
	this.tbDescr.Leave -= new System.EventHandler(this.IDchanged);
	this.tbFName.Leave -= new System.EventHandler(this.IDchanged);
	this.tbFTitel.Leave -= new System.EventHandler(this.IDchanged);
	this.tbFDescr.Leave -= new System.EventHandler(this.IDchanged);
	this.hScrollBar1.ValueChanged -= new System.EventHandler(this.doScroll);
	this.btLast.Click -= new System.EventHandler(this.btLast_Click);
	this.btFirst.Click -= new System.EventHandler(this.btFirst_Click);
}
private void alleEingaben(){
	this.tbID.Leave += new System.EventHandler(this.IDchanged);
	this.tbTitel.Leave += new System.EventHandler(this.IDchanged);
	this.tbZeit.Leave += new System.EventHandler(this.IDchanged);
	this.tbKarte.Leave += new System.EventHandler(this.IDchanged);
	this.tbDescr.Leave += new System.EventHandler(this.IDchanged);
	this.tbFName.Leave += new System.EventHandler(this.IDchanged);
	this.tbFTitel.Leave += new System.EventHandler(this.IDchanged);
	this.tbFDescr.Leave += new System.EventHandler(this.IDchanged);
	this.hScrollBar1.ValueChanged += new System.EventHandler(this.doScroll);
	this.btLast.Click += new System.EventHandler(this.btLast_Click);
	this.btFirst.Click += new System.EventHandler(this.btFirst_Click);
}
    private bool HasMember(IEnumerable<XElement> Dataset)
    {
        return Dataset != null && Dataset.Any(c=>c!=null);
    }


void doScroll(object sender, EventArgs e)
{
	Debug.WriteLine("Scroll: " + ((System.Windows.Forms.HScrollBar)sender).Value);
	keineEingaben();
	up = false;
	nextID = ((System.Windows.Forms.HScrollBar)sender).Value;
	if (strID == "") { strID = "0"; return;}		// keine Etappe erreichbar
	if (int.Parse(strID) < nextID) up = true;
	if (geaendert || picBsChanged) {
		DialogResult antwort = abfrageSichern();
		if (antwort == DialogResult.Yes) {
			if (strID == "") strID = nextID.ToString();
			saveNodeData(strID);
		}
		if (antwort == DialogResult.Cancel) {
			alleEingaben();
			return;
		}
		if (antwort == DialogResult.No) {
			alleAufNeu(false);
			geaendert = false;
			picBsChanged = false;
		}
	}
	if (nextID.ToString() != this.tbID.Text) {
		setNodeData(nextID.ToString());		// ermittelt mit getNextID() neue strID
	}
	//strID =  nextID.ToString();
	this.toolStripStatusLabel1.Text = "neue ID: " + strID;
	alleEingaben();		// werden wieder registriert
}
    
    
// findet nach Scroll die auf thisID nächste belegte ID 
// entsprechend up = true, down = up = false
// falls ythisID gültige Etappe, wird diese gefunden
private string getNextID(string ythisID, bool up = true){
	int zaehler = int.Parse(ythisID)  ;	// holt die nächste Etappe 
	int rWert = 0;
	XElement root = xTree;
	IEnumerable<XElement> itemsIDloc = null;	// itemsID für diese Suche mit strID
	itemsID = from record in xTree.Descendants("etappe")
	where record.Element("ID").Value == ythisID
		select record;	
	if (HasMember(itemsID)){
		hScrollBar1.Value = Int16.Parse(ythisID);
		return ythisID;
	} else {
		int i = 20;		// um mögl. endlos-Schleife zu verhindern
		while (!HasMember(itemsIDloc) && i>0) {
			if (up) {
				strID = (zaehler++ ).ToString();
			} else {
				strID = (zaehler-- ).ToString();
			}
			//Debug.Print("zaehler: " + zaehler.ToString());
			itemsIDloc = from record in xTree.Descendants("etappe")
				where record.Element("ID").Value == strID
			    select record;	
			rWert = itemsIDloc.Elements().Count();	//Anzahl der gefundenen Tags (immer =6) des Standard XML-Inputs
			i--;
		}
	if (HasMember(itemsIDloc)){
		Debug.Print("r=" + rWert + ":\tzaehl=" + zaehler.ToString() + "\titems:\t"+ itemsID.ToString());
		hScrollBar1.Value = Int16.Parse(strID);
		return strID;
	}
	return "";
}
}

private int setNodeData(string xthisID){
	int rWert = 0;
	Debug.Print("vor getNextID: " + strID);
	keineEingaben();	// eventhandler entfernen
	strID = getNextID( xthisID, up);		// setzt itemsID Liste und thisID
	Debug.Print("nach getNextID: " + strID);
	alleloeschen_Click(null,null);
	if (strID == ""){
		this.toolStripStatusLabel1.Text = "kein <row>-Satz gefunden";
		tbID.Text = strID; 
		tbTitel.Text = "";
		tbKarte.Text = "";
		tbZeit.Text = "";
		tbDescr.Text = "";
		MessageBox.Show("kein weiterer XML-Satz vorhanden!\n" +
		                "Neue Etappen mit Menü erstellen!", 
		                "Ende XML",MessageBoxButtons.OK);
		alleEingaben();
		geaendert = false;
		return rWert;
	}
	foreach (XElement item in itemsID.Elements()){
		//Program.dbg(item.ToString());
		switch (item.Name.ToString()) {
       		case "Titel":
        		tbTitel.Text = item.Value;
        		break;
       		case "IDKarte":
        		tbKarte.Text = item.Value;
        		break;
       		case "Descr":
        		tbDescr.Text = item.Value;
        		break;
       		case "Zeit":
        		tbZeit.Text = item.Value;
        		break;
       		case "ID":
        		tbID.Text = item.Value;
        		hScrollBar1.Value = int.Parse(item.Value);
        		break;
       		case "fotos":
        		Int32 zaehler = 0;
        		neueLoc = new Point(3,3);
        		foreach (XElement foto in item.Elements("foto")) {
        			string pfad = Path.Combine(arbeitsverzeichnis, foto.Element("Pfad").Value.Trim());
        			picbox2 = machNeuePB(pfad, foto.Element("Titel").Value);
					picbox2.Descr = foto.Element("Desc").Value;
					picbox2.Location = neueLoc;
					if (foto.Element("Name")!=null) {
						if (foto.Element("Name").Value == "Leerbild") continue;
						picbox2.Name = foto.Element("Name").Value;
					}
					
					listBox1.Items.Add(picbox2.Datei);
					neueLoc = newLocation(neueLoc);
					zaehler++;		
        		}
        		/*******
        		foreach (Control ctrl in flowLayoutPanel2.Controls) {
        			Program.dbg(ctrl.Name);
        		}
        		******/
        		break;
      	}
}
		geaendert = false;
		wasDropped = true;		// damit neue Bilder hochgeschoben werden können
		alleEingaben();
	return rWert;
}

// PictBoxes im Panel2: gerufen von setNodeData() und picturebox_MouseDown()
// PictBoxes mit Tag == "neu" sind nur Platzhalter (ohne Image)
private pictBox machNeuePB(string Pfad, string Titel = "neu gemacht", bool mitBild=true) {
		picbox2 = new pictBox(Pfad, Titel);
		picbox2.Image = Image.FromFile("Leerbild.jpg");
		try {
		if (mitBild) picbox2.Image = Image.FromFile(Pfad);
		} catch (IOException e) {
			picbox2.Image = null;
		}
		picbox2.Datei = Pfad;
		picbox2.ContextMenu = this.ContextMenu;
		picbox2.Size = new System.Drawing.Size(80, 100);
		picbox2.SizeMode = PictureBoxSizeMode.StretchImage;
		this.flowLayoutPanel2.Controls.Add(picbox2);
	    picbox2.AllowDrop = true;
	    picbox2.MouseUp += new MouseEventHandler(picbox2_MouseClickUp);
	    //picbox2.MouseDown += new MouseEventHandler(pictBox2_MouseDown);
	    //picbox2.MouseHover += new EventHandler(pictBox2_Hover);
	    picbox2.DragEnter += new DragEventHandler(pictureBox3_DragEnter);
	    picbox2.DragDrop += new System.Windows.Forms.DragEventHandler(pictureBox2_DragDrop);
	    return picbox2;
}

private Point newLocation(Point alteLoc, int wo = 1){
	Point neueLoc = new Point(0,0);
	neueLoc = alteLoc;
	switch (wo) {
		case 1:		// ein Bild weiter mit Beachtung der Grenzen
			neueLoc = new Point(alteLoc.X + 83, alteLoc.Y);
			if (neueLoc.X > flowLayoutPanel2.Width - 80) { 
				neueLoc = new Point(0, picbox2.Height +3); 
			}
			break;
		case 2: 	// beiseite schieben einer picBox, auf die geschoben wird
			neueLoc = new Point(alteLoc.X , alteLoc.Y +103);
			break;
	}
	return neueLoc;
}

    // Handler für picBoxes in Panel2
    private void pictBox2_MouseDown(object sender, MouseEventArgs e)
    {
	pictBox  pb = (pictBox)sender;
	Debug.WriteLine("down pb2: " + pb.Datei);
	picbox_Click(pb, flowLayoutPanel2);
	alteLoc = pb.Location;
	if (e.Button ==  MouseButtons.Left) {	// mit linker Taste schieben, rechter Contextmenu
		movingPB = pb;
		DoDragDrop(pb.Datei, DragDropEffects.Copy);
		//ab hier springt Programm zu Enter und Drop Handlern und kommt zurück;
		if (wasDropped) {		// neue picBox nur, wenn auf neue gezogen wird
			picbox2 = machNeuePB("", "picbox2_neu" , false);
			picbox2.Name = "picbox2_neu";	// + dist.ToString();
			picbox2.Datei = pb.Datei;
			picbox2.Location = neueLoc;
			this.flowLayoutPanel2.Controls.Add(picbox2);
			neueLoc = newLocation(neueLoc);
			Program.dbg(pb.Name);
			wasDropped = false;
		}
	} 
    }
    
    void pictBox2_MouseDrag(object sender, MouseEventArgs e) {
    	Program.dbg(sender.ToString());
    }
    
void pictureBox3_DragEnter(object sender, DragEventArgs e) {
	pictBox pb = (pictBox)sender;
	Program.dbg(pb.Name);
    pb.MouseDown -= new MouseEventHandler(pictBox2_MouseDown);
	//if (e.Data.GetDataPresent(pb.DataFormat)){}
		e.Data.GetDataPresent(DataFormats.StringFormat);
		e.Effect = DragDropEffects.Copy;
    Program.dbg("Enter2: " + e.X +"," + e.Y + "effect: "  + e.Effect.ToString());
}
    
    void pictureBox2_DragDrop(object sender, DragEventArgs e) {
	pictBox pb = (pictBox)sender;
	Debug.WriteLine("Drop: " + pb.Name);
    wasDropped = true;
		pb.Datei = (string)e.Data.GetData(DataFormats.StringFormat);
		Program.dbg("neuL: " + neueLoc.ToString() + "\t" + pb.Datei);
		neueLoc = newLocation(neueLoc);
		pb.Image = Image.FromFile(pb.Datei);
		listBox1.Items.Add(pb.Datei);
		picBsChanged = true;
		Program.dbg(pb.Datei);
		return;
}


private bool hasChanged(){
	bool rBool = false;
	if (
	   (string)tbTitel.Tag == "true"  || 
	  	(string)tbZeit.Tag == "true"  || 
	  	(string)tbDescr.Tag == "true" ||
	  	(string)tbKarte.Tag == "true"||
		picBsChanged == true)
	  	 {
			rBool = true;
		}
  	return rBool;
}


        
private void picbox_Flip(System.Object sender, System.EventArgs e)
{
	foreach (pictBox ctrl in flowLayoutPanel2.Controls) {
	if (ctrl.Focused) {
		Debug.WriteLine("Flip: " + ctrl.Name);
		img = ctrl.Image;
	    img.RotateFlip(RotateFlipType.Rotate90FlipNone);
	    ctrl.Image = img;
	}
	}	
}

private void alleloeschen_Click(System.Object sender, System.EventArgs e) 
{
	Panel flowP1 = this.flowLayoutPanel2;		//(FlowLayoutPanel)(((ToolStripMenuItem)sender).Parent);
	Debug.WriteLine("alleloeschen: " + flowP1.Name +"\tAnz.: " + flowP1.Controls.Count);
	for (int i = flowP1.Controls.Count-1; i>=0; i--) {
		//Debug.WriteLine("name: " + flowP1.Controls[i].GetType().ToString() + "\t" + flowP1.Controls[i].Name);
		if (flowP1.Controls[i].GetType() == typeof(pictBox)) {
			flowP1.Controls[i].Dispose();
		}
	}
	listBox1.Items.Clear();
	wasDropped = true;
	tbPfad.Text = "";
	tbFDescr.Text = "";
	tbFName.Text = "";
	tbFTitel.Text = "";
	dist = new Point(3,3);
	neueLoc = new Point(3,3);
}

private void schieben_Click(object sender, EventArgs e) {
	Program.dbg(sender.ToString());
	Panel flowP1 = this.flowLayoutPanel2;
	int pbtabidx = 0;
	Point freieLoc = new Point(0,0);
	foreach (pictBox ctrl in flowP1.Controls) {
		if (ctrl.Focused) { 
			pbtabidx = ctrl.TabIndex;
			picbox2 = machNeuePB("", "picbox2_neu" , false);
			picbox2.Name = "Leerbild";	
			freieLoc = ctrl.Location;
//			neueLoc = newLocation(neueLoc);
			picbox2.Location = neueLoc;
			flowP1.Controls.Add(picbox2);
			break; 
		}
	}
	Debug.WriteLine("schieben_Click: "  +"\tAnz.: " + flowP1.Controls.Count);
	Point loc1 = flowP1.Controls[flowP1.Controls.Count-2].Location;
	for (int i = pbtabidx; i < flowP1.Controls.Count-1;  i++) {
		Debug.WriteLine("name: " + flowP1.Controls[i].GetType().ToString() + "\t" + flowP1.Controls[i].TabIndex);
		if (flowP1.Controls[i].GetType() == typeof(pictBox)) {
			flowP1.Controls[i].Location = flowP1.Controls[i+1].Location;
			//System.Threading.Thread.Sleep(1000);
		}
	}
	picbox2 = machNeuePB("", "picbox2_neu" , false);
	picbox2.Name = "Leerbild";	
	picbox2.Location = freieLoc;
	this.flowLayoutPanel2.Controls.Add(picbox2);
	tbPfad.Text = "";
	tbFDescr.Text = "";
	tbFName.Text = "";
	tbFTitel.Text = "";
	picBsChanged = true;
}



	private void itemloeschen_Click(System.Object sender, System.EventArgs e){
	ToolStripMenuItem item = (ToolStripMenuItem)sender;
	Debug.WriteLine("itemloeschen: " + item.Name );
	int pos=-1;
	bool focused = false;
	foreach (pictBox ctrl in flowLayoutPanel2.Controls) {
		if (ctrl.Focused) {
			focused = true;
			try{
			foreach ( var eintrag in listBox1.Items) {
				if (eintrag.ToString() == ctrl.Datei.ToString()){
					pos = listBox1.Items.IndexOf(eintrag);
				}
			}
			} catch (NullReferenceException evt) {
				MessageBox.Show(evt.Message);
			}
			if (pos >= 0) {
				listBox1.Items.RemoveAt(pos);
				ctrl.Image = Image.FromFile("Leerbild.jpg");
				ctrl.Name = "Leerbild";
				 ctrl.Datei = "";
				wasDropped = true;
				tbPfad.Text = "";
				tbFDescr.Text = "";
				tbFName.Text = "";
				tbFTitel.Text = "";
				 picBsChanged = true;
			}
		} 
		
	}
	if (!focused) {
		MessageBox.Show("zum Löschen muss ein Item selektiert werden!");
	}
	wasDropped = true;

}

private void att_Click(object sender, EventArgs e) {
	Debug.WriteLine("att: " + ((PictureBox)sender).Name);
}

public static String PrintXML(String xml)
{
var stringBuilder = new StringBuilder();

    var element = XElement.Parse(xml);

    var settings = new XmlWriterSettings();
    settings.OmitXmlDeclaration = true;
    settings.Indent = true;
    settings.NewLineOnAttributes = true;

    using (var xmlWriter = XmlWriter.Create(stringBuilder, settings))
    {
        element.Save(xmlWriter);
    }

    return stringBuilder.ToString();
}

	private void btLast_Click(object sender, System.EventArgs e) {
		Program.dbg(((Button)sender).Name);
		pictBox lastpb = new pictBox("","");
		sortEtappen();
		XElement lastelem = xTree.Descendants("etappe").Last();
	 	strID = lastelem.Element("ID").Value;
	 	lastID = strID;
	 	Int16 savStrID = Int16.Parse(strID);
	 setNodeData(strID);	// setzt strID über letzte ID hinaus auf leer
	 if (strID == "") hScrollBar1.Value = --savStrID;
	 else hScrollBar1.Value = Int16.Parse(strID);
	}


	private void btFirst_Click(object sender, System.EventArgs e) {
		//Program.dbg(((Button)sender).Name);
		pictBox lastpb = new pictBox("","");
		XElement firstelem = xTree.Descendants("etappe").First();
	 	strID = firstelem.Element("ID").Value;
	 	firstID = strID;
	 	Int16 savStrID = Int16.Parse(strID);
	 setNodeData(strID);
	 if (strID == "") hScrollBar1.Value = ++savStrID;
	 else hScrollBar1.Value = Int16.Parse(strID);
	}

private void sortEtappen(){
	XElement root = xTree;
var orderedEtabs = root.Elements("etappe")
                      .OrderBy(xtab => (int)xtab.Element("ID"))
                      .ToArray();
root.RemoveAll();
foreach(XElement tab in orderedEtabs)
    root.Add(tab);
root.Save(@"xTree.xml");
}

private void neue_Bilder(object sender, EventArgs e) {
	Program.dbg(sender.ToString());
	wasDropped = true;
	MessageBox.Show("mit Click auf Panel2 Ort für weitere Bilder anklicken");
	flowLayoutPanel2.MouseClick += new MouseEventHandler(panel_Click);
}

private void panel_Click(object sender, MouseEventArgs e) {
	Program.dbg(sender.ToString());
	neueLoc = new Point(e.X, e.Y);
    	picbox2 = machNeuePB("", "picbox2_neu" , false);
    	picbox2.Name = "picbox2_neu";	// + dist.ToString();
    	picbox2.Location = neueLoc;
		this.flowLayoutPanel2.Controls.Add(picbox2);
	flowLayoutPanel2.MouseClick -= new MouseEventHandler(panel_Click);
}

private void pictBox2_Hover(object sender, EventArgs e){
	Program.dbg(((pictBox)sender).Name.ToString());
	Debug.WriteLine(Cursor.Position.ToString() + "\tAnz.Ctrls: " + flowLayoutPanel2.Controls.Count);
}

private void neueEtappe_Click(object sender, EventArgs e){
	Program.dbg("start");
	Etappe etappe = new Etappe();
	etappe.Show();
}
private void xmlSave_Click(object sender, EventArgs e){
	Program.dbg("start");
    saveFileDialog1.InitialDirectory = arbeitsverzeichnis;
    if(saveFileDialog1.ShowDialog() == DialogResult.OK)
    {
		Program.dbg("Verz: " + arbeitsverzeichnis);
		xTree.Save(saveFileDialog1.FileName);
		picBsChanged = false;
		geaendert = false;
		this.toolStripStatusLabel1.Text =  saveFileDialog1.FileName + " gespeichert" ;  
		}
}

private void listeBilder_Click(object sender, EventArgs e){
	Program.dbg("start");
	foreach (XElement foto in xTree.Descendants("foto")) {
		Debug.Print(foto.Element("Pfad").Value);
	}
}
}	
}
