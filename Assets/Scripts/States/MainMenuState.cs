using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Golf
{
    public class MainMenuState : GameState
    {
		public LevelController levelController;
		public Acid_Controller acidController;
		public GameState gamePlayState;
		public TMP_Text scoreText;

		public void PlayGame()
		{
			Exit();
			gamePlayState.Enter();
		}

		protected override void OnEnable()
		{
			base.OnEnable();
			acidController.enabled = true;

			scoreText.text = $" HScore : {levelController.hightScore}";
		}
	}
}
