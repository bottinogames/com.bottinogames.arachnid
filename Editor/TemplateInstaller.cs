#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;

public class TemplateInstaller
{
    [InitializeOnLoadMethod]
    public static void TemplatePrompt()
    {
        if (!AssetDatabase.IsValidFolder("WebGLTemplates/Arachnid"))
        {
            FileUtil.CopyFileOrDirectory("../Packages/com.bottinogames.arachnid/WebGLTemplates/Arachnid", "WebGLTemplates/Arachnid");
        }
    }
}
#endif