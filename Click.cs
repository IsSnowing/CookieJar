using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Click : MonoBehaviour {
    public static bool sound = true;
    public Sprite mute;
    public Sprite unmute;
    public Button SoundButton;

    private void Awake()
    {
        SoundButton.GetComponent<Image>().sprite = unmute;

    }

    public void muteOrUnmute()
    {
        if(sound == true)
        {
            sound = false;
            SoundButton.GetComponent<Image>().sprite = mute;

        }
        else
        {
            sound = true;
            SoundButton.GetComponent<Image>().sprite = unmute;
        }
        Debug.Log("this is sound: " + sound);
    }
}
