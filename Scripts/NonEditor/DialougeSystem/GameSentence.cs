using System;
using UnityEngine;

namespace CXUtils.DialougeSystem
{
    /// <summary>
    /// A single sentence in a piece of dialouge
    /// </summary>
    [Serializable]
    public class GameSentence
    {
        public GameSentence(string content, Action onSentenceCalled = null)
        {
            this.content = content;
            this.OnSentenceCalled = onSentenceCalled;
        }
        
        /// <summary>
        /// The content of the sentence
        /// </summary>
        [TextArea]
        public string content;

        /// <summary>
        /// The action that will be called when triggered by the <see cref="GameDialouge"/>
        /// </summary>
        public event Action OnSentenceCalled;

        protected void CallOnSentenceCalled() =>
            OnSentenceCalled?.Invoke();
    }
}