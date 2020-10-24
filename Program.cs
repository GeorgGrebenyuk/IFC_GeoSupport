using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Autodesk.Navisworks.Api.Plugins;
using Autodesk.Navisworks.Api;


namespace IFC_AddGeolocation_Ver1
{
	[PluginAttribute("Plugin to add geolocation property to IFC files",                   //Plugin name
					"IFC_Geo",                                       //4 character Developer ID or GUID
					ToolTip = "Изменение геопространственной привязки для IFC файла",//The tooltip for the item in the ribbon
					DisplayName = "IFC GeoConvert")]          //Display name for the Plugin in the Ribbon


	public class Program : AddInPlugin

	{
		
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		public override int Execute(params string[] parameters)

		{
			System.Windows.Forms.Application.EnableVisualStyles();
			System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
			System.Windows.Forms.Application.Run(new GeneralForm());
			return 0;
		}
	}
}
