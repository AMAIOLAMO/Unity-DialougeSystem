using System;
using TMPro;
using UnityEngine;
using UnityEngine.Assertions;
using UnityEngine.UI;

namespace CXUtils.DialougeSystem.Test
{
    public class DialougSystemTest : MonoBehaviour
    {
        [SerializeField] private TextMeshProUGUI dialougeText;

        [SerializeField] private Button dialougeNextButton;

        [SerializeField] private GameDialougeData testDialougeData;

        private GameDialouge _gameDialouge;

        private void Awake()
        {
            _gameDialouge = new GameDialouge(testDialougeData);
            
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