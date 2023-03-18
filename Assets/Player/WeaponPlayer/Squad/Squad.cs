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
        Debug.Log("Squad");
        int randomPoint = (int)UnityEngine.Random.Range(0f, _spawnersSoldiers.Length);
        _spawnersSoldiers[randomPoint].SetReady(true);
        _spawnersSoldiers[randomPoint].StartSpawn();
    }
}
