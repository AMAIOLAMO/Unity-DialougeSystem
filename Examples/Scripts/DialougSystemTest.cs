using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CXUtils.DialougeSystem.Test
{
    public class DialougSystemTest : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI dialougeText;

        [SerializeField] private Button dialougeNextButton;

        [SerializeField] private GameDialogueData testDialogueData;

        private GameDialouge _gameDialouge;

        private void Awake()
        {
            _gameDialouge = new GameDialouge( testDialogueData );
        }

        private void OnEnable()
        {
            // Use code for better linking (so we don't do manually)
            dialougeNextButton.onClick.AddListener( NextSentence );

            _gameDialouge.OnNextSentenceTriggered += UpdateDialougeDisplay;
        }

        private void OnDisable()
        {
            dialougeNextButton.onClick.RemoveListener( NextSentence );

            _gameDialouge.OnNextSentenceTriggered -= UpdateDialougeDisplay;
        }

        // For a test button to trigger
        public void NextSentence()
        {
            if ( _gameDialouge.NextSentence() == null )
                Debug.Log( "Bro this is the end of the Dialouge queue :D" );
        }

        private void UpdateDialougeDisplay( GameSentence nextSentence ) =>
            dialougeText.text = nextSentence.Content;
    }
}