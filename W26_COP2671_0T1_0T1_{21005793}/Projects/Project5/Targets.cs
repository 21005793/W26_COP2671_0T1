using UnityEngine;

public class Targets : MonoBehaviour
{
    private Rigidbody targetRb;
    private GameManager gameManager;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -2;

    public ParticleSystem explosionParticle;
    public int pointValue;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        targetRb = GetComponent<Rigidbody>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();


        //applies a force to move objects on screen - Up in this case
        targetRb.AddForce(RandomForce(), ForceMode.Impulse);
        targetRb.AddTorque(RandomTorque(), RandomTorque(), RandomTorque(), ForceMode.Impulse);

        //determines where an object will spawn
        transform.position = RandomSpawnPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    //destroys a game object when clicked -- is not working
    //tracks score of objects clicked
    private void OnMouseDown()
    {
        if(gameManager.isGameActive)
        {
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            gameManager.UpdateScore(pointValue);
        }
        
    }
    //destroys a game object when it passes the trigger line -- is not working
    private void OnTriggerEnter(Collider other)
    {
        Destroy(gameObject);
        if (!gameObject.CompareTag("Bad"))
        {
            gameManager.GameOver();
        }
    }
    //creates the upward motion for the objects
    Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }
    //determines the speed of the upward moving objects
    float RandomTorque()
    {
        return Random.Range(-maxTorque, maxTorque);
    }
    //determines the spawning position of the objects
    Vector3 RandomSpawnPos()
    {
        return new Vector3(Random.Range(-xRange, xRange), ySpawnPos);
    }
}
