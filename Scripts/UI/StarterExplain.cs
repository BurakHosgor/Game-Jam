using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class StarterExplain: MonoBehaviour
{
    // Metin ��esi referans�
    public Text textObject;

    // Aktif kalacak s�re
    public float activeTime = 5f;

    // Start() fonksiyonu
    void Start()
    {
        // Invoke() fonksiyonu ile metin ��esinin kald�r�lma s�resi ayarlan�r
        Invoke("DisableText", activeTime);
    }

    // Metin ��esini kald�ran fonksiyon
    void DisableText()
    {
        textObject.enabled = false;
    }
}

