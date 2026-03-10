using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;

public class bulletController : MonoBehaviour
{
    
    void Start()
    {
        GetComponent<Rigidbody>().AddForce(transform.forward * 3000);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Enemy")
        {
            Destroy(this.gameObject);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag != "Bullet")
        {
            Destroy(this.gameObject); 
            print("HIT");
        }
    }
}
