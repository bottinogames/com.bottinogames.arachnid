//#if UNITY_EDITOR
using System;
using System.IO;
using System.Text.RegularExpressions;
using UnityEditor;

using UnityEditor.Callbacks;

public static class BlaseSpry
{
    [MenuItem("Arachnid/Set Template")]
    public static void SetArachnidTemplate()
    {
        PlayerSettings.WebGL.template = "PROJECT:../../Packages/com.bottinogames.arachnid/WebGLTemplates/Arachnid";
    }

    //This get's rid of the warning screen Unity creates for mobile browsers. From: https://answers.unity.com/questions/1339261/unity-webgl-disable-mobile-warning.html
    //[PostProcessBuild]
    //public static void RemoveUnsupportedPopUp(BuildTarget target, string targetPath)
    //{
    //    var path = Path.Combine(targetPath, "Build/UnityLoader.js");
    //    var text = File.ReadAllText(path);
    //    text = text.Replace("UnityLoader.SystemInfo.mobile", "false");
    //    File.WriteAllText(path, text);
    //}

}
//#endif