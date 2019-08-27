using Game;
using UnityEngine;
using Utils;

namespace UI
{
    public abstract class MenuController : MonoBehaviour
    {
        protected Canvas canvas;
        protected GameController controller;

        protected virtual void Awake()
        {
            canvas = GetComponent<Canvas>();
            controller = Finder<GameController>.Find;
        }

        private void Start()
        {
            UpdateVisibility(controller.GameState);
        }

        private void OnEnable()
        {
            controller.OnGameStateChanged += UpdateVisibility;
        }

        private void OnDisable()
        {
            controller.OnGameStateChanged -= UpdateVisibility;
        }

        protected abstract void UpdateVisibility(GameState gameState);
    }
}