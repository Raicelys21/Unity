using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroybyContact : MonoBehaviour
{
    public GameObject explosion;
    public GameObject spacecraftexplo;

    private GameControl gameControl;
    public int scoreValue;

    void Start()
    {
        GameObject gameControlObject = GameObject.FindWithTag("GameControl");
        gameControl = gameControlObject.GetComponent<GameControl>();

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Limit")) return; // Que no se rompa con collider
        Instantiate(explosion, transform.position, transform.rotation); // Explosion de asteroide
        if (other.CompareTag("Spacecraft"))
        {
            Instantiate(spacecraftexplo, other.transform.position, other.transform.rotation); // Explosion de nave
        }
        gameControl.AddScore(scoreValue);
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
