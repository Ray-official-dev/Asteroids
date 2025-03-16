using UnityEngine;

namespace Game.View
{
    public class Ship : MonoBehaviour
    {
        public void Delete()
        {
            Destroy(gameObject);
        }
    }
}