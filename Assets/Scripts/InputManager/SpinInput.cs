using BallSystem;
using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpinInput : MonoBehaviour
{
    public Slider spinSlider;
    bool selectSpin = true;
    [SerializeField]BallManager ball;
    // Start is called before the first frame update
    void Start()
    {
    }

    public void SetListeneres()
    {
        GameManager.Instance.Reset += Reset;
    }
    public void Reset()
    {
        selectSpin = true;
    }
    public void SetSpin()
    {
        selectSpin = false;
        ball.SetSpinScalar(spinSlider.value*10);
        ball.ThrowBall();
    }

    // Update is called once per frame
    void Update()
    {
        if (selectSpin)
        {
            float pi = Mathf.PI / 2;
            float x = Mathf.Cos(Mathf.PingPong(Time.time * 3, 2 * pi));
            spinSlider.value = x;
        }

    }
}
