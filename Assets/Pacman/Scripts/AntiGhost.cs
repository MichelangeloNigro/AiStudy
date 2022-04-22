using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntiGhost : MonoBehaviour
{
    public float timeEmpowered;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StopAllCoroutines();
            Manager.Instance.StartCoroutine(Empower(other.gameObject.GetComponent<Pacman>()));
            Manager.Instance.antiGhosts.Remove(this);
            other.gameObject.GetComponent<Pacman>().tree.SetVariableValue("RemaningEmpower",Manager.Instance.antiGhosts.Count);
            Destroy(this.gameObject);
        }
    }

    private IEnumerator Empower(Pacman pac)
    {
        pac.isEmpowered = true;
        yield return new WaitForSeconds(timeEmpowered);
        pac.isEmpowered = false;
    }
}
