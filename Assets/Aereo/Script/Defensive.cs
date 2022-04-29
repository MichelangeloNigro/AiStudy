using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Random = UnityEngine.Random;

public class Defensive : aereo
{
    private Collider[] hits;
    public bool hasSomeoneBehind;
    public float boxMultiplier;
    public Transform back;
    public Transform avanti;

    public Collider coll;

    // Start is called before the first frame update
    void Start()
    {
        base.Start();
        coll = GetComponent<Collider>();
        back.transform.position=new Vector3(back.transform.position.x,back.transform.position.y,back.transform.position.z-(7*boxMultiplier));
    }

    // Update is called once per frame
    void Update()
    {
        hits = null;
        hasSomeoneBehind = false;
        hits = Physics.OverlapBox(
            new Vector3(back.position.x, back.position.y,
                back.position.z ), new Vector3(3f, 4f, 7f) * boxMultiplier,
            transform.rotation, LayerMask.GetMask("Player"));
        foreach (var VARIABLE in hits)
        {
            if (VARIABLE.gameObject != gameObject)
            {
                Debug.Log(VARIABLE.name);
                hasSomeoneBehind = true;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawCube(
            new Vector3(back.position.x, back.position.y,
                back.position.z), (new Vector3(3f, 4f, 7f) * boxMultiplier*2) );
    }
}