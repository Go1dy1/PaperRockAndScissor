using System.Collections.Generic;
using UnityEngine;

namespace Storage
{
    public class CharacterManager : MonoBehaviour
    {
        internal static float MinDistance = 3f;
        public static List<GameObject> EnemyList = new List<GameObject>();
        public static List<GameObject> AllyList = new List<GameObject>();
    }
    public enum StateUnit
    {
        Ide,
        WalkToCastle,
    }
    public enum CardType
    {
        Stone,
        Scissors,
        Paper
    }
}