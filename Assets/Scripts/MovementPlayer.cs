using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [Tooltip("speed movement of the object")]
    [SerializeField] private float speed;
    private Vector3 movement;
    [SerializeField] private Animator animator;
    private bool rightFace = true;
    private float oldSpeed = 0;
    // Start is called before the first frame update
    void Start()
    {
        oldSpeed = speed;
    }

    // Update is called once per frame
    void Update()
    {
        float move = Input.GetAxis("Horizontal");
        animator.SetFloat("Speed", Mathf.Abs(move));
        Debug.Log("move: " + move);

        if(move < 0 && rightFace)
        {
            transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);
            rightFace = false;
        }
        else if(move > 0 && !rightFace)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);
            rightFace = true;
        }
        transform.Translate(move*Time.deltaTime*speed, 0, 0);
        if (transform.position.x < -10.300 && !rightFace || transform.position.x > 10.300 && rightFace)
        {
            speed = 0;
        }
        else
        {
            speed = oldSpeed;
        }



    }
}
