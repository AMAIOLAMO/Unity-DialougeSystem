using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CXUtils.DialougeSystem
{
    /// <summary>
    /// A conversation stored a list of <see cref="GameDialouge"/> so you could call <br/>
    /// a list of dialouges to speak together (normally used with a conversation together)
    /// </summary>
    public class GameConversation
    {
        public GameConversation(params GameDialouge[] gameDialogues) =>
            this.gameDialogues = new List<GameDialouge>(gameDialogues);

        public readonly List<GameDialouge> gameDialogues;

        private Queue<GameDialouge> _dialougeQueue;

        public bool IsEndOfConversation => _dialougeQueue.Count == 0;

        public event Action<GameDialouge> OnNextDialougeCalled;

        public void ResetDialogues() =>
            _dialougeQueue = new Queue<GameDialouge>(gameDialogues);

        public GameDialouge NextDialogue()
        {
            if (IsEndOfConversation) return null;
            
            var newDialouge = _dialougeQueue.Dequeue();
            OnNextDialougeCalled?.Invoke(newDialouge);
            return newDialouge;
        }
    }
}

