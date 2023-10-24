using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Golf
{
    public class GameplayState : GameState
	{
        public LevelController levelController;
        public PlayerController playerController;
		public GameState gameOverState;
		public GameObject messageController;
		public TMP_Text scoreText;
		public static Action onGamePlay;
		public static Action onGameOver;

		protected override void OnEnable()
		{
			messageController.gameObject.SetActive(true);
            base.OnEnable();

			levelController.enabled = true;
			playerController.enabled = true;

			GameEvents.onCollisionStones += OnGameOver;
			GameEvents.onStickHit += OnStickHit;

			OnStickHit();
			onGamePlay?.Invoke();
		}

		private void OnStickHit()
		{
			scoreText.text = $"score : {levelController.score}";
		}

		private void OnGameOver()
		{
			Exit();
			gameOverState.Enter();
		}

		protected override void OnDisable()
		{
			
			onGameOver?.Invoke();

			base.OnDisable();

			GameEvents.onCollisionStones -= OnGameOver;

			if (levelController)
			{
				levelController.enabled = false;
			}

			if (playerController)
			{
				playerController.enabled = false;
			}

		}
	}
}
