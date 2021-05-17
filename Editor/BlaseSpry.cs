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
    [PostProcessBuild]
    public static void RemoveUnsupportedPopUp(BuildTarget target, string targetPath)
    {
        var path = Path.Combine(targetPath, "Build/UnityLoader.js");
        var text = File.ReadAllText(path);
        text = text.Replace("UnityLoader.SystemInfo.mobile", "false");
        File.WriteAllText(path, text);
    }

    //Theoretically should fix the sizing issue. partially from: https://stackoverflow.com/questions/58381516/unity-webgl-build-how-to-set-canvas-size-for-mobile-browsers
    [PostProcessBuild]
    public static void MakeResponsiveToBrowserSize (BuildTarget target, string targetPath)
    {
        var path = Path.Combine(targetPath, "index.html");
        string[] lines = File.ReadAllLines(path);
        for (int i = 0; i < lines.Length; i++)
        {
            if (lines[i].Contains("div id=\"unityContainer\""))
                lines[i] = "    <div id=\"unityContainer\" style=\"width: 360px; height: 640px; margin: auto\"></div>";
        }
        File.WriteAllLines(path, lines);
    }
}
//#endif