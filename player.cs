using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player: MonoBehaviour
{
    public int Speed;
    private float random1, random2, random3;
    private Renderer playerRenderer;
    private Color color;
    void MoveLeft() {
      transform.position = new Vector3(transform.position.x - Speed, transform.position.y, transform.position.z);
    }
    void MoveRigth() {
      transform.position = new Vector3(transform.position.x + Speed, transform.position.y, transform.position.z);
    }
    void MoveUp() {
      transform.position = new Vector3(transform.position.x, transform.position.y + Speed, transform.position.z);
    }
    void MoveDown() {
      transform.position = new Vector3(transform.position.x, transform.position.y - Speed, transform.position.z);
    }
    void MoveAway() {
      transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Speed);
    }
    void MoveClose() {
      transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Speed);
    }
    void ChangeColor() {
      random1 = UnityEngine.Random.Range(0f, 1f);
      random2 = UnityEngine.Random.Range(0f, 1f);
      random3 = UnityEngine.Random.Range(0f, 1f);
      color = new Color(random1, random2, random3);
      playerRenderer.material.SetColor("_Color", color);
    }
    // Start is called before the first frame update
    void Start()
    {
        playerRenderer = GetComponent<Renderer>();
        controladorjuego.left += MoveLeft;
        controladorjuego.right += MoveRigth;
        controladorjuego.away += MoveAway;
        controladorjuego.close += MoveClose;
        controladorjuego.down += MoveDown;
        controladorjuego.up += MoveUp;
        controladorjuego.change += ChangeColor;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
