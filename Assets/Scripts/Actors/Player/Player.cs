using System;
using Actuators;
using Events;
using Game;
using Sensors;
using UnityEngine;
using Utils;

namespace Actors.Player
{
    [RequireComponent(typeof(FlapMover))]
    public class Player : MonoBehaviour
    {
        [SerializeField] private float targetMainMenuHeight = 0f;

        private UpdatePlayer updatePlayer;

        private PlayerDeathEventChannel playerDeathEventChannel;
        
        private GameController gameController;
        private FlapMover playerMover;
        private Sensor sensor;
        private void Awake()
        {
            gameController = Finder<GameController>.Find;
            
            playerMover = GetComponent<FlapMover>();
            sensor = GetComponentInChildren<Sensor>();
            playerDeathEventChannel = Finder<PlayerDeathEventChannel>.Find;

            updatePlayer = UpdatePlayerInMainMenu;
        }

        private void OnEnable()
        {
            gameController.OnGameStateChanged += GameStateChanged;
            sensor.OnHit += OnHit;
        }

        private void OnDisable()
        {
            gameController.OnGameStateChanged -= GameStateChanged;
            sensor.OnHit -= OnHit;
        }

        private void Update()
        {
            updatePlayer?.Invoke();
        }
        
        private void OnHit(GameObject other)
        {
            Die();
        }
        
        [ContextMenu("Die")]
        private void Die()
        {
            Destroy(gameObject);
            playerDeathEventChannel.NotifyPlayerDeath();
        }
        
        private void GameStateChanged(GameState gameState)
        {
            if (gameState == GameState.MainMenu)
                updatePlayer = UpdatePlayerInMainMenu;
            else if (gameState == GameState.Playing)
                updatePlayer = UpdatePlayerInGame;
        }

        private delegate void UpdatePlayer();

        private void UpdatePlayerInMainMenu()
        {
            if (transform.position.y < targetMainMenuHeight)
                playerMover.Flap();
        }

        private void UpdatePlayerInGame()
        {
            if (Input.GetKeyDown(KeyCode.Space))
                playerMover.Flap();
        }
    }
}