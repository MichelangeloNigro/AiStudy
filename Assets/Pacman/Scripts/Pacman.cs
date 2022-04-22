using System;
using System.Collections;
using System.Collections.Generic;
using BehaviorDesigner.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Pacman : MonoBehaviour
{
    public bool isEmpowered;
    public int pillsEaten;
    public BehaviorTree tree;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy")&&!isEmpowered)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        if (collision.gameObject.CompareTag("Enemy")&&isEmpowered)
        {
            Manager.Instance.ghosts.Remove(collision.gameObject.GetComponent<Ghost>());
            if (Manager.Instance.ghosts.Count==0) {
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }
            collision.gameObject.SetActive(false);
        }
    }
}
