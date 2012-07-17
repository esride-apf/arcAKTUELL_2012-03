using System;
using System.Windows;
using ESRI.ArcGIS.Client;

namespace EsriDE.ArcAktuell.Agr.Mvvm
{
	public partial class App
	{
		private void ApplicationStartup(object sender, StartupEventArgs e)
		{
			try
			{
				ArcGISRuntime.Initialize();
			}
			catch (Exception ex)
			{
				MessageBox.Show(ex.ToString());

				Shutdown();
			}
		}
	}
}