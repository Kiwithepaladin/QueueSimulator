using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

namespace FillingGround.QueueGame.MiniGames
{
    [RequireComponent(typeof(BathroomMiniGameComponentUI))]
    public class BathroomMiniGameComponent : MonoBehaviour, IPointerDownHandler, IPointerExitHandler, IPointerUpHandler
    {
        [SerializeField] private bool ButtonHeld = false;
        public bool IsButtonHeld()
        {
            return ButtonHeld;
        }
        public void OnPointerDown(PointerEventData eventData)
        {
            StartCoroutine(HoldButtonDown());
        }
        public void OnPointerExit(PointerEventData eventData)
        {
            StopAllCoroutines();
        }
        public void OnPointerUp(PointerEventData eventData)
        {
            StopAllCoroutines();
        }
        private IEnumerator HoldButtonDown()
        {
            yield return new WaitForSeconds(2f);
            BathroomMiniGameUI.RequireUIUpdate = true;
            StopAllCoroutines();
            StartCoroutine(HoldButtonDown());
        }
    }
}