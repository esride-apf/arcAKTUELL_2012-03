using System;
using ESRI.ArcGIS.Client.Geometry;
using EsriDE.ArcAktuell.Agr.Mvvm.DomainModels;
using EsriDE.ArcAktuell.Agr.Mvvm.Models;

namespace EsriDE.ArcAktuell.Agr.Mvvm.Models
{
    public class Model:IModel
    {
        public event Action<int, QueryType> QueryCompleted = delegate { };

        public Model()
        {
        }

        public void DoQuery(Geometry geometry)
        {
            throw new NotImplementedException();
        }

        


    }
}