/*
 * Created by SharpDevelop.
 * User: gameloft
 * Date: 8/27/2008
 * Time: 11:25 AM
 * 
 * To change this template use Tools | Options | Coding | Edit Standard Headers.
 */

using System;
using System.Drawing;
using System.Windows.Forms;

namespace TileMapEditor
{
	/// <summary>
	/// Description of LoadXmlMapFrm.
	/// </summary>
	public partial class LoadPlayingMapFrm : Form
	{
        OpenFileDialog openDialog = new OpenFileDialog();
		public LoadPlayingMapFrm()
		{
			InitializeComponent();			
		}
		
		void BtnBrowserXmlMapClick(object sender, EventArgs e)
		{
            openDialog.Filter = "Playing Map Xml|*.tmx|All files|*.*";
            openDialog.FileName = "";
            if (openDialog.ShowDialog() == DialogResult.OK)
			{
                txtXmlMapPath.Text = openDialog.FileName;			
			}
		}
		
		void BtnBrowserImageClick(object sender, EventArgs e)
		{
            openDialog.Filter = "PNG Image|*.png|All files|*.*";
            openDialog.FileName = "";
            if (openDialog.ShowDialog() == DialogResult.OK)
			{
                txtImageFilename.Text = openDialog.FileName;			
			}
		}
		
		void BtnOkClick(object sender, EventArgs e)
		{
			MainFrm.s_ImageFilename = txtImageFilename.Text;
			MainFrm.s_XmlMapFilename = txtXmlMapPath.Text;
			MainFrm.s_BinaryFilename = txtBinaryFilename.Text;					
		}
		
		void BtnCancelClick(object sender, EventArgs e)
		{
		}
		
		void BtnBinaryFilenameClick(object sender, EventArgs e)
		{
            openDialog.Filter = "Playing Map|*.map|All files|*.*";
            openDialog.FileName = "";
            if (openDialog.ShowDialog() == DialogResult.OK)
			{
                txtBinaryFilename.Text = openDialog.FileName;			
			}
		}
	}
}
