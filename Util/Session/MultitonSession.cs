using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using TaCertoForms.Models;
using tacertoforms_dotnet.Models;

namespace Util
{
    public class MultitonSession
    {
        private static List<MultitonSession> sessionList = new List<MultitonSession>();

        private string SessionKey { get; set; }
        private DateTime LastUpdate { get; set; }

        private Dictionary<string, string> SessionVariables { get; set; } = new Dictionary<string, string>();

        private MultitonSession(string sessionKey){
            this.SessionKey = sessionKey;
        }

        public static Dictionary<string, string> GetSession(string sessionKey){
            for (int i = 0; i < sessionList.Count; i++)
                if (sessionList[i].SessionKey == sessionKey){
                    sessionList[i].LastUpdate = DateTime.Now;
                    return sessionList[i].SessionVariables;
                }

            MultitonSession newSession = new MultitonSession(sessionKey);
            sessionList.Add(newSession);

            return newSession.SessionVariables;
        }
    }
}