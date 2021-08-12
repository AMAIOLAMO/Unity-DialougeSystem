using UnityEngine.UIElements;
using UnityEditor.Experimental.GraphView;

namespace CXUtils.DialogSystem.Editors
{
    public class DialogEditorGraphView : GraphView
    {
        public DialogEditorGraphView()
        {
            var background = new GridBackground();

            background.StretchToParentSize();

            Insert(0, background);

            TestNode();

            AddManipulators();
        }

        void TestNode()
        {
            var node = new DialogNode();

            node.InitializeContainers();

            AddElement(node);
        }

        void AddManipulators()
        {
            SetupZoom(ContentZoomer.DefaultMinScale, ContentZoomer.DefaultMaxScale);
            this.AddManipulator(new ContentDragger());
        }
    }
}
