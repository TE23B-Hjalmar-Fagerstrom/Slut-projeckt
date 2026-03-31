using UnityEngine;
using UnityEngine.UI;
using UnityEngine.InputSystem;

public class legendController : MonoBehaviour
{
    [SerializeField]
    Image legend;

    bool isClosed;

    void Start()
    {
        isClosed = true;
        legend.enabled = false;
    }

    void OnOpenMenu()
    {
        isClosed = !isClosed;
        legend.enabled = isClosed;
        print(legend.enabled);
    }

    void Update()
    {
        // if (Input.GetKey(KeyCode.Tab) && isClosed == true)
        // {
        //     isClosed = false;
        // }

        // if (Input.GetKey(KeyCode.Tab) && isClosed == false)
        // {
        //     isClosed = true;
        // }


        if (isClosed == false)
        {
            legend.enabled = true;
        }

        if (isClosed == true)
        {
            legend.enabled = false;
        }
    }
}
