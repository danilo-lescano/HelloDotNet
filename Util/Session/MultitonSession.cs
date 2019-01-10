using System;
using System.Collections.Generic;

namespace Util{
    public class MultitonSession{
        private static List<MultitonSession> sessionList = new List<MultitonSession>();

        private string SessionKey { get; set; }
        private DateTime LastUpdate { get; set; }

        private Dictionary<string, Object> SessionVariables { get; set; } = new Dictionary<string, Object>();

        private MultitonSession(string sessionKey){
            this.SessionKey = sessionKey;
        }

        public static MultitonSession GetSession(string sessionKey){
            for (int i = 0; i < sessionList.Count; i++)
                if (sessionList[i].SessionKey == sessionKey){
                    sessionList[i].LastUpdate = DateTime.Now;
                    return sessionList[i];
                }

            MultitonSession newSession = new MultitonSession(sessionKey);
            newSession.LastUpdate = DateTime.Now;
            sessionList.Add(newSession);

            return newSession;
        }

        public static void RemoveSession(MultitonSession sessionToDelete){
            MultitonSession aux = null;
            foreach (MultitonSession session in sessionList){
                if(Object.ReferenceEquals(session, sessionToDelete)){
                    aux = session;
                    break;
                }
            }
            if(aux != null)
                sessionList.Remove(aux);
        }

        /***************************************************************/
        /***********************MÉTODOS DO OBJETO***********************/
        /***************************************************************/
        public Object this[string key] {
            get{
                if(SessionVariables.ContainsKey(key))
                    return SessionVariables[key];
                return null;
            }
            set{
                if(SessionVariables.ContainsKey(key))
                    SessionVariables[key] = value;
                else
                    SessionVariables.Add(key, value);
            }
        }
        public void Remove(string key){
            SessionVariables.Remove(key);
        }
    }
}