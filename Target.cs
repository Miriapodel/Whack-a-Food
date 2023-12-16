using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{

    private Rigidbody rb;

    private GameManager gameManager;

    public ParticleSystem explosionParticle;

    public float upwardForce = 30;
    public float torqueSpeed = 10;
    public float torqueRange = 10;
    public float xRange = 4;
    public int  pointValue=10;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
       
        MovePlayerUp();
        RotatePlayer();
    }

    // Update is called once per frame
    void Update()
    {
       
    }

    void MovePlayerUp()
    {
        rb.AddForce(Vector3.up * upwardForce, ForceMode.Impulse);
        transform.position = new Vector3(Random.Range(-xRange, xRange), 0, 0);
    }

    void RotatePlayer()
    {

        rb.AddTorque(GenerateRandomPosition(torqueRange) * torqueSpeed);
    }

    Vector3 GenerateRandomPosition(float range )
    {
        Vector3 position = new Vector3(Random.Range(-range, range), Random.Range(-range, range), Random.Range(-range, range));

        return position;
    }

    private void OnMouseDown()
    {
        if(gameManager.isGameActive==true)
        {
            Destroy(gameObject);
            gameManager.UpdateScore(pointValue);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
        }
        
    }

    private void OnTriggerEnter(Collider collider)
    {
        Destroy(gameObject);
        if(!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }


}
