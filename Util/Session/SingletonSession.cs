using System;
using System.Collections.Generic;


namespace Util
{
    public class MultitonSession
    {
        private static List<MultitonSession> sessionList = new List<MultitonSession>();

        private string IdSession { get; }
        private DateTime lastUpdate;

        private Dictionary<string, string> sessionVariables = new Dictionary<string, string>();


        private MultitonSession(){}

        public static MultitonSession getSession(string sessionId){
            for (int i = 0; i < sessionList.Count; i++)
                if (sessionList[i].IdSession == sessionId)
                    return sessionList[i];
            return null;
        }
    }
}