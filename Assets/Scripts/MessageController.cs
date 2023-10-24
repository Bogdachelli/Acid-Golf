using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

namespace Golf
{
        public class MessageController : MonoBehaviour
        {
            [SerializeField] GameObject imgMsgToPlayer;
            [SerializeField] TMP_Text msgToPlayer;
            private void OnEnable()
            {
                ImgActive(true);
                Acid_Controller.onRainStop += RainStopToMsg;
                Acid_Controller.onCloudClear += CloudClearToMsg;
                Acid_Controller.onLakeClear += LakeClearToMsg;
                GameplayState.onGamePlay += WarningMsg;
            }
           private void Start()
            {
                StartCoroutine(DisactiveMsg());
            }

            private void WarningMsg()
            {
                msgToPlayer.text = "Не допускай падение желтых шаров-нейтрализаторов\nдруг на друга. Они могут взорваться!!!";
                ActiveMsg();
                DisactiveMsg();
            }
            private void RainStopToMsg()
            {
                msgToPlayer.text = "Ура! Кислотный дождь прекратился.\n";
                ActiveMsg();
                DisactiveMsg();
            
            }

            private void CloudClearToMsg()
            {
                msgToPlayer.text = "Молодец!\nТвои усилия очистили облака, продолжай в том же духе.";
                ActiveMsg();
                DisactiveMsg();
            }
            private void LakeClearToMsg()
            {
                msgToPlayer.text = "Ты сумел очистить озеро!\nБлагодаря тебе в нем скоро снова появится жизнь!";
                ActiveMsg();
                DisactiveMsg();
            }

            private IEnumerator DisactiveMsg()
            { 
                yield return new WaitForSeconds(2);
                imgMsgToPlayer.SetActive(false);

            }

            private void ActiveMsg()
            {
                imgMsgToPlayer.SetActive(true);

            }
        private void ImgActive(bool active)
        {
            imgMsgToPlayer.gameObject.SetActive(active);

        }

            private void OnDisable()
            {
                ImgActive(false);
                Acid_Controller.onRainStop -= RainStopToMsg;
                Acid_Controller.onCloudClear -= CloudClearToMsg;
                Acid_Controller.onLakeClear -= LakeClearToMsg;
                GameplayState.onGamePlay -= WarningMsg;
            }
        }
    
}
