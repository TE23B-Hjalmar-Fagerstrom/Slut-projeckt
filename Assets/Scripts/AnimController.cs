using UnityEngine;

public class AnimController : MonoBehaviour
{
    Animator anim;
    [SerializeField]
    CameraControler player;
    [SerializeField]
    shotgunController wepon;

    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        anim.SetInteger("SlugAmount", wepon.curentAmmo);

        if (player.isMoving == true)
        {
            anim.SetBool("Walking", true);
        }
        else
        {
            anim.SetBool("Walking", false);
        }

        if (wepon.isReloading == true)
        {
            anim.SetBool("Reloading", true);
            print("is reloading");
        }
        else
        {
            anim.SetBool("Reloading", false);
        }

        if (wepon.fireGun == true)
        {
            anim.SetBool("Fire", true);
            print("is fireing");
        }
        else
        {
            anim.SetBool("Fire", false);
        }

        if (wepon.hasFired == true)
        {
            anim.SetBool("HasFired", true);
            print("has fired");
        }
        else
        {
            anim.SetBool("HasFired", false);
        }
    }
}