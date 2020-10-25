using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace IFC_AddGeolocation_Ver1
{

	public class Program

	{
		
		/// <summary>
		/// Главная точка входа для приложения.
		/// </summary>
		[STAThread]
		public static void Main ()

		{
			System.Windows.Forms.Application.EnableVisualStyles();
			System.Windows.Forms.Application.SetCompatibleTextRenderingDefault(false);
			System.Windows.Forms.Application.Run(new GeneralForm());
		}
	}
}
