using System.IO;
using UnityEditor;
using UnityEditor.Callbacks;

namespace Arachnid
{
    public static class BlaseSpry
    {
        const string MENU_ITEM = "Alice's Stuff/WebGL/Remove Unsupported Device Popup";
        const string EDITOR_PREF = "RemoveWebGLUnsupportedPopup";

        public static bool doRemoveUnsupportedPopup 
        {
            get { return EditorPrefs.GetBool(EDITOR_PREF, true); }
            set { EditorPrefs.SetBool(EDITOR_PREF, doRemoveUnsupportedPopup); }
        }


        //This get's rid of the warning screen Unity creates for mobile browsers. From: https://answers.unity.com/questions/1339261/unity-webgl-disable-mobile-warning.html
        [PostProcessBuild]
        public static void RemoveUnsupportedPopUp(BuildTarget target, string targetPath)
        {
            if (!doRemoveUnsupportedPopup)
                return;

            var path = Path.Combine(targetPath, "Build/UnityLoader.js");
            var text = File.ReadAllText(path);
            text = text.Replace("UnityLoader.SystemInfo.mobile", "false");
            File.WriteAllText(path, text);
        }

        [MenuItem(MENU_ITEM, priority = 26)]
        public static void TogglePopupRemoval()
        {
            doRemoveUnsupportedPopup = !doRemoveUnsupportedPopup;
        }

        [MenuItem(MENU_ITEM, validate = true)]
        public static bool TogglePopupRemovalValidate()
        {
            Menu.SetChecked(MENU_ITEM, doRemoveUnsupportedPopup);
            return true;
        }
    }
}