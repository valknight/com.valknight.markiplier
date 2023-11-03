using System;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

namespace com.valknight.markiplier.Editor
{
    public class BiteOf87: EditorWindow
    {
        private Texture2D bg;
        private Texture2D eyes;
        private GUIStyle style;
        
        [MenuItem ("Window/Markiplier/Bite of 87")]

        public static void  ShowWindow () {
            GetWindow(typeof(BiteOf87));
        }
        
        // this will cause this window to repaint much more frequently
        // it could cause perf issues
        // but it's worth it for markiplier
        // to see repainting debug info, check:
        // https://github.com/Unity-Technologies/UnityCsReference/blob/2023.3/Editor/Mono/GUI/AboutWindow.cs
        public void OnInspectorUpdate()
        {
            Repaint();
        }

        void OnGUI ()
        {
            const float EYE_SCALE = 40f;
            if (ReferenceEquals(style, null))
            {
                style = new GUIStyle(GUI.skin.label)
                {
                    fontStyle = FontStyle.BoldAndItalic,
                    alignment = TextAnchor.LowerCenter
                };
                style.font.material.color = Color.white;
                autoRepaintOnSceneChange = true;
            }
            if (ReferenceEquals(bg, null))
            {
                Debug.Log("Loading markiplier BG...");
                bg = (Texture2D)AssetDatabase.LoadAssetAtPath("Packages/com.valknight.markiplier/Editor/MarkiplierExtensions/markiplier_cataracts.png", typeof(Texture2D));
            }
            if (ReferenceEquals(eyes, null))
            {
                Debug.Log("Loading markiplier eyes...");
                eyes = (Texture2D)AssetDatabase.LoadAssetAtPath("Packages/com.valknight.markiplier/Editor/MarkiplierExtensions/markiplier_pupil.png", typeof(Texture2D));
            }

            float scaledMod = Mathf.Sin((float)EditorApplication.timeSinceStartup) / 150f;
            GUI.DrawTexture(new Rect(0, 0, position.width, position.height), bg, ScaleMode.StretchToFill);
            GUI.DrawTexture(new Rect((0.438f + scaledMod) * position.width, 0.337f * position.height, position.width / EYE_SCALE, position.height / EYE_SCALE), eyes);
            GUI.DrawTexture(
                new Rect((0.588f + scaledMod) * position.width, 0.337f * position.height, position.width / EYE_SCALE,
                    position.height / EYE_SCALE), eyes);
            GUI.Label(new Rect(0, 0, position.width, position.height - 15f), "WAS THAT THE EXCEPTION OF 87??", style);
        }
    }
}