using UnityEngine;

public class ChestController : MonoBehaviour
{
    Canvas UI;
    Animator Anim;
    bool inArea;

    void Start()
    {
        UI = GetComponentInChildren<Canvas>();
        Anim = GetComponentInChildren<Animator>();

        UI.enabled = false;
        inArea = false;
    }

    void Update()
    {
        if (inArea == true)
        {

        }
    }

    void OnTriggerEnter(Collider other)
    {
        UI.enabled = true;
        inArea = true;
    }

    void OnTriggerExit(Collider other)
    {
        UI.enabled = false;
        inArea = false;
    }

    void OnInteract()
    {
        
    }
    
}
