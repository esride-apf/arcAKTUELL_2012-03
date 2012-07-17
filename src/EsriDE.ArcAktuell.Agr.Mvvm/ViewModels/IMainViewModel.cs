using ESRI.ArcGIS.Client;
using GalaSoft.MvvmLight.Command;

namespace EsriDE.ArcAktuell.Agr.Mvvm.ViewModels
{
	public interface IMainViewModel
	{
		RelayCommand<ExtentEventArgs> ChangedMapExtentCommand { get; }
		int CountPointsOfInterest { get; set; }
		int CountEvacuationPerimeter { get; set; }
		int CountFirePerimeter { get; set; }
	}
}