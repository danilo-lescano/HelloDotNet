using System;
using System.Threading;
using System.Collections.Generic;

namespace Util{
    public class MultitonSession{
        private static List<Session> sessionList = new List<Session>();
        private static bool isStarted = false;
        public static Session GetSession(string sessionKey){
            if(!isStarted){
                isStarted = true;
                SessionThread obj = new SessionThread(sessionList); 
                Thread thr = new Thread(new ThreadStart(obj.LimparSessoesVencidas)); 
                thr.Start();
            }

            for (int i = 0; i < sessionList.Count; i++)
                if (sessionList[i].SessionKey == sessionKey){
                    sessionList[i].LastUpdate = DateTime.Now;
                    return sessionList[i];
                }

            Session newSession = new Session(sessionKey);
            newSession.LastUpdate = DateTime.Now;
            sessionList.Add(newSession);

            return newSession;
        }

        public static void RemoveSession(Session sessionToDelete){
            Session aux = null;
            foreach(Session session in sessionList){
                if(Object.ReferenceEquals(session, sessionToDelete)){
                    aux = session;
                    break;
                }
            }
            if(aux != null)
                sessionList.Remove(aux);
        }
        private class SessionThread{
            List<Session> sessionList;
            public SessionThread(List<Session> sessionList){
                this.sessionList = sessionList;
            }
            public void LimparSessoesVencidas(){
                while(true){
                    Thread.Sleep(1000);
                    for (int i = sessionList.Count - 1; i >= 0; i--)
                        if(sessionList[i].LastUpdate.AddMinutes(30) <= DateTime.Now)
                            MultitonSession.RemoveSession(sessionList[i]);
                }
            }
        }
    }

    public class Session{
        public string SessionKey { get; set; }
        public DateTime LastUpdate { get; set; }
        private Dictionary<string, Object> SessionVariables { get; set; } = new Dictionary<string, Object>();
        public Session(string sessionKey){
            this.SessionKey = sessionKey;
        }
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