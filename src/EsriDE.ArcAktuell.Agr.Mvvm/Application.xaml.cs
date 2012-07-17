using System;
using System.Windows;
using ESRI.ArcGIS.Client;
using EsriDE.ArcAktuell.Agr.Mvvm.Models;
using EsriDE.ArcAktuell.Agr.Mvvm.ViewModels;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace EsriDE.ArcAktuell.Agr.Mvvm
{
	public partial class App
	{
		private void ApplicationStartup(object sender, StartupEventArgs e)
		{
			ConfigureIoc();

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

		private static void ConfigureIoc()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			SimpleIoc.Default.Register<IModel, Model>();
			SimpleIoc.Default.Register<IMainViewModel>(() =>
			                                           	{
			                                           		var model = ServiceLocator.Current.GetInstance<IModel>();
			                                           		return new MainViewModel(model);
			                                           	});
		}
	}
}