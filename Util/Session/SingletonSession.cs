using System;
using System.Collections.Generic;


namespace Util
{
    public class MultitonSession
    {
        private static List<MultitonSession> sessionList = new List<MultitonSession>();

        private string IdSession { get; }
        private Dictionary<string, string> sessionVariables = new Dictionary<string, string>();


        private MultitonSession(){}

        public static MultitonSession getSession(string sessionId){
            for (int i = 0; i < this.sessionId.Count; i++)
                if (this.sessionId[i].IdSession == sessionId)
                    return this.sessionId[i];
            return null;
        }
    }
}