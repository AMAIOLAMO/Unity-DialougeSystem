using System;
using UnityEngine;

namespace CXUtils.DialougeSystem
{
    /// <summary>
    /// A single sentence in a piece of dialouge data
    /// </summary>
    [Serializable]
    public class GameSentence
    {
        public GameSentence(string content, Action onSentenceCalled = null)
        {
            _content = content;
            OnSentenceCalled = onSentenceCalled;
        }

        public string Content => _content;

        [TextArea(5, 10)]
        [SerializeField] private string _content;

        /// <summary>
        /// The action that will be called when triggered by the <see cref="GameDialouge"/>
        /// </summary>
        public event Action OnSentenceCalled;

        protected void CallOnSentenceCalled() =>
            OnSentenceCalled?.Invoke();
    }
}