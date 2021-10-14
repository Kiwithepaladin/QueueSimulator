using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace FillingGround.QueueGame
{
    public class QueueSupervisorUI : MonoBehaviour
    {
        [SerializeField] private GameObject StartQueuePanel;
        [SerializeField] private TextMeshProUGUI playersQueuedText;
        [SerializeField] private GameObject queuePanel;
        private bool IsRunning;
        private void Awake()
        {
            queuePanel.SetActive(false);
        }
        private void Update()
        {
            if(playersQueuedText.text != QueueSupervisor.playersPosition.ToString() && QueueSupervisor.playersPosition > -1)
            {
                playersQueuedText.text = QueueSupervisor.playersPosition.ToString();
            }
            else
            {
                if(!IsRunning)
                    StartCoroutine(LoginText(playersQueuedText));
            }
            if(!queuePanel.activeInHierarchy && QueueSupervisor.isInQueue)
            {
                ActivateQueuePanel();
            }
            if(queuePanel.activeInHierarchy && !QueueSupervisor.isInQueue)
            {
                DeactivateQueuePanel();
            }
            if(QueueSupervisor.Defeated)
            {
                playersQueuedText.text = "Defeated!";
            }
        }
        public void ActivateQueuePanel()
        {
            LeanTween.cancel(queuePanel);
            queuePanel.transform.localScale = Vector3.zero;


            LeanTween.moveLocal(queuePanel, Vector3.zero,0.7f).setOnStart(() => 
            {
                LeanTween.scale(queuePanel,new Vector3(1f,1f,1f),0.7f);
                queuePanel.SetActive(true);
                StartQueuePanel.SetActive(false);
            });
        }
        public void DeactivateQueuePanel()
        {
            // LeanTween.cancel(queuePanel);
            queuePanel.transform.localScale = Vector3.one;


            LeanTween.scale(queuePanel,Vector3.zero,0.5f).setOnComplete(() =>{
                queuePanel.SetActive(false);
                StartQueuePanel.SetActive(true);
                queuePanel.transform.localPosition = new Vector3(-750f,-200f);
            });
        }
        private IEnumerator LoginText(TextMeshProUGUI textObject)
        {
            while(QueueSupervisor.playersPosition <= -1)
            {
                IsRunning = true;
                textObject.text = "Logging in.";
                yield return new WaitForSeconds(1f);
                textObject.text = "Logging in..";
                yield return new WaitForSeconds(1f);
                textObject.text = "Logging in...";
                yield return new WaitForSeconds(1f);
                textObject.text = "Logging in....";
            }
            IsRunning = false;
        }
    }
}