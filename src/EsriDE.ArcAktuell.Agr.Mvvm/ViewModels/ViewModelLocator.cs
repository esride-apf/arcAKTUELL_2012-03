using EsriDE.ArcAktuell.Agr.Mvvm.Models;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace EsriDE.ArcAktuell.Agr.Mvvm.ViewModels
{
	public class ViewModelLocator
	{
		public ViewModelLocator()
		{
			ServiceLocator.SetLocatorProvider(() => SimpleIoc.Default);

			SimpleIoc.Default.Register<IModel, Model>();
			SimpleIoc.Default.Register<MainViewModel>();
		}

		public MainViewModel Main
		{
			get { return ServiceLocator.Current.GetInstance<MainViewModel>(); }
		}
	}
}