using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PaddleController : MonoBehaviour
{
    public float speed = 10f;
    public float rightEdge = 9.7f;
    public float leftEdge = -9.7f;
    public GameManager gm;
    void Update()
    {
        if(gm.gameOver){
            return;
        }
        float move = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        transform.Translate(0, 0, move);

        if (transform.position.x < leftEdge) {
            transform.position = new Vector3 (leftEdge, transform.position.y, transform.position.z);
        }
        if (transform.position.x > rightEdge) {
            transform.position = new Vector3 (rightEdge, transform.position.y, transform.position.z);
        }
    }

    void OnTriggerEnter(Collider other){
        if (other.CompareTag("ExtraLife")){
            gm.UpdateLives(1);
            Destroy(other.gameObject);
        }
    }

}

