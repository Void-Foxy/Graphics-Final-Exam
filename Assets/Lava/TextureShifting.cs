using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextureShifting : MonoBehaviour {

  Material material;
  float timer;
  float subTimer;
  [SerializeField] float cycleTime = 1;
  [SerializeField] float calmCycle = 100;
  [SerializeField] float explosiveCycle = 1;
  [SerializeField] List<string> texName;
  [SerializeField] bool xPositive;
  [SerializeField] bool yPositive;
  void Start() {
    //Fetch the Material from the Renderer of the GameObject
    material = GetComponent<Renderer>().material;
  }
  private void Update() {
    if (Input.GetKeyDown(KeyCode.C)) cycleTime = calmCycle;
    if (Input.GetKeyDown(KeyCode.V)) cycleTime = explosiveCycle;
    timer += Time.deltaTime;
    subTimer += Time.deltaTime/cycleTime;
    if (timer > cycleTime) {
      timer -= cycleTime;
    }
    float x;
    float y;
    if (xPositive) {
      x = timer / cycleTime;
    } else {
      x = -timer / cycleTime;
    }
    if (yPositive) {
      y = timer / cycleTime;
    } else {
      y = -timer / cycleTime;
    }
    for (int i = 0; i < texName.Count; i++) {
      material.SetTextureOffset(texName[i], new Vector2(x, y));
    }
    material.SetFloat("_RotationSpeed", subTimer);
  }
}
