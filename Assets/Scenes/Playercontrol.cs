using UnityEngine;
using UnityEngine.UI;
//using UnityEngine.InputSystem;
public class Playercontrol : MonoBehaviour {
    public float speed = 4f;
    private float gravity = 0;
    private CharacterController controller;
    public Text speedtext;
    //PlayerCtrll controls;

    /*    void Awake() {
            controls = new PlayerCtrll();
            controls.stick.up.performed += ctx => PlayerMovement();
        }*/

    void Start() {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update() {
        PlayerMovement();
        /*        if (Input.GetButtonDown("Fire1")) {
                    Debug.Log("Fire1");
                }
                if (Input.GetButtonDown("Fire2")) {
                    Debug.Log("Fire2");
                }
                if (Input.GetButtonDown("Fire3")) {
                    Debug.Log("Fire3");
                }
                if (Input.GetButtonDown("Jump")) {
                    Debug.Log("Jump");
                }
                if (Input.GetButtonDown("Submit")) {
                    Debug.Log("Submit");
                }
                if (Input.GetButtonDown("Cancel")) {
                    Debug.Log("Cancel");
                }
            }*/

        void PlayerMovement() {
            float horizontal = Input.GetAxis("Horizontal");
            float vertical = Input.GetAxis("Vertical");
            float altitude = 0;
            if (Input.GetButton("Cancel")) {
                altitude = 1;
            }
            if (Input.GetButton("Submit")) {
                altitude = -1;
            }
            if (Input.GetButtonDown("Fire1")) {
                speed += 5f;
                speedtext.text = "Speed: " + speed;
            }
            /*        if (Input.GetButtonDown("Fire3")) {
                            speedtext.text = "fire3";
                    }*/
            if (Input.GetButtonDown("Jump")) {
                if (speed >= 8) {
                    speed -= 5f;
                    speedtext.text = "Speed: " + speed;
                }
            }
            Vector3 direction = new Vector3(horizontal, altitude, vertical);
            Vector3 velocity = direction * speed;
            velocity = Camera.main.transform.TransformDirection(velocity);
            //velocity.y -= gravity;
            controller.Move(velocity * Time.deltaTime);
        }

        /*    void OnEnable() {
                controls.stick.Enable();
            }

            void OnDisable() {
                controls.stick.Disable();   
            }*/

    }
}
