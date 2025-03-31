﻿using UnityEngine;

namespace Game
{
    public class Storage
    {
        private const string LAST_LEVEL_KEY = "Level";

        public void SaveLastLevel(int index)
        {
            PlayerPrefs.SetInt(LAST_LEVEL_KEY, index);
            PlayerPrefs.Save();
        }

        public int GetLastLevelIndex()
        {
            return PlayerPrefs.GetInt(LAST_LEVEL_KEY);
        }
    }
}