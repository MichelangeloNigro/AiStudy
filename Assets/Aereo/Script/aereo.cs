using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class aereo : MonoBehaviour
{
    public aereo target;
    public aereo[] otherPlayers;
    // Start is called before the first frame update
  protected  void Start()
    {
        otherPlayers = FindObjectsOfType<aereo>();
        var tempList = otherPlayers.ToList();
        tempList.Remove(this);
        otherPlayers = tempList.ToArray();
        var temp=Random.Range(0,otherPlayers.Length);
        target = otherPlayers[temp];

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
