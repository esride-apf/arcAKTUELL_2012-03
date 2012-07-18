using Microsoft.Practices.ServiceLocation;

namespace EsriDE.ArcAktuell.Agr.Mvvm.ViewModels
{
	public class ViewModelLocator
	{
		public IMainViewModel MainViewModel
		{
			get { return ServiceLocator.Current.GetInstance<IMainViewModel>(); }
		}
	}
}