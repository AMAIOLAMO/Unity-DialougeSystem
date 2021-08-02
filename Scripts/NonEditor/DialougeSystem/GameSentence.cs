using System;
using UnityEngine;

namespace CXUtils.DialogSystem
{
    /// <summary>
    ///     A single sentence in a piece of Dialog data
    /// </summary>
    [Serializable]
    public class GameSentence
    {
        [TextArea( 5, 10 )]
        [SerializeField] string content;
        public GameSentence( string content ) => this.content = content;

        public string Content => content;
    }
}
