using System;
using System.Collections;
using Events;
using UnityEngine;
using UnityEngine.SceneManagement;
using Utils;

namespace Game
{
    public class GameController : MonoBehaviour
    {
        [SerializeField] private KeyCode startGameKey = KeyCode.Space;

        private GameState gameState = GameState.MainMenu;

        private PlayerDeathEventChannel playerDeathEventChannel;
        private PipePassedEventChannel pipePassedEventChannel;
        
        public event GameStateChangedEventHandler OnGameStateChanged;
        public event ScoreChangedEventHandler OnScoreChanged;

        private int score;

        public int Score
        {
            get => score;
            set
            {
                if (score != value)
                {
                    score = value;
                    if (OnScoreChanged != null) OnScoreChanged(value);
                }
            }
        }

        private void Awake()
        {
            playerDeathEventChannel = Finder<PlayerDeathEventChannel>.Find;
            pipePassedEventChannel = Finder<PipePassedEventChannel>.Find;
        }

        private void OnEnable()
        {
            playerDeathEventChannel.OnPlayerDeath += EndGame;
            pipePassedEventChannel.OnPipePassed += AddPoint;
        }

        private void Start()
        {
            if (!SceneManager.GetSceneByName(Scenes.GAME).isLoaded)
                StartCoroutine(LoadGame());
            else
                SceneManager.SetActiveScene(SceneManager.GetSceneByName(Scenes.GAME));
        }

        private void AddPoint()
        {
            Score += 1;
        }

        private void OnDisable()
        {
            playerDeathEventChannel.OnPlayerDeath -= EndGame;
            pipePassedEventChannel.OnPipePassed -= AddPoint;
        }

        private void EndGame()
        {
            GameState = GameState.GameOver;
        }
        
        public GameState GameState
        {
            get => gameState;
            private set
            {
                if (gameState != value)
                {
                    gameState = value;
                    if (OnGameStateChanged != null) OnGameStateChanged(gameState);
                }
            }
        }

        private void Update()
        {
            if (GameState == GameState.MainMenu && Input.GetKeyDown(startGameKey))
                GameState = GameState.Playing;

            if (GameState == GameState.GameOver && Input.GetKeyDown(startGameKey))
                RestartGame();
        }

        private void RestartGame()
        {
            GameState = GameState.MainMenu;
            score = 0;

            StartCoroutine(ReloadGame());
        }

        private IEnumerator ReloadGame()
        {
            yield return UnloadGame();
            yield return LoadGame();
        }
        
        private IEnumerator LoadGame()
        {
            yield return SceneManager.LoadSceneAsync(Scenes.GAME, LoadSceneMode.Additive);
            SceneManager.SetActiveScene(SceneManager.GetSceneByName(Scenes.GAME));
        }
        
        private IEnumerator UnloadGame()
        {
            yield return SceneManager.UnloadSceneAsync(Scenes.GAME);
        }

        public delegate void GameStateChangedEventHandler(GameState gameState);

        public delegate void ScoreChangedEventHandler(int score);
    }

    public enum GameState
    {
        MainMenu,
        Playing,
        GameOver
    }
}