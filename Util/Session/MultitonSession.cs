using System;
using System.Collections.Generic;

namespace Util
{
    public class MultitonSession
    {
        private static List<MultitonSession> sessionList = new List<MultitonSession>();

        private string SessionKey { get; set; }
        private DateTime LastUpdate { get; set; }

        private Dictionary<string, Object> SessionVariables { get; set; } = new Dictionary<string, Object>();

        private MultitonSession(string sessionKey){
            this.SessionKey = sessionKey;
        }

        public static Dictionary<string, Object> GetSession(string sessionKey){
            for (int i = 0; i < sessionList.Count; i++)
                if (sessionList[i].SessionKey == sessionKey){
                    sessionList[i].LastUpdate = DateTime.Now;
                    return sessionList[i].SessionVariables;
                }

            MultitonSession newSession = new MultitonSession(sessionKey);
            sessionList.Add(newSession);

            return newSession.SessionVariables;
        }

        public static void DeleteSession(Dictionary<string, Object> sessionToDelete){
            MultitonSession aux = null;
            foreach (MultitonSession session in sessionList){
                if(Object.ReferenceEquals(session.SessionVariables, sessionToDelete)){
                    aux = session;
                    break;
                }
            }
            if(aux != null)
                sessionList.Remove(aux);
        }
    }
}