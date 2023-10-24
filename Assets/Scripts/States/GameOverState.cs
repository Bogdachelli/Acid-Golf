using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Golf
{
    public class GameOverState : GameState
	{
        public GameState mainMenuState;
        public LevelController levelController;
        public Acid_Controller acidController;
        public GameObject messageController;
        protected override void OnEnable()
        {
            messageController.gameObject.SetActive(false);
            base.OnEnable();
            acidController.enabled = false;
        }
        public void Restart()
        {
            levelController.ClearStones();

			Exit();
            mainMenuState.Enter();
        }
    }
}
