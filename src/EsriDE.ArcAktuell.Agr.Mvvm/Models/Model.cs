using System;
using ESRI.ArcGIS.Client.Geometry;
using ESRI.ArcGIS.Client.Tasks;
using EsriDE.ArcAktuell.Agr.Mvvm.DomainModels;

namespace EsriDE.ArcAktuell.Agr.Mvvm.Models
{
    public class Model : IModel
    {
        private QueryTask _queryTaskEvacuationPerimeter;
        private QueryTask _queryTaskFirePerimeter;
        private QueryTask _queryTaskPointsOfInterest;

        public Model()
        {
            InitializeQueryComponents();
        }

        #region IModel Members

        public event Action<int, QueryType> QueryCompleted = delegate { };

        public void DoQuery(Geometry geometry)
        {
            CancelBusyQueries();

            StartQuery(geometry, QueryType.PointsOfInterest);
            StartQuery(geometry, QueryType.EvacuationPerimeter);
            StartQuery(geometry, QueryType.FirePerimeter);
        }

        #endregion

        private void InitializeQueryComponents()
        {
            _queryTaskPointsOfInterest =
                new QueryTask(@"http://sampleserver3.arcgisonline.com/ArcGIS/rest/services/Fire/Sheep/FeatureServer/0");
            _queryTaskPointsOfInterest.ExecuteCompleted += QueryTaskExecuteCompleted;
            _queryTaskPointsOfInterest.Failed += QueryTaskFailed;

            _queryTaskEvacuationPerimeter =
                new QueryTask(@"http://sampleserver3.arcgisonline.com/ArcGIS/rest/services/Fire/Sheep/FeatureServer/1");
            _queryTaskEvacuationPerimeter.ExecuteCompleted += QueryTaskExecuteCompleted;
            _queryTaskEvacuationPerimeter.Failed += QueryTaskFailed;

            _queryTaskFirePerimeter =
                new QueryTask(@"http://sampleserver3.arcgisonline.com/ArcGIS/rest/services/Fire/Sheep/FeatureServer/2");
            _queryTaskFirePerimeter.ExecuteCompleted += QueryTaskExecuteCompleted;
            _queryTaskFirePerimeter.Failed += QueryTaskFailed;
        }

        private void StartQuery(Geometry geometry, QueryType queryType)
        {
            var query = new Query
                            {
                                Geometry = geometry,
                                ReturnGeometry = false,
                                Where = "true"
                            };

            switch (queryType)
            {
                case QueryType.PointsOfInterest:
                    _queryTaskPointsOfInterest.ExecuteAsync(query, queryType);
                    break;
                case QueryType.EvacuationPerimeter:
                    _queryTaskEvacuationPerimeter.ExecuteAsync(query, queryType);
                    break;
                case QueryType.FirePerimeter:
                    _queryTaskFirePerimeter.ExecuteAsync(query, queryType);
                    break;
            }
        }

        private void QueryTaskExecuteCompleted(object sender, QueryEventArgs args)
        {
            QueryCompleted(args.FeatureSet.Features.Count, (QueryType) args.UserState);
        }

        private void QueryTaskFailed(object sender, TaskFailedEventArgs args)
        {
            QueryCompleted(0, (QueryType) args.UserState);
        }

        private void CancelBusyQueries()
        {
            if (_queryTaskFirePerimeter.IsBusy)
            {
                _queryTaskPointsOfInterest.CancelAsync();
            }
            if (_queryTaskEvacuationPerimeter.IsBusy)
            {
                _queryTaskEvacuationPerimeter.CancelAsync();
            }

            if (_queryTaskFirePerimeter.IsBusy)
            {
                _queryTaskFirePerimeter.CancelAsync();
            }
        }
    }
}