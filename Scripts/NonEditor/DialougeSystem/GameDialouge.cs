using System;
using System.Collections.Generic;

namespace CXUtils.DialougeSystem
{
    /// <summary>
    /// A single GameDialouge that manages a piece of dialouge data
    /// </summary>
    public class GameDialouge
    {
        public GameDialouge(GameDialougeData dialougeData)
        {
            DialougeData = dialougeData;
            
            ResetDialouge();
        }

        public readonly GameDialougeData DialougeData;

        private Queue<GameSentence> _dialougeQueue;

        /// <summary>
        /// Is the Dialouge queue empty?
        /// </summary>
        public bool IsEndOfQueue => _dialougeQueue.Count == 0;

        /// <summary>
        /// Triggers when a next sentence is called
        /// </summary>
        public event Action<GameSentence> OnNextSentenceTriggered;

        /// <summary>
        /// Reset's the whole sentence queue
        /// </summary>
        public void ResetDialouge() =>
            _dialougeQueue = new Queue<GameSentence>(DialougeData.Sentences);

        /// <summary>
        /// Peeks like a Queue from the sentences queue
        /// </summary>
        /// <returns>The first sentence of the queue (which is the one when you Use the method <see cref="NextSentence"/>)</returns>
        public GameSentence Peek() =>
            _dialougeQueue.Peek();

        /// <summary>
        /// To the next sentence
        /// </summary>
        /// <returns>the next sentence in the queue (will be null if on end of queue)</returns>
        public GameSentence NextSentence()
        {
            //if end of queue then just return null
            if (IsEndOfQueue) return null;
            
            GameSentence newSentence = _dialougeQueue.Dequeue();
            OnNextSentenceTriggered?.Invoke(newSentence);
            return newSentence;
        }
    }
}