using System;
using System.Collections.Generic;
using UnityEngine;

namespace CXUtils.DialougeSystem
{
    /// <summary>
    ///     A single piece of dialouge that stores a list of sentences
    ///     (Not intended for modifying)
    /// </summary>
    [CreateAssetMenu(fileName = "gameDialouge", menuName = "CXUtils/DialougeSystem/GameDialouge")]
    [Serializable]
    public class GameDialougeData : ScriptableObject
    {
        public GameDialougeData(params GameSentence[] sentences) =>
            this.sentences = sentences;
        public GameSentence[] Sentences => sentences;
        [SerializeField] private GameSentence[] sentences;
    }
}