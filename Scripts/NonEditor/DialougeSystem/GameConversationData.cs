using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CXUtils.DialogSystem
{
    /// <summary>
    ///     A list of <see cref="GameDialogData" />
    /// </summary>
    [Serializable]
    [CreateAssetMenu( fileName = "New GameConversation", menuName = "CXUtils/DialogSystem/GameConversationData" )]
    public class GameConversationData : ScriptableObject, IEnumerable<GameDialogData>
    {
        [SerializeField] GameDialogData[] dialogDataArray;
        public GameConversationData( params GameDialogData[] dialogueDataArray ) =>
            dialogDataArray = dialogueDataArray;

        public GameDialogData[] DialogDataArray => dialogDataArray;

        public IEnumerator<GameDialogData> GetEnumerator() => new ConversationEnumerator( dialogDataArray );
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        class ConversationEnumerator : IEnumerator<GameDialogData>
        {
            readonly GameDialogData[] _dialogues;
            Queue<GameDialogData> _dialogQueue;

            public ConversationEnumerator( GameDialogData[] dialogues )
            {
                _dialogues = dialogues;
                _dialogQueue = new Queue<GameDialogData>( dialogues );
            }

            public bool MoveNext()
            {
                if ( _dialogQueue.Count == 0 ) return false;

                Current = _dialogQueue.Dequeue();
                return true;
            }
            public void Reset()
            {
                _dialogQueue = new Queue<GameDialogData>( _dialogues );
            }
            public GameDialogData Current { get; private set; }
            object IEnumerator.Current => Current;
            public void Dispose() { }
        }
    }
}
