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
        public GameConversation(GameConversationData conversationData)
        {
            this.ConversationData = conversationData;

            _dialougeQueue = new Queue<GameDialouge>();
            ResetConversation();
        }

        public readonly GameConversationData ConversationData;

        private Queue<GameDialouge> _dialougeQueue;

        public bool IsEndOfConversation => _dialougeQueue.Count == 0;

        public void ResetConversation()
        {
            _dialougeQueue.Clear();
            
            for (int i = 0; i < ConversationData.GameDialogueDatas.Length; i++)
                _dialougeQueue.Enqueue(new GameDialouge(ConversationData.GameDialogueDatas[i]));
        }
    }
}

