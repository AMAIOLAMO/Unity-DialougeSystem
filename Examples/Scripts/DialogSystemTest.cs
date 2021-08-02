using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace CXUtils.DialogSystem.Test
{
    public class DialogSystemTest : MonoBehaviour
    {
        [SerializeField] TextMeshProUGUI dialogText;
        [SerializeField] Button dialogNextButton;

        [SerializeField] GameDialogData testDialogData;

        IEnumerator<GameSentence> _sentenceEnumerator;

        void Awake()
        {
            _sentenceEnumerator = testDialogData.GetEnumerator();
        }

        void OnEnable()
        {
            dialogNextButton.onClick.AddListener( NextSentence );
        }

        void OnDisable()
        {
            dialogNextButton.onClick.RemoveListener( NextSentence );
        }

        // For a test button to trigger
        public void NextSentence()
        {
            if ( _sentenceEnumerator.MoveNext() )
            {
                UpdateDialogDisplay( _sentenceEnumerator.Current );
                return;
            }

            Debug.Log( "Bro this is the end of the Dialog you can reset the enumerator :D" );
        }

        void UpdateDialogDisplay( GameSentence nextSentence ) =>
            dialogText.text = nextSentence.Content;
    }
}
