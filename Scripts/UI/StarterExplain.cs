using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StarterExplain: MonoBehaviour
{
    // Metin öðesi referansý
    public Text textObject;

    // Aktif kalacak süre
    public float activeTime = 5f;

    // Start() fonksiyonu
    void Start()
    {
        // Invoke() fonksiyonu ile metin öðesinin kaldýrýlma süresi ayarlanýr
        Invoke("DisableText", activeTime);
    }

    // Metin öðesini kaldýran fonksiyon
    void DisableText()
    {
        textObject.enabled = false;
    }
}

