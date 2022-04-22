using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Pill : MonoBehaviour
{
   private void Start() {
      transform.position += new Vector3(Random.Range(1f,100f),0,Random.Range(1f,100f));
   }

   private void OnTriggerEnter(Collider other)
   {
      if (other.CompareTag("Player"))
      {
         
         other.GetComponent<Pacman>().pillsEaten++;
         other.GetComponent<Pacman>().tree.SetVariableValue("DotEaten", other.GetComponent<Pacman>().pillsEaten);
         Manager.Instance.pills.Remove(this);
         other.gameObject.GetComponent<Pacman>().tree.SetVariableValue("RemaningDot",Manager.Instance.pills.Count);
         Destroy(this.gameObject);
      }
   }
}
