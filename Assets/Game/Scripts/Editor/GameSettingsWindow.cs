using UnityEditor;
using UnityEngine;

namespace Game
{
    public class GameSettingsWindow : EditorWindow
    {
        public static bool IsEditorInput { get; private set; }
        private static bool autoSave = false;
        private static float _timeScale;

        [MenuItem(Constans.EDITOR_WINDOW_PATH + "Settings")]
        public static void ShowWindow()
        {
            GetWindow<GameSettingsWindow>("Game Settings");
        }

        private void OnGUI()
        {
            GUILayout.Label("Settings:", EditorStyles.boldLabel);
            DrawInputModeToggle();
            DrawTimeScaleSlider();
            GUILayout.Space(10);
            DrawAutoSaveToggle();
        }

        private static void DrawTimeScaleSlider()
        {
            //GUILayout.Label("Time Settings", EditorStyles.boldLabel);

            float newTimeScale = EditorGUILayout.Slider("Time Scale", _timeScale, 0f, 5f);

            if (!Mathf.Approximately(newTimeScale, _timeScale))
            {
                _timeScale = newTimeScale;

                Time.timeScale = _timeScale;

                if (autoSave)
                    EditorPrefs.SetFloat("TimeScale", _timeScale);
            }
        }

        private static void DrawAutoSaveToggle()
        {
            autoSave = EditorGUILayout.Toggle("Auto Save", autoSave);
        }

        private static void DrawInputModeToggle()
        {
            //GUILayout.Label("Select Input Mode", EditorStyles.boldLabel);

            bool newIsEditorInput = EditorGUILayout.Toggle("Editor Input", IsEditorInput);

            if (newIsEditorInput != IsEditorInput)
            {
                IsEditorInput = newIsEditorInput;

                if (autoSave)
                {
                    EditorPrefs.SetBool("IsEditorInput", IsEditorInput);
                }
            }
        }

        [InitializeOnLoadMethod]
        private static void LoadPreferences()
        {
            IsEditorInput = EditorPrefs.GetBool("IsEditorInput", true);
            _timeScale = EditorPrefs.GetFloat("TimeScale", 1f);
            Time.timeScale = _timeScale;
        }
    }
}