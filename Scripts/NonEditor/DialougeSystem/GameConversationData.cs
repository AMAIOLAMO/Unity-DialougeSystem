using System;
using UnityEngine;

namespace CXUtils.DialougeSystem
{
    /// <summary>
    ///     A list of <see cref="GameDialogueDatas"/>
    ///     (Not intended for modifying externally (only in UnityEditor))
    /// </summary>
    [CreateAssetMenu(fileName = "NewGameConversation", menuName = "CXUtils/DialougeSystem/GameConversationData")]
    [Serializable]
    public class GameConversationData : ScriptableObject
    {
        public GameConversationData(params GameDialogueData[] dialogueDatas) =>
            this._gameDialogueDatas = dialogueDatas;

        public GameDialogueData[] GameDialogueDatas => _gameDialogueDatas;
        [SerializeField] private GameDialogueData[] _gameDialogueDatas;
    }
}