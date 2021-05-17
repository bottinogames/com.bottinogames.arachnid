using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;

namespace Arachnid
{
    public static class BlaseSpry
    {
        //This get's rid of the warning screen Unity creates for mobile browsers. From: https://answers.unity.com/questions/1339261/unity-webgl-disable-mobile-warning.html
        [PostProcessBuild]
        public static void RemoveUnsupportedPopUp(BuildTarget target, string targetPath)
        {
            var path = Path.Combine(targetPath, "Build/UnityLoader.js");
            var text = File.ReadAllText(path);
            text = text.Replace("UnityLoader.SystemInfo.mobile", "false");
            File.WriteAllText(path, text);
        }
    }
}