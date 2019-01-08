using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using Microsoft.AspNetCore.Mvc;
using tacertoforms_dotnet.Models;
using TaCertoForms.Models;
using Microsoft.AspNetCore.Http;

namespace Util{
    public class TesteSession : Controller{
        private static List<TesteSession> sessionList = new List<TesteSession>();

        private string SessionKey { get; set; }
        private DateTime LastUpdate { get; set; }

        private Dictionary<string, Object> SessionVariables { get; set; } = new Dictionary<string, Object>();

        public TesteSession() : base(){}
        private TesteSession(string sessionKey){
            this.SessionKey = sessionKey;
        }

        public static TesteSession GetSession(string sessionKey){
            for (int i = 0; i < sessionList.Count; i++)
                if (sessionList[i].SessionKey == sessionKey){
                    sessionList[i].LastUpdate = DateTime.Now;
                    return sessionList[i];
                }

            TesteSession newSession = new TesteSession(sessionKey);
            sessionList.Add(newSession);

            return newSession;
        }

        public static void DeleteSession(TesteSession sessionToDelete){
            TesteSession aux = null;
            foreach (TesteSession session in sessionList){
                if(Object.ReferenceEquals(session, sessionToDelete)){
                    aux = session;
                    break;
                }
            }
            if(aux != null)
                sessionList.Remove(aux);
        }
    }
}