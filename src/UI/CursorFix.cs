using UnityEngine;
using UniverseLib.UI;
using UnityExplorer.Config;


namespace UnityExplorer.UI
{
    internal class CursorFix
    {
        public static GameObject cursorObject;
        public static UIBase UI;
        public static UnityEngine.UI.Text text;
        public static void Init()
        {
            UI = UniversalUI.RegisterUI("me.redstoyn33.cursorfix", Update);
            UI.Canvas.sortingOrder = 1000;
            text = UIFactory.CreateLabel(UI.RootObject, "Cursor", ConfigManager.CursorChar.Value.ToString(), TextAnchor.MiddleCenter, ConfigManager.CursorColor.Value, true, 35);
            text.raycastTarget = false;
            cursorObject = text.gameObject;
            RectTransform rect = cursorObject.GetComponent<RectTransform>();
            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Horizontal, 64);
            rect.SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical, 64);
            ConfigManager.CursorChar.OnValueChangedNotify = new System.Action(CharUpdate);
            ConfigManager.CursorColor.OnValueChangedNotify = new System.Action(ColorUpdate);
        }
        public static void ColorUpdate()
        {
            text.color = ConfigManager.CursorColor.Value;
        }
        public static void CharUpdate()
        {
            text.text = ConfigManager.CursorChar.Value.ToString();
        }
        public static void Update()
        { 
            cursorObject.transform.localPosition = UIManager.UIRootRect.InverseTransformPoint(DisplayManager.MousePosition);
        }
    }
}
