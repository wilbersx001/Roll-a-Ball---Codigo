using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sonido : MonoBehaviour
{
    public  AudioSource quienEmite;
    public AudioClip elSonido;
    public float volumen = 1f;

    private void OnTriggerEnter(Collider other){
        AudioSource.PlayClipAtPoint(elSonido,gameObject.transform.position);
        Destroy(gameObject);
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
