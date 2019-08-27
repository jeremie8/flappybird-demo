using System;
using System.Collections;
using Game;
using UnityEngine;
using Utils;

namespace Actuators
{
    public class PipeSpawnPoint : MonoBehaviour
    {
        [SerializeField] private int spawnDelay = 3;

        private GameController gameController;
        private PrefabFactory prefabFactory;

        private void Awake()
        {
            gameController = Finder<GameController>.Find;
            prefabFactory = Finder<PrefabFactory>.Find;
        }

        private void OnEnable()
        {
            StartCoroutine(SpawnPipeRoutine());
        }

        private IEnumerator SpawnPipeRoutine()
        {
            while (true)
            {
                yield return new WaitForSeconds(spawnDelay);

                if (gameController.GameState != GameState.MainMenu)
                    prefabFactory.CreatePipePair(transform.position, Quaternion.identity, null);
            }
        }
    }
}