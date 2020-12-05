using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[DisallowMultipleComponent]
public class Oscillator : MonoBehaviour
{
    [SerializeField] Vector3 movementVector = new Vector3(0f, 3.2f, 0f);

    [SerializeField] float period = 2f;

    [Range(0, 1)] [SerializeField] float movementFactor; //o for no movement and 1 for full movement
    Vector3 startingPos;
    void Start()
    {
        startingPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon) { return; }
        float cycles = Time.time / period;
        const float Tau = Mathf.PI * 2;          //6.28
        float rawSineWave = Mathf.Sin(cycles * Tau);
        movementFactor = rawSineWave / 2f + 0.5f;
        Vector3 offset = movementFactor * movementVector;
        transform.position = startingPos + offset;
        
    }
}
