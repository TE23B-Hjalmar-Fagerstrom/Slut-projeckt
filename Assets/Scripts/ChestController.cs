using UnityEngine;
using TMPro;

public class ChestController : MonoBehaviour
{
    Canvas UI;
    Animator Anim;
    private bool inArea;
    bool shestOpen;
    public float moneyMult = 1;
    public int addMaxHP;
    public int addScrap;

    [SerializeField]
    TMP_Text chestText;

    void Start()
    {
        UI = GetComponentInChildren<Canvas>();
        Anim = GetComponentInChildren<Animator>();

        UI.enabled = false;
        inArea = false;
        shestOpen = false;
        chestText.text = "Press E to open chest";
    }

    void OnTriggerEnter(Collider other)
    {
        if (shestOpen == false && other.gameObject.tag == "Player")
        {
            UI.enabled = true;
            inArea = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (shestOpen == false && other.gameObject.tag == "Player")
        {
            UI.enabled = false;
            inArea = false;
        }
    }

    public void Press()
    {
        if (inArea == true && shestOpen == false)
        {
            shestOpen = true;
            UI.enabled = false;
            Anim.SetBool("IsOpende", true);

            GameObject player = GameObject.FindGameObjectWithTag("Player");

            player.GetComponent<CameraControler>().Money += Random.Range(5 * moneyMult, 31 * moneyMult);
            moneyMult = 1;

            if (addMaxHP > 0)
            {
                player.GetComponent<CameraControler>().maxHP += addMaxHP;
                addMaxHP = 0;
                print("HP added");
            }

            if (addScrap > 0)
            {
                player.GetComponent<CameraControler>().Scrap += addScrap;
                addScrap = 0;
                print("Scrap added");
            }
        }
    }
}
