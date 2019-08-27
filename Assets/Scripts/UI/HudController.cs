using System;
using Game;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace UI
{
    public sealed class HudController : MenuController
    {

        private Text text;
        protected override void Awake()
        {
            base.Awake();
            controller.OnScoreChanged += UpdateScore;
            text = GetComponentInChildren<Text>();
        }
        
        protected override void UpdateVisibility(GameState gameState)
        {
            canvas.enabled = gameState != GameState.MainMenu;
        }

        private void UpdateScore(int score)
        {
            if (text != null) text.text = score.ToString();
        }
    }
}