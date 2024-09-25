using System.Collections;
using System.Collections.Generic;
using System.IO.Compression;
using Unity.VisualScripting;
using UnityEngine;
public class BallController : MonoBehaviour
{
    public Rigidbody rb;
    public bool inPlay;
    private bool forceApplied = false;
    public float resetTime = 1f;
    public Transform paddle;
    public Transform explosion;
    public GameManager gm;
    public Transform powerup;
    AudioSource audio1;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audio1 = GetComponent<AudioSource>();
        StartCoroutine(ResetForceApplied());
    }

    void Update ()
    {
        if(gm.gameOver){
            return;
        }
        if(!inPlay){
            transform.position = paddle.position;
        }

        if(Input.GetButton ("Jump") && !inPlay){
            inPlay = true;
            rb.AddForce (Vector3.forward * 500);
        }
        transform.Rotate(80f * Time.deltaTime, 40f * Time.deltaTime, 120f * Time.deltaTime, Space.Self);

        if (transform.position.z > 5.6f && !forceApplied)
        {
            // Apply a force in the negative z direction (backward) to move the ball backward
            rb.AddForce(Vector3.forward * 5f);
            forceApplied = true;
            StartCoroutine(ResetForceApplied());
        }
    }

    void FixedUpdate(){
        if (transform.position.z > 5.6f)
        {
            // Apply a force in the negative z direction (backward) to move the ball backward
            rb.AddForce(Vector3.forward * 20f   );
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Respawn")) {
            rb.velocity = Vector3.zero;
            inPlay = false;
            gm.UpdateLives(-1);
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.transform.CompareTag("Brick"))
        {
            BrickScript brickScript = collision.gameObject.GetComponent<BrickScript>();
            
            if(brickScript.hitsToBreak > 1) {
                brickScript.BreakBrick();
            } else {

                Vector3 direction = new Vector3(0,0,-1); // Get the negative Z-axis direction
                Quaternion rotation = Quaternion.LookRotation(direction);

                int randChance = Random.Range(1,101);
                if(randChance < 33){
                    Instantiate(powerup, collision.transform.position, rotation);
                }
                
                Transform newExplosion = Instantiate (explosion, collision.transform.position, rotation);
                Destroy(newExplosion.gameObject, 2.5f);

                gm.UpdateScore (brickScript.points);
                gm.UpdateNumberOfBricks();
                Destroy(collision.gameObject);

            }

            audio1.Play();

        }
    }

    IEnumerator ResetForceApplied()
    {
        yield return new WaitForSeconds(resetTime);
        forceApplied = false;
    }

}


