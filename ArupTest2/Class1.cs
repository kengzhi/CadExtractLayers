using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.IO;


using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.DatabaseServices;

[assembly: CommandClass(typeof(ArupTest2.Class1))]

namespace ArupTest2
{

	public class Class1
	{
		static void Main(string[] args)
		{
			Class1 initCad = new Class1();
			initCad.extractLayers();
		}

		[CommandMethod("extractLayers")]
		public void extractLayers()
		{
			// checking opened document
			var document = Application.DocumentManager.MdiActiveDocument;
			var editor = document.Editor;
			try
			{
				//extract layer names and save them to layers.txt
				var db = document.Database;
				using (var writer = File.CreateText(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "layers.txt")))
				{
					dynamic layers = db.LayerTableId;
					foreach (dynamic layer in layers)
						writer.WriteLine(layer.Name);
				}
			}
			catch (System.Exception e)
			{
				editor.WriteMessage("Error: {0}", e);
			}

			
		}



	}
}
