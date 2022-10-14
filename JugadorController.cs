using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
// Agregamos
using UnityEngine.UI;
public class JugadorController : MonoBehaviour {
//Declarlo la variable de tipo RigidBody que luego asociaremos a nuestro

private Rigidbody rb;
public float tiempo_start; //Los segundos por los quales comienza i la variable que utilizaremos para que vaya contando segundos.
public float tiempo_end; 
//Inicializo el contador de coleccionables recogidos
private int contador;
//Inicializo variables para los textos
public TextMeshProUGUI TextoContador, TextoGanar;
//Declaro la variable pública velocidad para poder modificarla desde la

public float velocidad;
// Use this for initialization
void Start () {
//Capturo esa variable al iniciar el juego
rb = GetComponent<Rigidbody>();
//Inicio el contador a 0
contador = 0;
//Actualizo el texto del contador por pimera vez
setTextoContador();
//Inicio el texto de ganar a vacío
TextoGanar.text = "";
}
// Para que se sincronice con los frames de física del motor
void FixedUpdate () {
//Estas variables nos capturan el movimiento en horizontal y

float movimientoH = Input.GetAxis("Horizontal");
float movimientoV = Input.GetAxis("Vertical");
//Un vector 3 es un trío de posiciones en el espacio XYZ, en este

Vector3 movimiento = new Vector3(movimientoH, 0.0f,
movimientoV);
//Asigno ese movimiento o desplazamiento a mi RigidBody,

rb.AddForce(movimiento * velocidad);
}
//Se ejecuta al entrar a un objeto con la opción isTrigger seleccionada
void OnTriggerEnter(Collider other)
{
 if (other.gameObject.CompareTag ("Coleccionable"))
 {
//Desactivo el objeto
 other.gameObject.SetActive (false);
//Incremento el contador en uno (también se peude hacer

contador = contador + 1;
//Actualizo elt exto del contador
setTextoContador();
 }
 }

 
//Actualizo el texto del contador (O muestro el de ganar si las ha cogido
 public IEnumerator EscenaVolverMenu(){
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("Menu");
    }

void setTextoContador(){
TextoContador.text = "Objetivos alcanzados: " + contador.ToString() + "/12";

    if (contador >= 12){
    TextoGanar.text = "Ganaste!";

    tiempo_start += Time.deltaTime;//Función para que la variable tiempo_start vaya contando segundos.
        if (tiempo_start >= tiempo_end) //Si pasan los segundos que hemos puesto antes...
        {
            StartCoroutine(EscenaVolverMenu());
        }
   
    }
   
    }
}


