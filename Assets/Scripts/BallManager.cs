using Common;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BallSystem
{
    public class BallManager : MonoBehaviour
    {
        [SerializeField] PitchInput markerPos;
        public Vector3 defaultPosition; // ball's default beginning position
        public float ballSpeed; // speed of the ball
        public GameObject ball; // stores the ball game object
        public float bounceScalar; // the bounce scalar value to scale the bounce angle after the ball hits the ground
        float spinScalar; // the ball's spin scalar value
        public float realWorldBallSpeed; // the ball's speed to display on the UI which corresponds to the real world units(kmph)
                                         //  public GameObject trajectoryHolder; // the holder game object to parent each trajectory ball object to
        public int ballType; // the balls type; 0 - straight, 1 - leg spin, 2 - off spin
        private bool isBallThrown;
        bool Stumphit = false;
        private float angle; // the bounce angle of the ball after the ball hits the ground for the first time
        private Vector3 startPosition; // ball's startPosition for the lerp function
        private Vector3 targetPosition; // ball's targetPosition for the lerp function
        private Vector3 direction; // the direction vector the ball is going in
        private Rigidbody rb; // rigidbody of the ball
        private float spinBy; // value to spin the ball by
        private bool firstBounce; 
        public float BallSpeed { set { ballSpeed = value; } }
        public int BallType { set { ballType = value; } }
        public void SetSpinScalar(float spinValue)
        {
            spinScalar = spinValue;
        }
        public void SetListeneres()
        {
            GameManager.Instance.Reset += Reset;
        }
        void Start()
        {
            defaultPosition = transform.position; // set defaultPosition to the balls beginning position
            rb = gameObject.GetComponent<Rigidbody>();
            startPosition = transform.position;  // set the startPosition to the balls beginning position
        }

        public void Reset()
        {
            ResetBall();
        }
        public void StopBall()
        {
            rb.velocity = new Vector3(0, 0, 0);
        }
        void OnCollisionEnter(Collision collision)
        {
            if (collision.gameObject.CompareTag("Ground"))
            {
                Debug.Log(spinScalar);
                spinBy = spinScalar / ballSpeed;

                if (!firstBounce)
                {   firstBounce = true; // set the firstBounce bool to true
                    rb.useGravity = true; // allow the gravity to affect the ball
                    direction = new Vector3(spinBy, -direction.y * (bounceScalar * ballSpeed), direction.z);
                    direction = Vector3.Normalize(direction); // normalize the direction value
                    angle = Mathf.Atan2(direction.y, direction.z) * Mathf.Rad2Deg; // calculte the bounce angle from the direction vector
                    rb.AddForce(direction * ballSpeed, ForceMode.Impulse);
                }
            }
            else if (collision.gameObject.CompareTag("Stump"))
            {
                Debug.Log("hit the stumps");
                GameManager.Instance.SetForNextBall();
                if (!Stumphit)
                {
                    Stumphit = true;
                    GameManager.Instance.UpdateScore();
                }
                collision.gameObject.GetComponent<Rigidbody>().useGravity = true; // set the stump's rigidbody to be affected by gravity
            }
            else if (collision.gameObject.CompareTag("World")) {
                GameManager.Instance.SetForNextBall();
            }
        }

        public void ThrowBall()
        {
            if (!isBallThrown)
            { // if the ball is not thrown, throw the ball
                isBallThrown = true;
                Stumphit = false;
                //CanvasManagerScript.instance.EnableBatSwipePanel(); // Enable the bat swipe panel 
                targetPosition = markerPos.GetMarkerPosition(); // make the balls target position to the markers position
                direction = Vector3.Normalize(targetPosition - startPosition); // calculate the direction vector
                rb.AddForce(direction * ballSpeed, ForceMode.Impulse); // Add an instant force impulse in the direction vector multiplied by ballSpeed to the ball considering its mass
            }
        }
        public void ResetBall()
        { // reset the values
            firstBounce = false;
            isBallThrown = false;
            rb.velocity = Vector3.zero;
            rb.useGravity = false;
            transform.position = defaultPosition;

            // Destroy trajectory balls if childCount of the trajectory holder is greater than 0
            //int childCount = trajectoryHolder.transform.childCount;
        }
    }
}