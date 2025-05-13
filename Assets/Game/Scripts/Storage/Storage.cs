using UnityEngine;

namespace Game
{
    public class Storage
    {
        private const string LAST_LEVEL_KEY = "Level";
        private const string ASTEROIDS_DESTROYED_KEY = "AsteroidsDestroyedCount";

        public void SaveLastLevel(int index)
        {
            PlayerPrefs.SetInt(LAST_LEVEL_KEY, index);
            PlayerPrefs.Save();
        }

        public int GetLastLevelIndex()
        {
            return PlayerPrefs.GetInt(LAST_LEVEL_KEY);
        }

        public void AddDestroyedAsteroid()
        {
            var count = PlayerPrefs.GetInt(ASTEROIDS_DESTROYED_KEY);
            PlayerPrefs.SetInt(ASTEROIDS_DESTROYED_KEY, ++count);
        }

        public int GetDestroyedAsteroidsCount()
        {
            return PlayerPrefs.GetInt(ASTEROIDS_DESTROYED_KEY);
        }
    }
}