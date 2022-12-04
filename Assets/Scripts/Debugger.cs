using System;
using System.ComponentModel;
using System.Diagnostics;
using UnityEngine;
using UnityEngine.Bindings;
using UnityEngine.Internal;

public static class Debugger
{
#if DEBUG_MODE
    const string ConditionalString = "DEBUG_MODE";
#else
    const string ConditionalString = "UNITY_EDITOR";
#endif

    [Conditional(ConditionalString)]
    public static void Log(object message)
    {
        UnityEngine.Debug.Log(message);
    }

    [Conditional(ConditionalString)]
    public static void Log(object messege, UnityEngine.Object context)
    {
        UnityEngine.Debug.Log(messege, context);
    }

    public static void LogFormat(string format, params object[] args)
    {
        UnityEngine.Debug.LogFormat(format, args);
    }

    public static void LogFormat(UnityEngine.Object context, string format, params object[] args)
    {
        UnityEngine.Debug.LogFormat(context, format, args);
    }

    [Conditional(ConditionalString)]
    public static void LogError(object message)
    {
        UnityEngine.Debug.LogError(message);
    }

    [Conditional(ConditionalString)]
    public static void LogError(object message, UnityEngine.Object context)
    {
        UnityEngine.Debug.LogError(message, context);
    }

    [Conditional(ConditionalString)]
    public static void LogErrorFormat(string format, params object[] args)
    {
        UnityEngine.Debug.LogErrorFormat(format, args);
    }

    [Conditional(ConditionalString)]
    public static void LogErrorFormat(UnityEngine.Object context, string format, params object[] args)
    {
        UnityEngine.Debug.LogErrorFormat(context, format, args);
    }

    [Conditional(ConditionalString)]
    public static void LogException(Exception exception)
    {
        UnityEngine.Debug.LogException(exception);
    }

    [Conditional(ConditionalString)]
    public static void LogException(Exception exception, UnityEngine.Object context)
    {
        UnityEngine.Debug.LogException(exception, context);
    }

    [Conditional(ConditionalString)]
    public static void LogWarning(object message)
    {
        UnityEngine.Debug.LogWarning(message);
    }

    [Conditional(ConditionalString)]
    public static void LogWarning(object message, UnityEngine.Object context)
    {
        UnityEngine.Debug.LogWarning(message, context);
    }

    [Conditional(ConditionalString)]
    public static void LogWarningFormat(string format, params object[] args)
    {
        UnityEngine.Debug.LogWarningFormat(format, args);
    }

    [Conditional(ConditionalString)]
    public static void LogWarningFormat(UnityEngine.Object context, string format, params object[] args)
    {
        UnityEngine.Debug.LogWarningFormat(context, format, args);
    }
}
