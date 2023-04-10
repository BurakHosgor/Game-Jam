using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ApplePicker2D : MonoBehaviour
{
    public int apples = 0;
    public Slider appleSlider;

    void Start()
    {
        // appleSlider component should be assigned in the Inspector
        // Set the minimum and maximum values of the Slider
        appleSlider.minValue = 0;
        appleSlider.maxValue = 10;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (Input.GetKeyDown(KeyCode.Space))
            {
            {
                // Destroy the apple game object
                Destroy(gameObject);

                // Increase the number of apples
                apples++;

                // Update the Slider value
                appleSlider.value = apples;


            }
        }
    }
}



