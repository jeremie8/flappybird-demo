using System;
using System.Collections;
using Actuators;
using Game;
using UnityEngine;
using Utils;
using Random = UnityEngine.Random;

namespace Props
{
    [RequireComponent(typeof(TranslateMover))]
    public class Pipe : MonoBehaviour
    {
        [Header("Behaviour")] [SerializeField] private int secondsBeforeDestroy = 20;
        [Header("Position")] [SerializeField] private float minY = -1;
        [SerializeField] private float maxY = 1;

        private GameController gameController;
        private TranslateMover translateMover;

        private Renderer renderer;

        public void Start()
        {
            gameController = Finder<GameController>.Find;
            translateMover = GetComponent<TranslateMover>();

            transform.Translate(Vector3.up * Random.Range(minY, maxY));

            renderer = GetComponentInChildren<Renderer>();
            StartCoroutine(DestroyPipe());
        }

        private void Update()
        {
            if (gameController.GameState == GameState.Playing)
                translateMover.Move();
        }

        private IEnumerator DestroyPipe()
        {
            while (isActiveAndEnabled)
            {
                yield return new WaitForSeconds(secondsBeforeDestroy);
                Destroy(gameObject);
            }
        }
    }
}