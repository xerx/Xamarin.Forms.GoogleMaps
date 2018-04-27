using System;
using System.Linq;
using Android.Widget;
using Com.Google.Maps.Android.Clustering;
using Java.Lang;
using Xamarin.Forms.GoogleMaps.Android;
using XForms = Xamarin.Forms.Forms;

namespace Xamarin.Forms.GoogleMaps.Logics.Android
{
    internal class ClusterLogicHandler : Java.Lang.Object,
        ClusterManager.IOnClusterClickListener,
        ClusterManager.IOnClusterItemClickListener,
        ClusterManager.IOnClusterInfoWindowClickListener,
        ClusterManager.IOnClusterItemInfoWindowClickListener
    {
        private Map _map;
        private ClusterManager _clusterManager;
        private ClusterLogic _logic;

        public ClusterLogicHandler(Map map, ClusterManager manager, ClusterLogic logic)
        {
            this._map = map;
            this._clusterManager = manager;
            this._logic = logic;
        }

        public bool OnClusterClick(ICluster cluster)
        {
            return false;
        }

        public bool OnClusterItemClick(Java.Lang.Object nativeItemObj)
        {
            ClusteredMarker nativeItem = nativeItemObj as ClusteredMarker;

            //lookup pin
            Pin targetPin = this._logic.LookupPin(nativeItem);
            // If set to PinClickedEventArgs.Handled = true in app codes,
            // then all pin selection controlling by app.
            if (this._map.SendPinClicked(targetPin))
            {
                return true;
            }

            return true;
        }

        public void OnClusterInfoWindowClick(ICluster cluster)
        {

        }

        public void OnClusterItemInfoWindowClick(Java.Lang.Object p0)
        {

        }
    }
}