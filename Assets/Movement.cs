using UnityEngine;
using System.Collections;
    public class Movement : MonoBehaviour
    {

        // Use this for initialization
        public float MaxSpeed = 5f;
        public float JumpForce = 200f;
        public Transform GroundChecking;
        public LayerMask Ground;
        public LayerMask DeathZone;
        public LayerMask ExitZone;
        bool grounded = false;
        bool groundedDEATH = false;
        bool Exit = false;
        float Radius = 0.2f;
        public bool Jump;
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            float Move = Input.GetAxis("Horizontal");
            Jump = Input.GetKeyDown(KeyCode.Space);
            grounded = Physics2D.OverlapCircle(GroundChecking.position, Radius, Ground);
            groundedDEATH = Physics2D.OverlapCircle(GroundChecking.position, Radius, DeathZone);
            Exit = Physics2D.OverlapCircle(GroundChecking.position, Radius, ExitZone);
            if (Jump && grounded)
            {
                rigidbody2D.AddForce(new Vector2(0, JumpForce));
            }
            if (groundedDEATH)
            {
                Application.LoadLevel(Application.loadedLevelName);
            }
            if (Exit && Input.GetKeyDown(KeyCode.Return))
            {
                Application.Quit();
            }
            rigidbody2D.velocity = new Vector2(Move * MaxSpeed, rigidbody2D.velocity.y);
        }
    }