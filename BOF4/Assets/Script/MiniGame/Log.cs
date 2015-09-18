using System;
using System.Collections.Generic;
using UnityEngine;

public enum LogLevel {
    Info,
    Warning,
    Error,
    NoLog
}
public static class Log {

    public static LogLevel logLevel = LogLevel.Info;
    public static void Info(string msg, params object[] args) {
        if (logLevel <= LogLevel.Info) {
            if (args.Length == 0) {
                Debug.Log(msg);
            }
            else {
                Debug.Log(string.Format(msg, args));
            }
        }
    }

}

