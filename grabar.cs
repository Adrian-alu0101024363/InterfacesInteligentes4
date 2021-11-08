using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class grabar : MonoBehaviour
{
    AudioClip recording;
    public AudioSource audioSource;
    public Button button;
    public string device;
    public Text text;
    static bool press;
    // Start is called before the first frame update
    void Start()
    {
      GetComponentInChildren<Text>().text = "Record/Play";
      audioSource = GetComponent<AudioSource>();
      button.onClick.AddListener(graba);
      for (int i = 0; i < Microphone.devices.Length; i++) {
        Debug.Log(Microphone.devices.GetValue(0));
      }
      press = false;
    }
    void graba() {
      if (!press) {
        Debug.Log("graba");
        recording = Microphone.Start(Microphone.devices[0], false, 10, 44100);
        press = true;
      } else {
        audioSource.clip = recording;
        Microphone.End(Microphone.devices[0]);
        audioSource.Play();
        Debug.Log("play");
        press = false;
      }
      //controladorjuego.audio();
    }
    // Update is called once per frame
    void Update()
    {
        
    }

}
