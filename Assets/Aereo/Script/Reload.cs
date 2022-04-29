using UnityEngine;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;

public class Reload : Action
{
    public SharedInt ammo;
    public SharedInt maxAmmo;
    public SharedFloat reloadTime;
    public SharedBool isReloading;
    private float temp;

    public override void OnStart()
    {
    }

    public override TaskStatus OnUpdate()
    {
        if (ammo.Value == 0)
        {
            isReloading.Value = true;
            if (temp>=reloadTime.Value)
            {
                realod();
            }
            temp += Time.deltaTime;
        }
        else
        {
            isReloading.Value = false;
        }
        return TaskStatus.Success;
    }

    public void realod()
    {
        Debug.Log("reload");
        ammo.Value = maxAmmo.Value;
        Debug.Log(ammo.Value);
        isReloading.Value = false;
        temp = 0;

    }
}