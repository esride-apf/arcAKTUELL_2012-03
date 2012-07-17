using ESRI.ArcGIS.Client;
using EsriDE.ArcAktuell.Agr.Mvvm.DomainModels;
using EsriDE.ArcAktuell.Agr.Mvvm.Models;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Command;
using Microsoft.Practices.ServiceLocation;

namespace EsriDE.ArcAktuell.Agr.Mvvm.ViewModels
{
    /// <summary>
    /// This class contains properties that the main View can data bind to.
    /// <para>
    /// Use the <strong>mvvminpc</strong> snippet to add bindable properties to this ViewModel.
    /// </para>
    /// <para>
    /// You can also use Blend to data bind with the tool's support.
    /// </para>
    /// <para>
    /// See http://www.galasoft.ch/mvvm
    /// </para>
    /// </summary>
    public class MainViewModel : ViewModelBase
    {
        /// <summary>
        /// Initializes a new instance of the MainViewModel class.
        /// </summary>
        /// 
        private readonly IModel _model;

        public RelayCommand<ExtentEventArgs> ChangedMapExtentCommand
        {
            get;
            private set;
        }

        private int _countPointsOfInterest;
        public int CountPointsOfInterest
        {
            get { return _countPointsOfInterest; }
            set { _countPointsOfInterest = value; RaisePropertyChanged("CountPointsOfInterest"); }
        }

        private int _countEvacuationPerimeter;
        public int CountEvacuationPerimeter
        {
            get { return _countEvacuationPerimeter; }
            set { _countEvacuationPerimeter = value; RaisePropertyChanged("CountEvacuationPerimeter"); }
        }

        private int _countFirePerimeter;
        public int CountFirePerimeter
        {
            get { return _countFirePerimeter; }
            set { _countFirePerimeter = value; RaisePropertyChanged("CountFirePerimeter"); }
        }

        public MainViewModel()
        {
            ////if (IsInDesignMode)
            ////{
            ////    // Code runs in Blend --> create design time data.
            ////}
            ////else
            ////{
            ////    // Code runs "for real"
            ////}

            _model = ServiceLocator.Current.GetInstance<IModel>();;
            InitializeModelEvents();
            InitializeRelayCommands();
        }

        //public MainViewModel(IModel model)
        //{
        //    _model = model;
        //    InitializeModelEvents();
        //    InitializeRelayCommands();
        //}

        private void InitializeRelayCommands()
        {
            ChangedMapExtentCommand = new RelayCommand<ExtentEventArgs>(
                p => _model.DoQuery(p.NewExtent));
        }

        private void InitializeModelEvents()
        {
            _model.QueryCompleted += ModelQueryCompleted;
        }

        void ModelQueryCompleted(int count, QueryType queryType)
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