using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapLogic : MonoBehaviour
{


    private Rigidbody2D rigidBody;
    private Transform parent;
    private bool moveToOriginalPosition = false;
    [Range(0f,10f)]
    public float speed = 2.0f;
    // Start is called before the first frame update
    void Start()
    {
        rigidBody = this.GetComponent<Rigidbody2D>();
        parent = transform.parent.GetComponent<Transform>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("TRIGGERED");
        if (collision.CompareTag("Player"))
        {
            rigidBody.bodyType = RigidbodyType2D.Dynamic;
            
            

            //rigidBody.bodyType = RigidbodyType2D.Dynamic;
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //Damage code here
            Debug.Log("DAMAGE");
            rigidBody.bodyType = RigidbodyType2D.Static;
            moveToOriginalPosition = true;
        }
        else if (collision.gameObject.CompareTag("ground"))
        {
            rigidBody.bodyType = RigidbodyType2D.Static;
            
            moveToOriginalPosition = true;
        }


    }

    // Update is called once per frame
    void Update()
    {
        if (moveToOriginalPosition)
        {
            transform.position = Vector3.MoveTowards(transform.position, parent.position, speed * Time.deltaTime);
        }
        
        if(transform.position == parent.position)
        {
            moveToOriginalPosition = false;
        }
    }
}
