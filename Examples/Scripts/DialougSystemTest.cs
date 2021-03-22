using System;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.Serialization;
using UnityEngine.UI;

namespace CXUtils.DialougeSystem.Test
{
    public class DialougSystemTest : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI dialougeText;

        [SerializeField] private Button dialougeNextButton;

        [FormerlySerializedAs("testDialougeData")] [SerializeField] private GameDialogueData testDialogueData;

        private GameDialouge _gameDialouge;

        private void Awake()
        {
            _gameDialouge = new GameDialouge(testDialogueData);
            
            // Use code for better linking (so we don't do manually)
            dialougeNextButton.onClick.AddListener(NextSentence);

            _gameDialouge.OnNextSentenceTriggered += UpdateDialougeText;
        }

        // For a test button to trigger
        public void NextSentence()
        {
            if (_gameDialouge.NextSentence() == null)
                Debug.Log("Bro this is the end of the Dialouge queue :D");
        }

        private void UpdateDialougeText(GameSentence nextSentence) =>
            dialougeText.text = nextSentence.content;
    }
}