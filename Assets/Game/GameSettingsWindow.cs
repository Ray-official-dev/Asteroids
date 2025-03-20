using UnityEditor;
using UnityEngine;

namespace Game
{
    public class GameSettingsWindow : EditorWindow
    {
        public static bool IsEditorInput { get; private set; }

        [MenuItem(Constans.EDITOR_WINDOW_PATH + "GameSettings")]
        public static void ShowWindow()
        {
            GetWindow<GameSettingsWindow>("Game Settings");
        }

        private void OnGUI()
        {
            GUILayout.Label("Select Input Mode", EditorStyles.boldLabel);
            IsEditorInput = EditorGUILayout.Toggle("Editor Input", IsEditorInput);

            if (GUILayout.Button("Save"))
            {
                EditorPrefs.SetBool("IsEditorInput", IsEditorInput);
            }
        }

        [InitializeOnLoadMethod]
        private static void LoadPreferences()
        {
            IsEditorInput = EditorPrefs.GetBool("IsEditorInput", true);
        }
    }
}