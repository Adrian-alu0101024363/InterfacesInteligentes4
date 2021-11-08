using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class reproducir : MonoBehaviour
{
    // Start is called before the first frame update
    void reproduce() {
      controladorjuego.audioplay();
    }
    void Start()
    {
        GetComponent<Button>().onClick.AddListener(reproduce);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
