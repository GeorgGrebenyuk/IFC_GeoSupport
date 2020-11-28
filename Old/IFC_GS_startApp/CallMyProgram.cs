using Autodesk.Navisworks.Api.Plugins;


namespace IFC_GS_startApp
{
    [PluginAttribute("IFC GeoConvert",
                    "IFC_Geo",
                    ToolTip = "Плагин для корректировки параметров гео-положения IFC-файла, вычисление параметров трансформации начала координат файла относительно целевой модели/генплана",
                    DisplayName = "Изменение геоположения файла IFC")]

    public class CallMyProgram : AddInPlugin
    {
        public override int Execute(params string[] parameters)
        {
            System.Diagnostics.Process.Start(@"C:\Program Files\Autodesk\Navisworks Manage 2021\Plugins\IFC_GS_startApp\IFC_AddGeolocation_Ver1.exe");
            return 0;
        }
    }
}
