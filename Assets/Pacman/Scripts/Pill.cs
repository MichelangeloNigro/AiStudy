using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pill : MonoBehaviour
{
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
