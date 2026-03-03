using UnityEngine;

public class bulletController : MonoBehaviour
{
    
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * 2000);
    }

    

}
