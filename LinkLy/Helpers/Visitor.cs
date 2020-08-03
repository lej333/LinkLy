using System;
using LinkLy.Models;
using Newtonsoft.Json;
using System.Net;
using LinkLy.Interfaces;

namespace LinkLy.Helpers
{
    public class Visitor : IVisitor
    {
        private readonly string _lookupUri = "";

        public Visitor(string lookupUri) {
            _lookupUri = lookupUri;
        }

        public IpInfo GetIpInfo(string ipNumber) {
            IpInfo ipInfo;
            try
            {
                string uri = string.Format(_lookupUri, ipNumber);
                string info = new WebClient().DownloadString(uri);
                ipInfo = JsonConvert.DeserializeObject<IpInfo>(info);
            }
            catch (Exception)
            {
                ipInfo = null;
            }
            return ipInfo;
        }
    }
}
