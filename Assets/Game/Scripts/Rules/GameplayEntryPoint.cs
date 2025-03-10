using Game.Root;
using UnityEngine;

namespace Game.Rules
{
    public class GameplayEntryPoint : MonoBehaviour
    {
        public void Entry(GameplayState.Arguments args)
        {
            Debug.Log("Entry");
        }
    }
}