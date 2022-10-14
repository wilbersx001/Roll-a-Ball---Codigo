using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class CamaraController : MonoBehaviour {
//Referencia a nuestro jugador
public GameObject jugador;
private Vector3 offset;
// Use this for initialization
void Start () {
//diferencia entre la posición de la cámara y la del jugador
offset = transform.position - jugador.transform.position;
}
// Se ejecuta cada frame, pero después de haber procesado todo. Es más

void LateUpdate () {
//Actualizo la posición de la cámara
transform.position = jugador.transform.position + offset;
}
}
