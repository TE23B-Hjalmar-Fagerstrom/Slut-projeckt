using UnityEngine;
using TMPro;
using Unity.Mathematics;

public class ChestController : MonoBehaviour
{
    Canvas UI;
    Animator Anim;
    private bool inArea;
    bool shestOpen;
    public float moneyMult = 1;
    public float moneyAddition = 1;
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

            float num = UnityEngine.Random.Range((5 + moneyAddition) * moneyMult, (31 + moneyAddition) * moneyMult);
            player.GetComponent<CameraControler>().Money += math.round(num);
            moneyMult = 1;
            moneyAddition = 1;

            // här låg den hemsökta printen
            if (addMaxHP > 0)
            {
                player.GetComponent<CameraControler>().maxHP += addMaxHP;
                print($"HP added ({addMaxHP})");
                addMaxHP = 0;
            }

            if (addScrap > 0)
            {
                player.GetComponent<CameraControler>().Scrap += addScrap;
                print($"Scrap added ({addScrap})");
                addScrap = 0;
            }
        }
    }
}
