using MPA.Utilits;
using TMPro;
using UnityEngine;

namespace Game.View
{
    [RequireComponent(typeof(TMP_Text))]
    public class AsteroidKillCounterUI : MonoBehaviour
    {
        private void Start()
        {
            var storage = Context.Get<Storage>();
            var source = GetComponent<TMP_Text>();
            var count = storage.GetDestroyedAsteroidsCount();

            GetComponent<TMP_Text>().text = string.Format(source.text, count);
        }
    }
}