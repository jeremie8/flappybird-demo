using System;
using System.Collections;
using Game;
using UnityEngine;
using Utils;

namespace Actuators
{
    public class PipeSpawnPoint : MonoBehaviour
    {
        [SerializeField] private GameObject pipePrefab;
        [SerializeField] private int spawnDelay = 3;

        private GameController gameController;

        private void Awake()
        {
            gameController = Finder<GameController>.Find;
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
                
                if(gameController.GameState != GameState.MainMenu)
                    Instantiate(pipePrefab, transform.position, Quaternion.identity);
            }
        }
    }
}