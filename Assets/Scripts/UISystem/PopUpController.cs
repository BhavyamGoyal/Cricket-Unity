using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace UISystem
{
    public class PopUpController : MonoBehaviour
    {
        [SerializeField] Text message;
        [SerializeField] Text scoreText;
        [SerializeField] Button restart;
        UIManager uiManager;
        public void ShowPopUp(string message, int score)
        {
            scoreText.text = "SCORE: " + score;
            gameObject.SetActive(true);
            this.message.text = message;
        }
        public void SetManager(UIManager uiManager)
        {
            this.uiManager = uiManager;
        }
        public void Hide()
        {
            gameObject.SetActive(false);
        }
        public void RestartGame()
        {
            uiManager.NotifyRestart();
        }
        private void OnEnable()
        {
            restart.onClick.AddListener(RestartGame);
        }
        private void OnDisable()
        {
            restart.onClick.RemoveListener(RestartGame);
        }
    }
}
