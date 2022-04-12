using System;
using System.Collections;
using System.Collections.Generic;
using Rewired;
using UnityEngine;

public class MacchininaPlayer : MonoBehaviour {
    private Player Player;
    public float currentSpeed;
    public float maxSpeed;
    public float minSpeed;
    public float accelerationDelta;
    // Start is called before the first frame update
    void Start() {
        Player = ReInput.players.GetPlayer(0);
        Player.AddInputEventDelegate(Accelerate, UpdateLoopType.Update, InputActionEventType.ButtonPressed,
            RewiredConsts.Action.Accelerate);
        Player.AddInputEventDelegate(Break, UpdateLoopType.Update, InputActionEventType.ButtonPressed,
            RewiredConsts.Action.Break); 
        Player.AddInputEventDelegate(Decelerate, UpdateLoopType.Update, InputActionEventType.ButtonUnpressed,
            RewiredConsts.Action.Accelerate); 
        Player.AddInputEventDelegate(SetAim, UpdateLoopType.Update, InputActionEventType.AxisActive,
            RewiredConsts.Action.Steer);
    }

    void Accelerate(InputActionEventData data) {
        currentSpeed += accelerationDelta;
        currentSpeed=Mathf.Clamp(currentSpeed, minSpeed, maxSpeed);
    }

    void Break(InputActionEventData data) {
        currentSpeed=Mathf.Lerp(currentSpeed, 0, 0.02f);
        currentSpeed=Mathf.Clamp(currentSpeed, minSpeed, maxSpeed);
    }

    void Decelerate(InputActionEventData data) {
        currentSpeed -= accelerationDelta;
        currentSpeed=Mathf.Clamp(currentSpeed, minSpeed, maxSpeed);
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Muri")) {
            Debug.Log("bonk");
            currentSpeed = 0;
        }    
    }

    private void Update() {
        transform.position += transform.forward * currentSpeed;
        
    }
    
    void SetAim(InputActionEventData data) {
         var angolo = Mathf.Asin(Player.GetAxis(RewiredConsts.Action.Steer));
         angolo = Mathf.Rad2Deg * angolo;
         var raycastDir = Quaternion.Euler(0, angolo, 0) * transform.forward;
         transform.forward =  Vector3.Lerp(transform.forward,raycastDir,0.01f);
    }

}
