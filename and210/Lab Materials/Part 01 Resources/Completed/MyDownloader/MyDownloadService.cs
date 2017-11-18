using System;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;
using Android.Widget;
using System.Threading;
using System.Threading.Tasks;

namespace MyDownloader
{
    [Service (Label = "MyDownloadService", Icon = "@drawable/Icon") ] 
    class MyDownloadService : Service 
    {
        const string tag = "MyDownloadService";
        const int NotificationID = 1000;
        bool isDownloaded;
        bool isCancelled;
        PendingIntent pendingIntent;

        public override void OnCreate()
        {
            base.OnCreate();
            Log.Debug(tag, "Service created");

            pendingIntent = PendingIntent.GetActivity(this, 0, new Intent(this, typeof(MainActivity)), 0);
        }

        public override IBinder OnBind(Intent intent)
        {
            Log.Debug(tag, "OnBind called");

            throw new NotImplementedException();
        }

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            Log.Debug(tag, "OnStartCommand called");

            isDownloaded = false;
            isCancelled = false;

            StartForeground(NotificationID, GetNotification("Download started"));

            Toast.MakeText(this, "Download Started", ToastLength.Short).Show();

            var steps = intent.GetIntExtra("LoopCount",10);

            Task.Run(() =>
                {
                for (int i = 0; i < steps; i++)
                {
                    int percent = 100 * (i + 1) / steps;
                    var msg = String.Format("[{0}] download in progress: {1}% complete", startId, percent);
                    Log.Debug(tag, msg);
                    UpdateNotifcation(msg);

                    Thread.Sleep(500);
                }

                if(isCancelled == false)
                    {
                        isDownloaded = true;
                        StopSelf();

                    }

                    
            } );

            

            return StartCommandResult.RedeliverIntent;

           
        }

        Notification GetNotification(string content)
        {
            return new Notification.Builder(this)
                .SetContentTitle(tag)
                .SetContentText(content)
                .SetSmallIcon(Resource.Drawable.icon)
                .SetContentIntent(pendingIntent)
                .Build();
                
        }

        void UpdateNotifcation(string content)
        {
            var notification = GetNotification(content);
            NotificationManager manager = (NotificationManager)GetSystemService(Context.NotificationService);
            manager.Notify(NotificationID, notification);

        }

        public override void OnDestroy()
        {
            isCancelled = true;
            if (isDownloaded)
            {
                Toast.MakeText(this, "Download completed", ToastLength.Long).Show();
            }
            else
            {
                Toast.MakeText(this, "Download cancelled", ToastLength.Long).Show();
            }
            Log.Debug(tag, "Service destroyed");
        }
    }
}