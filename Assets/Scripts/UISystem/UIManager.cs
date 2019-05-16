using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UISystem
{
    public class UIManager
    {

        PopUpController popUp;
        //Button playButton;
        SpinInput spinInput;
        GameUIController gameUI;
        // Start is called before the first frame update
        public UIManager(PopUpController popUp,SpinInput spinInput,GameUIController gameUI)
        {
            GameManager.Instance.Reset += Reset;
            this.gameUI = gameUI;
            this.spinInput = spinInput;
            this.popUp = popUp;
            //gameUI.HideText();
            spinInput.gameObject.SetActive(false);
            popUp.SetManager(this);
        }
        public void UpdateScore(int score)
        {
            gameUI.UpdateScoreText(score);
        }
        ~UIManager()
        {
          //  this.playButton.onClick.RemoveListener(StartGame);
        }
        private void StartGame()
        {
            gameUI.ShowText();
            //playButton.gameObject.SetActive(false);
        }
        public void SetPopUp(string message,int score)
        {
            popUp.ShowPopUp(message, score);
        }
        public void Reset()
        {
            popUp.Hide();
            spinInput.gameObject.SetActive(true);
        }
        public void NotifyRestart()
        {
        }

    }
}