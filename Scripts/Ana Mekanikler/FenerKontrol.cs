using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenerKontrol : MonoBehaviour
{
    public GameObject fener;

    public bool ýsOnLight;
    // Start is called before the first frame update
    void Start()
    {
        if (fener != null)
        {
            fener.SetActive(false);
            ýsOnLight = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            ýsOnLight = !ýsOnLight; // Deðiþkene tersini atayarak ýþýðýn açýk/kapalý durumunu deðiþtiriyoruz.

            if (ýsOnLight)
            {
                fener.SetActive(true); // Iþýk açýk deðilse açýyoruz.
            }
            else
            {
                fener.SetActive(false); // Iþýk açýksa kapatýyoruz.
            }
        }
    }
}
