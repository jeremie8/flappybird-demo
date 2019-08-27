using System;
using Game;
using UnityEngine;
using Utils;

namespace UI
{
    public sealed class MainMenuController : MenuController
    {
        protected override void UpdateVisibility(GameState gameState)
        {
            canvas.enabled = gameState == GameState.MainMenu;
        }
    }
}