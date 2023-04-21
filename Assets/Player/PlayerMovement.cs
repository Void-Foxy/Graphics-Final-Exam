using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  Rigidbody rb;
  public float speed;
  private void Start() {
    rb = GetComponent<Rigidbody>();
  }
  private void Update() {
    Vector2 dir = new Vector2();
    if (Input.GetKey(KeyCode.W)) {
      dir.x += 1;
    }
    if (Input.GetKey(KeyCode.A)) {
      dir.y -= 1;
    }
    if (Input.GetKey(KeyCode.S)) {
      dir.x -= 1;
    }
    if (Input.GetKey(KeyCode.D)) {
      dir.y += 1;
    }
    rb.velocity = new Vector3(dir.y,0,dir.x) * Time.deltaTime * speed;
  }
}
