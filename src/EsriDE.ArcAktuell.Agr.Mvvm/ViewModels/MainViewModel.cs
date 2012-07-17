using ESRI.ArcGIS.Client;
using EsriDE.ArcAktuell.Agr.Mvvm.DomainModel;
using EsriDE.ArcAktuell.Agr.Mvvm.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;

namespace EsriDE.ArcAktuell.Agr.Mvvm.ViewModels
{
	public class MainViewModel : ViewModelBase, IMainViewModel
	{
		private readonly IModel _model;
		private int _countEvacuationPerimeter;
		private int _countFirePerimeter;

		private int _countPointsOfInterest;

		public MainViewModel(IModel model)
		{
			_model = model;

			InitializeModelEvents();
			InitializeRelayCommands();
		}

		public RelayCommand<ExtentEventArgs> ChangedMapExtentCommand { get; private set; }

		public int CountPointsOfInterest
		{
			get { return _countPointsOfInterest; }
			set
			{
				_countPointsOfInterest = value;
				RaisePropertyChanged("CountPointsOfInterest");
			}
		}

		public int CountEvacuationPerimeter
		{
			get { return _countEvacuationPerimeter; }
			set
			{
				_countEvacuationPerimeter = value;
				RaisePropertyChanged("CountEvacuationPerimeter");
			}
		}

		public int CountFirePerimeter
		{
			get { return _countFirePerimeter; }
			set
			{
				_countFirePerimeter = value;
				RaisePropertyChanged("CountFirePerimeter");
			}
		}

		private void InitializeRelayCommands()
		{
			ChangedMapExtentCommand = new RelayCommand<ExtentEventArgs>(
				p => _model.DoQuery(p.NewExtent));
		}

		private void InitializeModelEvents()
		{
			_model.QueryCompleted += ModelQueryCompleted;
		}

		private void ModelQueryCompleted(int count, QueryType queryType)
		{
			switch (queryType)
			{
				case QueryType.PointsOfInterest:
					CountPointsOfInterest = count;
					break;
				case QueryType.EvacuationPerimeter:
					CountEvacuationPerimeter = count;
					break;
				case QueryType.FirePerimeter:
					CountFirePerimeter = count;
					break;
			}
		}
	}
}