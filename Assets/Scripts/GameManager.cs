using BallSystem;
using System;
using System.Collections;
using System.Collections.Generic;
using UISystem;
using UnityEngine;
namespace Common
{
    public class GameManager : Singleton<GameManager>
    {
        int Score = 0;
        [SerializeField] BallManager ballManager;
        [SerializeField] PopUpController popUp;
        [SerializeField] SpinInput spinInput;
        public GameObject stump1, stump2, stump3;
        Vector3 pst1, pst2, pst3;
        Quaternion Rst1, Rst2, Rst3;
        UIManager uiManager;
        [SerializeField] GameUIController gameUI;

        private void Start()
        {
            pst1 = stump1.transform.position;
            pst2 = stump2.transform.position;
            pst3 = stump3.transform.position;
            Rst1 = stump1.transform.rotation;
            Rst2 = stump2.transform.rotation;
            Rst3 = stump3.transform.rotation;

            Debug.Log(stump3.transform.position+"  "+pst3);
            uiManager = new UIManager(popUp, spinInput, gameUI);
            spinInput.SetListeneres();
            ballManager.SetListeneres();
        }
        public event Action Reset;

        public void UpdateScore()
        {
            Score++;
            uiManager.UpdateScore(Score);
        }
        public void SetForNextBall()
        {
            spinInput.gameObject.SetActive(false);
            uiManager.SetPopUp("try again", Score);
        }
        public void ResetGame()
        {
            Debug.Log(stump3.transform.position+"  "+pst3);
            stump1.transform.position = pst1;
            stump1.transform.rotation = Rst1;
            stump1.GetComponent<Rigidbody>().velocity = Vector3.zero;
            stump1.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            stump2.transform.position = pst2;
            stump2.transform.rotation = Rst2;
            stump2.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            stump2.GetComponent<Rigidbody>().velocity = Vector3.zero;
            stump3.transform.position = pst3;
            stump3.transform.rotation = Rst3;
            stump3.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            stump3.GetComponent<Rigidbody>().velocity = Vector3.zero;
            Reset.Invoke();
        }
    }
}