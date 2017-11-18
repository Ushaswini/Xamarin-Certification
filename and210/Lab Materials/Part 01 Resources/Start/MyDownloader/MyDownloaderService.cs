
using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Util;

namespace MyDownloader
{
    [Service(Label ="My downloader service",Icon ="@drawable/Icon")]
    class MyDownloaderService : Service
    {
        const string tag = "MyDownloadService";
        public override IBinder OnBind(Intent intent)
        {
            Log.Debug(tag, "OnBind called");
            return null;
        }

        public override void OnCreate()
        {
            Log.Debug(tag, "OnCreate called");
            base.OnCreate();
        }

        public override void OnDestroy()
        {
            Log.Debug(tag, "OnDestroy called");
            base.OnDestroy();
        }

        protected override void Dispose(bool disposing)
        {
            Log.Debug(tag, "Dispose called");
            base.Dispose(disposing);
        }

        [return: GeneratedEnum]
        public override StartCommandResult OnStartCommand(Intent intent, [GeneratedEnum] StartCommandFlags flags, int startId)
        {
            Log.Debug(tag, "StartCommandResult called");
            return base.OnStartCommand(intent, flags, startId);
        }
    }
}