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
    }

    void Update()
    {
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
