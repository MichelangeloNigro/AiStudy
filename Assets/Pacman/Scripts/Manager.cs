using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Riutilizzabile;
using UnityEngine;

public class Manager : Singleton<Manager>
{
    public List<Pill> pills=new List<Pill>();
    public List<AntiGhost> antiGhosts=new List<AntiGhost>();
    public List<Ghost> ghosts=new List<Ghost>();
    public List<Pacman> pacmans=new List<Pacman>();

    protected void Awake()
    {
        base.Awake();
        pills = FindObjectsOfType<Pill>().ToList();
        antiGhosts = FindObjectsOfType<AntiGhost>().ToList();
        ghosts = FindObjectsOfType<Ghost>().ToList();
        pacmans = FindObjectsOfType<Pacman>().ToList();
        pacmans[0].tree.SetVariableValue("RemaningDot",pills.Count);
        pacmans[0].tree.SetVariableValue("RemaningEmpower",antiGhosts.Count);
    }


    public Tuple<Transform,float> GetClosestGhostToPacman()
    {
        List<GameObject> temp = new List<GameObject>();
        foreach (var VARIABLE in ghosts)
        {
            temp.Add(VARIABLE.gameObject);
        }

        return GetClosestToPacman(pacmans[0].gameObject.transform.position, temp);
    }

    public Tuple<Transform,float> GetClosestEmpowerToPacman()
    {
        List<GameObject> temp = new List<GameObject>();
        foreach (var VARIABLE in antiGhosts)
        {
            temp.Add(VARIABLE.gameObject);
        }

        return GetClosestToPacman(pacmans[0].gameObject.transform.position, temp);
    }
    public Tuple<Transform,float> GetClosestPacman(Vector3 position)
    {
        List<GameObject> temp = new List<GameObject>();
        foreach (var VARIABLE in pacmans)
        {
            temp.Add(VARIABLE.gameObject);
        }

        return GetClosestToPacman(position, temp);
    }


    public Tuple<Transform,float> GetClosestDotToPacman()
    {
        List<GameObject> temp = new List<GameObject>();
        foreach (var VARIABLE in pills)
        {
            temp.Add(VARIABLE.gameObject);
        }

        return GetClosestToPacman(pacmans[0].gameObject.transform.position, temp);
    }

    public Tuple<Transform,float> GetClosestToPacman(Vector3 center, List<GameObject> objects)
    {
        if (objects.Count > 0)
        {
            Transform target = objects[0].gameObject.transform;
            float minDistance = Vector3.Distance(center, objects[0].gameObject.transform.position);
            foreach (var obj in objects)
            {
                if (minDistance > Vector3.Distance(center, obj.transform.position))
                {
                    minDistance = Vector3.Distance(center, obj.transform.position);
                    target = obj.transform;
                }
            }

            return new Tuple<Transform, float>(target,minDistance);
        }
        else
        {
            return null;
        }
    }
}