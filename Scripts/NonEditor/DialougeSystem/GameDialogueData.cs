using System;
using UnityEngine;

namespace CXUtils.DialougeSystem
{
    /// <summary>
    ///     A single piece of dialouge that stores a list of sentences
    ///     (Not intended for modifying externally (only in UnityEditor))
    /// </summary>
    [CreateAssetMenu( fileName = "GameDialogue", menuName = "CXUtils/DialougeSystem/GameDialogueData" )]
    [Serializable]
    public class GameDialogueData : ScriptableObject
    {
        [SerializeField] private GameSentence[] sentences;

        public GameSentence[] Sentences => sentences;

        public GameDialogueData( params GameSentence[] sentences ) =>
            this.sentences = sentences;

        public string ToJson() => JsonUtility.ToJson( this );
    }
}