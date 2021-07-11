using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
public static class ArachnidInstaller
{
    const string PACKAGE_URL = "Packages/com.bottinogames.arachnid/ArachnidPackage.unitypackage";


    [MenuItem("Alice's Stuff/WebGL/Install Arachnid Template")]
    public static void Install()
    {
        AssetDatabase.ImportPackage(PACKAGE_URL, true);
    }
}
