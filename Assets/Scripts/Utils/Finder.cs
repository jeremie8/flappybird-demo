using Events;
using Game;
using UnityEngine;

namespace Utils
{
    public static class Finder<T> where T : MonoBehaviour
    {
        private const string GAME_CONTROLLER_TAG = "GameController";
        
        private static T objectToFind;

        public static T Find {
            get
            {
                if (objectToFind == null)
                {
                    objectToFind = GameObject.FindWithTag(GAME_CONTROLLER_TAG).GetComponent<T>();
                }

                return objectToFind;
            }
            
        }
    }

}
