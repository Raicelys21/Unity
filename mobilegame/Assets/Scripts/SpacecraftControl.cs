using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityStandardAssets.CrossPlatformInput;
using UnityEngine.UI;

[System.Serializable]
public class Limit
{
    public float zMin;
    public float zMax;
}
public class SpacecraftControl : MonoBehaviour
{
    [Header("Movement")]
    private Rigidbody rig;
    public float speed; // Velocidad de movimiento
    public Limit limit; //Limites
    private float mov;

    [Header ("Bolt")]
    public GameObject shoot;
    public Transform showSpawn;
    private AudioSource audioSource;

    [Header("GameOver")]
    public GameObject gameovertext;
    private bool gameoverbool;

    [Header("Playerexplo")]
    public GameObject spacecraftexplo;

    void Awake()
    {
        rig = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        gameovertext.SetActive(false);
        gameoverbool = false;
    }

    void Update()
    {
        if (gameoverbool)
        {
            Time.timeScale = 0; 
        }
    }

    public void BulletStart()
    {
        Instantiate(shoot, showSpawn.position, Quaternion.identity);
        audioSource.Play();
    }

    public void MoveU()
    {
        mov = -speed;
    }
    public void MoveD()
    {
        mov = speed;
    }

    // Movimiento de la nave
    void FixedUpdate()
    {
        float movevertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(movevertical, -0.001f, -0.44f);
        rig.velocity = movement * mov;
        rig.position = new Vector3(7.51f, -0.001f, Mathf.Clamp(rig.position.z, limit.zMin, limit.zMax));

        if (rig.position.z == -5.22f || rig.position.z == 3.65f)
        {
            gameovertext.SetActive(true);
            gameoverbool = true;
            Time.timeScale = 0;
            Instantiate(spacecraftexplo, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
