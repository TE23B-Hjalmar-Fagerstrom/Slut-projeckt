using UnityEngine;

public class WeaponScript : MonoBehaviour
{
    void OnAttack()
    {
        shotgunController shotgun = GetComponentInChildren<shotgunController>();
        shotgun.Fire();
    }

    void OnReload()
    {
        shotgunController shotgun = GetComponentInChildren<shotgunController>();
        shotgun.Reload();
    }
}
