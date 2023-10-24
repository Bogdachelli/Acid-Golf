using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace Golf
{

	public class Stick : MonoBehaviour
	{
		public UnityEvent<Collider> onCollision;
        

        private void OnCollisionEnter(Collision collision)
		{
			GetComponent<AudioSource>().Play();
			onCollision.Invoke(collision.collider);
		}
	}

}