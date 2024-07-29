using UnityEngine;

namespace GameData.Player.PlayerData
{
    public struct PlayerInfo
    {
        public static Transform PlayerTransform = null;
        public static void WritePlayerTransform(Transform transform)
        {
            PlayerTransform = transform;
        }
    }
}