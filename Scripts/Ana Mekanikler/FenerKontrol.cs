using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FenerKontrol : MonoBehaviour
{
    public GameObject fener;

    public bool �sOnLight;
    // Start is called before the first frame update
    void Start()
    {
        if (fener != null)
        {
            fener.SetActive(false);
            �sOnLight = false;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            �sOnLight = !�sOnLight; // De�i�kene tersini atayarak �����n a��k/kapal� durumunu de�i�tiriyoruz.

            if (�sOnLight)
            {
                fener.SetActive(true); // I��k a��k de�ilse a��yoruz.
            }
            else
            {
                fener.SetActive(false); // I��k a��ksa kapat�yoruz.
            }
        }
    }
}
