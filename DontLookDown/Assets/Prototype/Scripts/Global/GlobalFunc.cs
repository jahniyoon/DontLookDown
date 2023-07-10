using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public static partial class GlobalFunc
{

    [System.Diagnostics.Conditional("DEBUG_MODE")]

    public static void Log(object message)
    {
#if DEBUG_MODE
        Debug.Log(message);
#endif
    }

    [System.Diagnostics.Conditional("DEBUG_MODE")]
    public static void Assert(bool condition)
    {
#if DEBUG_MODE
        Debug.Assert(condition);
#endif 
    }


    public static void SetText(this GameObject target, string text)
    {
        Text textComponent = target.GetComponent<Text>();
        if (textComponent == null || textComponent == default) { return; }
        textComponent.text = text;
    }

    public static void LoadScene(string SceneName)
    {
        SceneManager.LoadScene(SceneName);
    }


}
