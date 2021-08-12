using UnityEngine.UIElements;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;

namespace CXUtils.DialogSystem.Editors
{
    public enum DialogType
    {
        Single, Multiple
    }

    public class DialogNode : Node
    {
        public DialogNode(string name = "NewDialog", List<string> choices = null, string text = "Text here", DialogType type = default)
        {
            (DialogName, Choices, Text, Type) = (name, choices ?? new List<string>(), text, type);
        }

        public string DialogName { get; set; }
        public List<string> Choices { get; set; }
        public string Text { get; set; }
        public DialogType Type { get; set; }

        public void InitializeContainers()
        {
            // ==

            var title = new TextField() { value = DialogName };
            titleContainer.Insert(0, title);

            // == 

            var input = InstantiatePort(Orientation.Horizontal, Direction.Input, Port.Capacity.Multi, typeof(bool));

            input.portName = "Trigger From";

            inputContainer.Add(input);

            // == 

            var customContainer = new VisualElement();

            var foldOut = new Foldout() { text = "Dialog" };

            var dialogText = new TextField() { value = Text };

            foldOut.Add(dialogText);

            customContainer.Add(foldOut);

            extensionContainer.Add(customContainer);

            RefreshExpandedState();
        }
    }
}

