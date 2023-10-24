using System;
using System.Collections;
using System.Collections.Generic;
using TestXlab;
using UnityEngine;

namespace Golf
{

    public class LevelController : MonoBehaviour
    {
        public Spawner spawner;
	
		private float m_lastSpawnedTime = 0;

		public float delayMax = 3f;
		public float delayMin = 1f;
		public float delayStep = 0.08f;

		public int score = 0;
		public int hightScore = 0;

		private float m_delay = 0.5f;
		private float m_upperDelay; 

		private List<GameObject> m_stones = new List<GameObject>(16);
		public static Action<int> onScore;

		public void ClearStones()
		{
			foreach (var stone in m_stones)
			{
				Destroy(stone);
			}

			m_stones.Clear();
		}

		private void Awake()
		{	
		}

		private void Start()
		{
			m_lastSpawnedTime = Time.time;
			RefreshDelay();
		}

		private void OnEnable()
		{	
			GameEvents.onStickHit += OnStickHit;
			GameplayState.onGameOver += AudioBoomPlay;
			score = 0;
			m_upperDelay = delayMax;
		}

		private void OnDisable()
		{
			GameEvents.onStickHit -= OnStickHit;
            GameplayState.onGameOver -= AudioBoomPlay;
        }

		private void AudioBoomPlay()
		{
			GetComponent<AudioSource>().Play();
		}
		private void OnStickHit()
		{
			score++;
			onScore?.Invoke(score);
			hightScore = Mathf.Max(hightScore, score);

			Debug.Log($"score: {score} - hightScore: {hightScore}");
		}

		private void Update()
		{
			if (Time.time >= m_lastSpawnedTime + m_delay)
			{
				var stone = spawner.Spawn();
				m_stones.Add(stone);

				m_lastSpawnedTime = Time.time;

				RefreshDelay();
			}
		}

		public void RefreshDelay()
		{
			m_delay = UnityEngine.Random.Range(delayMin, m_upperDelay);
			m_upperDelay = Mathf.Max(delayMin, m_upperDelay - delayStep);
		}


		IEnumerator WaitEvent(System.Action callBack)
		{
			yield return new WaitForSeconds(delayStep);
			callBack?.Invoke();
		}
	}
}