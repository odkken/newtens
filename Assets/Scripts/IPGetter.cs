﻿using System;
using System.Net;
using Assets.Scripts.Common;

namespace Assets.Scripts
{
    public class IPGetter : Singleton<IPGetter>
    {
        protected IPGetter()
        {
        }

        public string LookupCity(string ipAddress)
        {

            var webClient = new WebClient();
            return webClient.DownloadString(new Uri("http://api.hostip.info/get_html.php?ip=66.27.72.112", UriKind.Absolute));
        }

    }
}
