using System;
using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using BehaviorDesigner.Runtime.Tasks;
using UnityEngine;

public class MacchinaController : MonoBehaviour {
    public BehaviorTree tree;
    // Start is called before the first frame update
    void Start() {
        tree = GetComponent<BehaviorTree>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Muri")) {
            Debug.Log("bonk");
            tree.SetVariableValue("CurrentSpeed",0);
        }
    }
}
