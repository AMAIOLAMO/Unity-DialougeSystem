using UnityEditor;
using UnityEngine.UIElements;

namespace CXUtils.DialogSystem.Editors
{
    public class DialogGraphEditorWindow : EditorWindow
    {
        [MenuItem("Window/CXUtils/DialogSystem/DialogGraphEditor")]
        public static void Open()
        {
            GetWindow<DialogGraphEditorWindow>("Dialog Graph Editor");
        }

        public void CreateGUI()
        {
            var graphView = new DialogEditorGraphView();

            graphView.StretchToParentSize();

            rootVisualElement.Add(graphView);
        }
    }
}