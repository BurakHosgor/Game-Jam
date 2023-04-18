using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MuteButton : MonoBehaviour
{
   private bool muted = false;
   public Image muteButton;
   public Sprite unmutedImage;
   public Sprite mutedImage;

   public void Mute(){

    if(muted){

        muteButton.sprite = unmutedImage;
        AudioListener.volume = 1;
        muted=false;

    }
    else{

        muteButton.sprite = mutedImage;
        AudioListener.volume = 0;
        muted = true;
    }
   }
}
