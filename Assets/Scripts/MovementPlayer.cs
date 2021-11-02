using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    [Tooltip("speed movement of the object")]
    [SerializeField] private float speed;

    [Tooltip("Animator of the player")]
    [SerializeField] private Animator animator;

    //Does the player look to the right
    private bool rightFace = true;
    // save the speed of the player
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
        Debug.Log("move: " + move); // test of move

        //If the player moves to the left and his face to the right
        if (move < 0 && rightFace)
        {
            transform.localScale = new Vector3(transform.localScale.x*-1, transform.localScale.y, transform.localScale.z);//turn him 180 degree
            rightFace = false;//he is not looking to the right
        }

        //If the player moves to the right and his face to the left
        else if (move > 0 && !rightFace)
        {
            transform.localScale = new Vector3(transform.localScale.x * -1, transform.localScale.y, transform.localScale.z);//turn him 180 degree
            rightFace = true;//he is looking to the right
        }
        transform.Translate(move*Time.deltaTime*speed, 0, 0); // move player

        //borders
        if (transform.position.x < -9 && !rightFace || transform.position.x > 9 && rightFace)
        {
            speed = 0;
        }
        else
        {
            speed = oldSpeed;
        }



    }
}
