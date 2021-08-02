using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CXUtils.DialogSystem
{
    /// <summary>
    ///     A single piece of dialog that stores a list of sentences
    /// </summary>
    [CreateAssetMenu( fileName = "GameDialog", menuName = "CXUtils/DialogSystem/GameDialogData" )]
    [Serializable]
    public class GameDialogData : ScriptableObject, IEnumerable<GameSentence>
    {
        [SerializeField] GameSentence[] sentences;

        public GameDialogData( params GameSentence[] sentences ) => this.sentences = sentences;

        public GameSentence[] Sentences => sentences;

        public IEnumerator<GameSentence> GetEnumerator() => new DialogEnumerator( sentences );
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public string ToJson() => JsonUtility.ToJson( this );

        class DialogEnumerator : IEnumerator<GameSentence>
        {
            readonly GameSentence[] _sentences;
            Queue<GameSentence> _sentenceQueue;
            
            public DialogEnumerator( GameSentence[] sentences )
            {
                _sentences = sentences;
                _sentenceQueue = new Queue<GameSentence>( sentences );
            }

            public bool MoveNext()
            {
                if ( _sentenceQueue.Count == 0 ) return false;

                Current = _sentenceQueue.Dequeue();
                return true;
            }
            public void Reset()
            {
                _sentenceQueue = new Queue<GameSentence>( _sentences );
            }
            public GameSentence Current { get; private set; }
            object IEnumerator.Current => Current;
            public void Dispose() { }
        }
    }
}
