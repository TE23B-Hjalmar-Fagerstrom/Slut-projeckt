using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    int hp;
    float timer;
    Animator anim;

    void Start()
    {
        hp = 50;
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (hp < 1)
        {
            Destroy(this.gameObject);
        }

        timer += Time.deltaTime;

        int lookInterverl = 12;

        anim.SetFloat("IdelTime", timer);

        if (timer > lookInterverl)
        {
            timer = 0;
            lookInterverl = 64;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Bullet")
        {
            hp -= 5;
        }

        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("Attacking", true);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("Attacking", false);
        }
    }
}
