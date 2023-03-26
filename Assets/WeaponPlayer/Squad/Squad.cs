using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Squad : MonoBehaviour
{
    [SerializeField] private Spawner[] _spawnersSoldiers;

    public void OnSquadsButtonClick()
    {
        //int randomPoint = (int)UnityEngine.Random.Range(0f, _spawnersSoldiers.Length);
        //_spawnersSoldiers[randomPoint].SetReady(true);

        foreach (var spawner in _spawnersSoldiers)
        {
            spawner.SetReady(true);
        }
    }
}
