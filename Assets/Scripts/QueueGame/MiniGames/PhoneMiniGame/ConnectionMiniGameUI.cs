using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Ink.Runtime;
using TMPro;
using UnityEngine.UI;

namespace FillingGround.QueueGame.MiniGames
{
    #if UNITY_EDITOR
    [ExecuteInEditMode]
    #endif
    public class ConnectionMiniGameUI : MonoBehaviour
    {
        private ConnectionMiniGame miniGame;
        [Header("Json File")]
        [SerializeField] private TextAsset inkJson;
        [Header("UI")]
        [SerializeField] private TextMeshProUGUI dialogueText;
        [SerializeField] private List<GameObject> choices;
        [SerializeField] private List<TextMeshProUGUI> choicesTexts;
        [SerializeField] private Button phoneSmallButton;
        [SerializeField] private Image phoneBigImage; 
        [SerializeField] private GameObject dialougeGameObject;  
        private void Awake()
        {
            miniGame = GetComponent<ConnectionMiniGame>();
            miniGame.SetCurrentStory(inkJson);
            phoneBigImage.gameObject.SetActive(false);
            InitializeChoicesTexts();
        }
        private void Update()
        {
            if(!QueueSupervisor.isInQueue)
            {
                phoneSmallButton.interactable = false;
                return;
            }
            else
            {
                if(phoneBigImage.IsActive())
                {
                    ContinueStory();
                    if(Input.GetMouseButtonDown(1))
                    {
                        DisablePhone();
                    }
                }
                phoneSmallButton.interactable = true;
            }
        }
        public void DisablePhone()
        {
            miniGame.GetCurrentStory().ResetState();
            phoneSmallButton.gameObject.SetActive(true);
            phoneBigImage.gameObject.SetActive(false);
            EndPhoneCall();
        }
        public void EnablePhone()
        {
            phoneSmallButton.gameObject.SetActive(false);
            phoneBigImage.gameObject.SetActive(true);
        }
        private void InitializeChoicesTexts()
        {
            choicesTexts = new List<TextMeshProUGUI>();
            int index = 0;
            foreach (GameObject choice in choices)
            {
                TextMeshProUGUI newChoice = choice.GetComponentInChildren<TextMeshProUGUI>();
                choicesTexts.Add(newChoice);
                index++;
            }
        }
        private void DisplayChoices()
        {
            List<Choice> currentChoices = miniGame.GetCurrentStory().currentChoices;

            if(currentChoices.Count > choices.Count)
            {
                Debug.LogWarning("Cant support this number of choices");
            }
            int index = 0;
            foreach (Choice choice in currentChoices)
            {
                choices[index].gameObject.SetActive(true);
                choicesTexts[index].text = choice.text;
                index++;
            }
            for (int i = index; i < choices.Count; i++)
            {
                choices[i].gameObject.SetActive(false);
            }
        }
        public void StartPhoneCall()
        {
            for (int i = 0; i < dialougeGameObject.transform.childCount; i++)
            {
                dialougeGameObject.transform.GetChild(i).gameObject.SetActive(true);
            }
            ContinueStory();
            miniGame.SetInDialogue(true);
        }
        private void EndPhoneCall()
        {
            for (int i = 0; i < dialougeGameObject.transform.childCount; i++)
            {
                dialougeGameObject.transform.GetChild(i).gameObject.SetActive(false);
            }
            miniGame.SetInDialogue(false);
        }
        private void ContinueStory()
        {
            if (miniGame.GetCurrentStory().canContinue)
            {
                dialogueText.text = miniGame.GetCurrentStory().Continue();
                DisplayChoices();
            }
        }
    }
}