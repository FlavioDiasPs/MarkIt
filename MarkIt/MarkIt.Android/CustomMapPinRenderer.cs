using System;
using System.Collections.Generic;
using System.Runtime.Remoting.Contexts;
using Android.Content;
using Android.Gms.Maps;
using Android.Gms.Maps.Model;
using Android.Views;
using Android.Widget;
using MarkIt.App_Code;
using MarkIt.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Maps;
using Xamarin.Forms.Maps.Android;

[assembly: ExportRenderer(typeof(CustomMapPin), typeof(CustomMapPinRenderer))]
namespace MarkIt.Droid
{
    class CustomMapPinRenderer : MapRenderer, GoogleMap.IInfoWindowAdapter
    {
        List<CustomPin> CustomPins;

        public CustomMapPinRenderer(Android.Content.Context context) : base(context)
        {
        }

        protected override void OnElementChanged(Xamarin.Forms.Platform.Android.ElementChangedEventArgs<Map> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement != null)
            {
                NativeMap.InfoWindowClick -= OnJanelaInformacaoClick;
            }

            if (e.NewElement != null)
            {
                var formsMap = (CustomMapPin)e.NewElement;
                CustomPins = formsMap.PinCustomizados;
                Control.GetMapAsync(this);
            }
        }

        protected override void OnMapReady(GoogleMap map)
        {
            base.OnMapReady(map);

            NativeMap.InfoWindowClick += OnJanelaInformacaoClick;
            NativeMap.SetInfoWindowAdapter(this);
        }

        protected override MarkerOptions CreateMarker(Pin pin)
        {
            var marker = new MarkerOptions();
            marker.SetPosition(new LatLng(pin.Position.Latitude, pin.Position.Longitude));
            marker.SetTitle(pin.Label);
            marker.SetSnippet(pin.Address);
            marker.SetIcon(BitmapDescriptorFactory.FromResource(Resource.Drawable.pinMarkIt));
            return marker;
        }

        void OnJanelaInformacaoClick(object sender, GoogleMap.InfoWindowClickEventArgs e)
        {
            var pinCustomizado = GetPinCustomizado(e.Marker);
            if (pinCustomizado == null)
            {
                throw new Exception("Marcação não localizada");
            }

            if (!string.IsNullOrWhiteSpace(pinCustomizado.Localizacao))
            {
                var url = Android.Net.Uri.Parse(pinCustomizado.Localizacao);
                var intent = new Intent(Intent.ActionView, url);
                intent.AddFlags(ActivityFlags.NewTask);
                Android.App.Application.Context.StartActivity(intent);
            }
        }

        public Android.Views.View GetInfoContents(Marker marker)
        {
            var inflater = Android.App.Application.Context.GetSystemService(Android.Content.Context.LayoutInflaterService) as Android.Views.LayoutInflater;
            if (inflater != null)
            {
                Android.Views.View view;

                var customPin = GetPinCustomizado(marker);
                if (customPin == null)
                {
                    throw new Exception("Marcação não localizada");
                }

                if (customPin.Id.ToString() == "Fiap")
                {
                    view = inflater.Inflate(Resource.Layout.InfoMapaClick, null);
                }
                else
                {
                    view = inflater.Inflate(Resource.Layout.InfoMapaClick, null);
                }

                var infoTitle = view.FindViewById<TextView>(Resource.Id.InfoWindowTitle);
                var infoSubtitle = view.FindViewById<TextView>(Resource.Id.InfoWindowSubtitle);

                if (infoTitle != null)
                {
                    infoTitle.Text = marker.Title;
                }
                if (infoSubtitle != null)
                {
                    infoSubtitle.Text = marker.Snippet;
                }

                return view;
            }
            return null;
        }

        public Android.Views.View GetInfoWindow(Marker marker)
        {
            return null;
        }

        CustomPin GetPinCustomizado(Marker annotation)
        {
            var position = new Position(annotation.Position.Latitude, annotation.Position.Longitude);
            foreach (var pin in CustomPins)
            {
                if (pin.Position == position)
                {
                    return pin;
                }
            }
            return null;
        }
    }
}