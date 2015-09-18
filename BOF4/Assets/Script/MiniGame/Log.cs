using System;
using System.Collections.Generic;
using UnityEngine;

public enum LogLevel {
    Info,
    Warning,
    Exception,
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

    public static void Warning(string msg, params object[] args) {
        if (logLevel <= LogLevel.Warning) {
            if (args.Length == 0) {
                Debug.LogWarning(msg);
            }
            else {
                Debug.LogWarning(string.Format(msg, args));
            }
        }
    }

    public static void Exception(Exception ex) {
        if (logLevel <= LogLevel.Exception) {
            Debug.LogException(ex);
        }
    }

    public static void Error(string msg, params object[] args) {
        if (logLevel <= LogLevel.Error) {
            if (args.Length == 0) {
                Debug.LogError(msg);
            }
            else {
                Debug.LogError(string.Format(msg, args));
            }
        }
    }
}

