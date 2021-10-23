using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Tracker : MonoBehaviour
{
    [SerializeField] Slider slider;
    [SerializeField] Transform LevelStart, LevelEnd, Player;

    private float StartZ, EndZ, progress;

    void Start()
    {
        StartZ = LevelStart.position.z;
        EndZ = LevelEnd.position.z;

    }

    void Update()
    {
        progress = (Player.position.z - StartZ) / (EndZ - StartZ);
        //Debug.Log(progress);
        slider.value = progress * 100;
    }
}