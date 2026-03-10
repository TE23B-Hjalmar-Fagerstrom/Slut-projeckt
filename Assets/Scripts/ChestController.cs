using UnityEngine;
using TMPro;

public class ChestController : MonoBehaviour
{
    Canvas UI;
    Animator Anim;
    private bool inArea;
    bool shestOpen;

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

            player.GetComponent<CameraControler>().Money += Random.Range(5, 31);
        }
    }
}
