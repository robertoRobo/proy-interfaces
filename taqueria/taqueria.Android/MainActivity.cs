using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using FFImageLoading.Forms.Droid;
using Xamarin.Forms.Xaml;
using Acr.UserDialogs;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace taqueria.Droid
{
    [Activity(Label = "Tacos Tito", Icon = "@drawable/Logo", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            CachedImageRenderer.Init(enableFastRenderer: true);
            Xamarin.FormsMaps.Init(this, bundle);

            base.OnCreate(bundle);

            global::Xamarin.Forms.Forms.Init(this, bundle);

            Android.Telephony.TelephonyManager mTelephonyMgr;
            mTelephonyMgr = (Android.Telephony.TelephonyManager)GetSystemService(TelephonyService);
            //IMEI number  
            String m_deviceId = mTelephonyMgr.DeviceId;

            LoadApplication(application: new App(m_deviceId));

            UserDialogs.Init(this);


        }
    }
}

