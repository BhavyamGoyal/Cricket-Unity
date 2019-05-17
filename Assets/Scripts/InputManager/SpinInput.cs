using BallSystem;
using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpinInput : MonoBehaviour
{
    public Slider spinSlider, bounceSlider;
    bool selectSpin = true;
    bool selectBounce = true;
    [SerializeField] BallManager ball;
    // Start is called before the first frame update
    void Start()
    {
        bounceSlider.gameObject.SetActive(false);
    }

    public void SetListeneres()
    {
        GameManager.Instance.Reset += Reset;
    }
    public void Reset()
    {
        selectBounce = true;
        selectSpin = true;
        bounceSlider.gameObject.SetActive(false);
        spinSlider.gameObject.SetActive(true);
    }
    public void SetSpin()
    {
        if (selectSpin)
        {
            selectSpin = false;
            ball.SetSpinScalar(spinSlider.value * 10);
            bounceSlider.gameObject.SetActive(true);
            spinSlider.gameObject.SetActive(false);
        }
        else if (selectBounce)
        {
            selectBounce = false;
            ball.SetBounceScalar(bounceSlider.value);
            ball.ThrowBall();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (selectSpin || selectBounce)
        {

            float pi = Mathf.PI / 2;
            float x = Mathf.Cos(Mathf.PingPong(Time.time * 5, 2 * pi));
            if (!selectSpin)
            {
                bounceSlider.value = x + 1;
            }
            else
            {
                spinSlider.value = x;
            }
        }

    }
}
