using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class camera : MonoBehaviour
{
    public WebCamTexture cam;
    public RawImage image;
    private bool camAvaliable;
    private Texture defaultBackground;
    public RawImage background;
    public AspectRatioFitter fit;
    // Start is called before the first frame update
    void TakePhoto() {
      Texture2D photo = new Texture2D(cam.width, cam.height);
      photo.SetPixels(cam.GetPixels());
      photo.Apply();
      image.texture = photo;
    }
    void Start()
    {
       controladorjuego.photo += TakePhoto;
       controladorjuego.pause += Manage;
        defaultBackground = background.texture;
        WebCamDevice[] devices = WebCamTexture.devices;
        if (devices.Length == 0) {
          Debug.Log("No device avaliable");
          camAvaliable = false;
          return;
        }
        cam = new WebCamTexture (devices[0].name, Screen.width, Screen.height);
        cam.Play();
        background.texture = cam;
        camAvaliable = true;
    }

    // Update is called once per frame
    void Update()
    {
        if (!camAvaliable) 
          return;
        float ratio = (float)cam.width / cam.height;
        fit.aspectRatio = ratio;
        float scaleY = cam.videoVerticallyMirrored ? -1f: 1f;
        background.rectTransform.localScale = new Vector3(1f,scaleY, 1f);
        int orient = -cam.videoRotationAngle;
        background.rectTransform.localEulerAngles = new Vector3(0, 0, orient);
    }
    void Manage() {
      if (cam.isPlaying) {
        cam.Pause();
      } else {
        cam.Play();
      }
    }
}
