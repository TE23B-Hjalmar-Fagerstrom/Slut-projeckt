using UnityEngine;
using TMPro;
using UnityEngine.UIElements;

public class DoorController : MonoBehaviour
{
    Canvas UI;
    Animator anim;
    GameObject door;
    ChestController chest;
    private bool inArea;
    public bool doorOpen = false;
    public bool bossDoor = false;
    public bool HPDoor = false;
    public bool moneyDoor = false;
    public bool scrapDoor = false;
    public bool shopDoor = false;
    public bool uppgradeDoor = false;

    [SerializeField]
    TMP_Text doorText;

    void Start()
    {
        UI = GetComponentInChildren<Canvas>();
        anim = GetComponentInChildren<Animator>();
        door = this.gameObject;
        chest = gameObject.GetComponent<ChestController>();

        UI.enabled = false;
        inArea = false;
        doorOpen = false;
        doorText.text = "Press E to open door";

        if (door.name == "BossDoor")
        {
            bossDoor = true;
        }
        else if (door.name == "MoneyDoor")
        {
            moneyDoor = true;
        }
        else if (door.name == "HPDoor")
        {
            HPDoor = true;
        }
        else if (door.name == "ShopDoor")
        {
            shopDoor = true;
        }
        else if (door.name == "ScrapDoor")
        {
            scrapDoor = true;
        }
        else if (door.name == "UppgradeDoor")
        {
            uppgradeDoor = true;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if (doorOpen == false && other.gameObject.tag == "Player")
        {
            UI.enabled = true;
            inArea = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (doorOpen == false && other.gameObject.tag == "Player")
        {
            UI.enabled = false;
            inArea = false;
        }
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("interactWithDoor?", false);
            GetComponentInChildren<Collider>().enabled = true;
            doorOpen = false;
        }

    }

    public void Press()
    {
        if (inArea == true && doorOpen == false)
        {
            doorOpen = true;
            UI.enabled = false;
            anim.SetBool("interactWithDoor?", true);
            GetComponentInChildren<Collider>().enabled = false;

            if (bossDoor == true)
            {
                chest.moneyMult = 2.5f;
                chest.addScrap = Random.Range(10, 36);
                print(chest.moneyMult);
            }
            else if (moneyDoor == true)
            {
                chest.moneyMult = 1.75f;
            }
            else if (HPDoor == true)
            {
                chest.addMaxHP = Random.Range(5, 16);
            }
            else if (shopDoor == true)
            {
                ;
            }
            else if (scrapDoor == true)
            {
                chest.addScrap = Random.Range(5, 21);;
            }
            else if (uppgradeDoor == true)
            {
                ;
            }
        }
    }
}
