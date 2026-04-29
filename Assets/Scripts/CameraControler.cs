using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;
using UnityEngine.UI;// UI
using UnityEngine.SceneManagement;

public class CameraControler : MonoBehaviour
{
    public float Money = 0;
    public int maxHP = 100;
    public int HP;
    public int Scrap = 0;

    Vector2 moveInput = Vector2.zero;
    Vector2 lookInput;
    float xRotation = 0;

    [SerializeField]
    float walkingSpeed = 1.4f;
    [SerializeField]
    float jumpForce = 10;
    [SerializeField]
    float gravityMult = 2f;
    float velocityY = 0;
    public bool isMoving;

    [SerializeField]
    Vector2 sensitivity = Vector2.one;

    [SerializeField]
    TMP_Text moneyText; // UI
    [SerializeField]
    TMP_Text scrapText; // UI
    [SerializeField]
    Slider HPSlider; // UI

    CharacterController controller;
    Camera head;

    bool isBeingAttacked = false;

    float dmgInterval = 0.6f;
    float timeSinceDmgTaken;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        head = GetComponentInChildren<Camera>();
        controller = gameObject.GetComponent<CharacterController>();
        HPSlider.maxValue = maxHP;
        HPSlider.value = HP;
    }

    void Update()
    {
        moneyText.text = $"{Money}"; // UI
        scrapText.text = $"{Scrap}"; // UI

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

        if (movment.x != Vector3.zero.x || movment.z != Vector3.zero.z)
        {
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }


        // Looking
        xRotation += -lookInput.y * sensitivity.y;
        xRotation = Mathf.Clamp(xRotation, -90, 90);

        head.transform.localEulerAngles = new(
          xRotation, 0, 0
        );

        transform.Rotate(Vector3.up, lookInput.x * sensitivity.x);


        // Player taking dmg 
        if (isBeingAttacked == true)
        {
            timeSinceDmgTaken += Time.deltaTime;

            if (timeSinceDmgTaken > dmgInterval)
            {
                HP -= Random.Range(5, 16);
                HPSlider.value = HP;

                dmgInterval = 1.4f;
                // dmgInterval -= 0.1f;
                timeSinceDmgTaken = 0;

                isBeingAttacked = false;
            }
        }

        if (HP <= 0)
        {
            SceneManager.LoadScene("GameOver");
            Cursor.lockState = CursorLockMode.None;
        }
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

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            isBeingAttacked = true;
        }
        else
        {
            isBeingAttacked = false;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            isBeingAttacked = false;

            dmgInterval = 0.6f;
            timeSinceDmgTaken = 0;
        }
    }

    void OnInteract()
    {
        RaycastHit hit;

        if (Physics.Raycast(head.transform.position, head.transform.forward, out hit, 5))
        {
            hit.transform.SendMessage("Press", SendMessageOptions.DontRequireReceiver);
        }
    }
}
