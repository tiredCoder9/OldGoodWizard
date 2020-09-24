using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Notifications.Android;
using System;

public class TestNotifications : MonoBehaviour
{
    public AndroidNotificationChannel channel;
    void Start()
    {
        channel = new AndroidNotificationChannel()
        {
            Id = "channel_id",
            Name = "Default Channel",
            Importance = Importance.High,
            Description = "Generic notifications",
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);

        var notification = new AndroidNotification();
        notification.Title = "Old Good Wizard";
        notification.Text = "Your hero has been killed by giant skeleton dragon!";
        notification.FireTime = System.DateTime.Now.AddMinutes(5);

        //AndroidNotificationCenter.SendNotification(notification, "channel_id");
    }

    void Update()
    {
        
    }
}
