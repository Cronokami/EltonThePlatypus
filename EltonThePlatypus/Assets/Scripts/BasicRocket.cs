using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class BasicRocket : MonoBehaviour
{
    private GameObject target;
    private Rigidbody2D rb2d;

    [SerializeField]
    private float speed;

    [SerializeField]
    private float maneuverabilityLerp;

    private void Start()
    {
        target = PlayerCore.SingletonObject;
        rb2d = gameObject.GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, target.transform.position);
        Debug.DrawLine(transform.position, target.transform.position);
        Debug.DrawLine(transform.position, transform.position + transform.up * 5);
        //Debug.Log( );


        var relativePos = target.transform.position - transform.position;

        var forward = transform.up;
        var angle = Vector3.Angle(relativePos, forward);
        if (Vector3.Cross (relativePos, forward).z > 0) angle = -angle; //this took more time than it should
        Debug.Log(angle);
        
        transform.Rotate(0, 0,  angle * maneuverabilityLerp);
        rb2d.velocity = transform.up * speed * Time.deltaTime;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
