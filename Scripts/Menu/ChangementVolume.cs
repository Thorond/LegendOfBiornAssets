using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChangementVolume : MonoBehaviour {

    [SerializeField] Slider sliderVolume;
    [SerializeField] AudioSource maMusic;

	void Update () {
        maMusic.volume = sliderVolume.value;
    }
}
