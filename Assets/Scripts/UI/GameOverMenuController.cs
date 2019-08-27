using Game;
using UnityEngine;
using Utils;

namespace UI
{
    public sealed class GameOverMenuController : MenuController
    {
        protected override void UpdateVisibility(GameState gameState)
        {
            canvas.enabled = gameState == GameState.GameOver;
        }
    }
}