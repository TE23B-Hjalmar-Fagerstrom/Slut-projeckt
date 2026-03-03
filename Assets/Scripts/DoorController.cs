using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class DoorController : MonoBehaviour
{
    Canvas UI;
    Animator anim;
    private bool inArea;
    bool doorOpen;
    bool bossDoor;
    bool HPDoor;
    bool moneyDoor;
    bool scrapDoor;
    bool shopDoor;
    bool uppgradeDoor;

    [SerializeField]
    TMP_Text doorText;

    void Start()
    {
        UI = GetComponentInChildren<Canvas>();
        anim = GetComponentInChildren<Animator>();

        UI.enabled = false;
        inArea = false;
        doorOpen = false;
        doorText.text = "Press E to open door";
    }

    void OnTriggerEnter(Collider other)
    {
        if (doorOpen == false)
        {
            UI.enabled = true;
            inArea = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (doorOpen == false)
        {
            UI.enabled = false;
            inArea = false;
        }

        anim.SetBool("interactWithDoor?", false);
        GetComponentInChildren<Collider>().enabled = true;
        doorOpen = false;
    }

    public void Press()
    {
        if (inArea == true && doorOpen == false)
        {
            doorOpen = true;
            UI.enabled = false;
            anim.SetBool("interactWithDoor?", true);
            GetComponentInChildren<Collider>().enabled = false;
        }
    }
}
