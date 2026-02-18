using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;// UI

public class CameraControler : MonoBehaviour
{
    int Money = 0;

    Vector2 moveInput = Vector2.zero;
    Vector2 lookInput;
    float xRotation = 0;
    Camera head;

    [SerializeField]
    float walkingSpeed = 1.4f;

    [SerializeField]
    float jumpForce = 10;

    [SerializeField]
    float gravityMult = 2f;

    [SerializeField]
    Vector2 sensitivity = Vector2.one;

    [SerializeField]
    TMP_Text moneyText; // UI

    CharacterController controller;

    float velocityY = 0;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        head = GetComponentInChildren<Camera>();
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        moneyText.text = $"{Money}"; // UI

        // Gravity
        velocityY += Physics.gravity.y * gravityMult * Time.deltaTime;

        if (controller.isGrounded && velocityY < 0)
        {
            velocityY = -1;
        }


        // Movment
        Vector3 movment = transform.forward * moveInput.y 
        + transform.right * moveInput.x;

        movment *= walkingSpeed;
        
        movment.y = velocityY;

        controller.Move(movment * Time.deltaTime);


        // Looking
        xRotation += -lookInput.y * sensitivity.y;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        head.transform.localEulerAngles = new(
          xRotation, 0, 0
        );

        transform.Rotate(Vector3.up, lookInput.x * sensitivity.x);
    }

    void OnMove(InputValue value)
    {
        moveInput = value.Get<Vector2>();
    }

    void OnJump(InputValue value)
    {
        if (controller.isGrounded)
        {
            velocityY = jumpForce;
        }
    }

    void OnLook(InputValue value)
    {
        lookInput = value.Get<Vector2>();
    }

    void OnTriggerEnter(UnityEngine.Collider other)
    {
        if (other.gameObject.tag == "Money")
        {
            Money += 15;
        }
    }
}
