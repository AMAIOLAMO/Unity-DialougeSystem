using System.Collections.Generic;

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

        private readonly Queue<GameDialouge> _dialougeQueue;

        public bool IsEndOfConversation => _dialougeQueue.Count == 0;

        public void ResetConversation()
        {
            _dialougeQueue.Clear();

            foreach (var dialougeData in ConversationData.GameDialogueDatas)
                _dialougeQueue.Enqueue(new GameDialouge(dialougeData));
        }
    }
}

