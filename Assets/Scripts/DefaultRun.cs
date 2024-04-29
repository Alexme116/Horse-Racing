using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DefaultRun : MonoBehaviour
{
    private float speed = 5f;
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

        if (speed > 0){
            animator.SetFloat("Speed", 1);
        } else {
            animator.SetFloat("Speed", 0);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Finish"){
            speed = 0;
        }
    }
}
