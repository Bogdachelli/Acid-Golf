using System;
using System.Collections;
using System.Collections.Generic;
using TestXlab;
using UnityEngine;

namespace Golf
{
    public class Acid_Controller : MonoBehaviour
    {
      
        [SerializeField] private GameObject[] clouds;
        [SerializeField] private GameObject[] rainObj;
        [SerializeField] private Material neutral_cloud;
        [SerializeField] private Material neutral_lake;
        [SerializeField] private GameObject lake;
        public static Action onRainStop;
        public static Action onCloudClear;
        public static Action onLakeClear;


        private void OnEnable()
        {
            LevelController.onScore += ChangeAcid;
        }


        private void ChangeAcid(int score)
        {

            if (score > 5)
            { 
                    for (int i = 0; i < clouds.Length; i++)
                    {

                        rainObj[i].SetActive(false);
                    
                    }
                onRainStop?.Invoke();
            }

            if (score > 7)
            { 
            
                    for (int i = 0; i < clouds.Length; i++)
                    {
                       
                        clouds[i].GetComponent<MeshRenderer>().material = neutral_cloud; 
                    }

                onCloudClear?.Invoke();
            }
            
            if (score > 10)
            { 
                lake.GetComponent<MeshRenderer>().material = neutral_lake;
                onLakeClear?.Invoke();
            }
        }
        private void OnDisable()
        {
            LevelController.onScore -= ChangeAcid;
            for (int i = 0; i < clouds.Length; i++)
            {

                rainObj[i].SetActive(true);

            }
        }
    }
}
