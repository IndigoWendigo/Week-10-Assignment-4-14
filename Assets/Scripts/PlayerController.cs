using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed = 1;
    public float jumpForce = 2;
    public CoinManager cm;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float h = Input.GetAxis("Horizontal");

        //transform.Translate(Vector3.right * h * Time.deltaTime * speed);

        Rigidbody2D rb = GetComponent<Rigidbody2D>();

        Vector3 vel = new Vector3();

        vel.x = h * speed;
        vel.y = rb.velocity.y;
        vel.z = 0;

        rb.velocity = vel;

        if(Input.GetButtonDown("Jump"))
        {
            //rb.AddForce(Vector2.up * jumpForce);

            vel.y = jumpForce;
        }

        rb.velocity = vel;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            cm.coinCount++;
        }
    }
}
