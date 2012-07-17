using System;
using ESRI.ArcGIS.Client.Geometry;
using EsriDE.ArcAktuell.Agr.Mvvm.DomainModel;

namespace EsriDE.ArcAktuell.Agr.Mvvm.Models
{
	public interface IModel
	{
		void DoQuery(Geometry geometry);
		event Action<int, QueryType> QueryCompleted;
	}
}