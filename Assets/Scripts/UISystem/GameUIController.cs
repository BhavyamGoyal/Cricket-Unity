using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
namespace UISystem
{
    public class GameUIController : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] Text scoreText;
        public void UpdateScoreText(int score)
        {
            scoreText.text = score.ToString();
        }
        public void HideText()
        {
            this.gameObject.SetActive(false);
        }
        public void ShowText()
        {
            this.gameObject.SetActive(true);
        }
    }
}