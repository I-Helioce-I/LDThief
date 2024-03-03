using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class Bruit : MonoBehaviour
{
    PlayerController playerController;

    [Header("Noise")]
    [SerializeField] Slider sliderNoise;
    [SerializeField] public string actualFloor;
    [SerializeField] public float gridNoise;
    [SerializeField] public float groundNoise;
    [SerializeField] float crouchNoise = 1;
    [SerializeField] float walkNoise = 2;
    [SerializeField] float sprintNoise = 5;

    [SerializeField] public float actualNoise;
    [SerializeField] public float maxNoise = 10;

    [SerializeField] PlayerState playerState;


    private void Start()
    {
        sliderNoise.maxValue = maxNoise;
    }

    private void Update()
    {
        playerState = GetComponent<FirstPersonController>().playerState;
        UpdateSlider();
        GetTag();
    }

    public void ReceiveNoise(float noiseIn)
    {
        float calculatedNoise = noiseIn;

        if (actualFloor == "Grid")
        {
            calculatedNoise *= gridNoise;
        }
        else if (actualFloor == "Ground")
        {
            calculatedNoise *= groundNoise;
        }

        actualNoise = calculatedNoise;

    }


    public void GetTag()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, Vector3.down * 0.25f, out hit))
        {
            actualFloor = hit.collider.tag;
        }

    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawLine(transform.position, Vector3.down * 0.25f);
    }

    private void UpdateSlider()
    {
        sliderNoise.value = actualNoise;
    }
}
