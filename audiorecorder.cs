using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class audiorecorder : MonoBehaviour {
    public AudioClip recording;
    public AudioSource audioSource;
    private float startRecordingTime;


    private void Start()
    {
        controladorjuego.audio += Record;
        controladorjuego.audioplay += Play;
        audioSource = GetComponent<AudioSource>();
    }
    void Record() {
      audioSource = GetComponent<AudioSource>();
      Debug.Log("grabo");
      recording = Microphone.Start("", false, 300, 44100);
      audioSource.clip = recording;
      audioSource.Play();
    }
    void Play() {
      Microphone.End("");
      Debug.Log("play");
      audioSource.clip = recording;
      audioSource.Play();
    }

}
