using UnityEngine;

namespace Utilits
{
    public class CameraFollower : MonoBehaviour
    {
        private void Start()
        {
            var cameraFollow = FindFirstObjectByType(typeof(CameraFollow)) as CameraFollow;

            if (cameraFollow is null)
                throw new System.Exception("Add follow camera to scene!");

            cameraFollow.Set(gameObject.transform);
        }
    }
}