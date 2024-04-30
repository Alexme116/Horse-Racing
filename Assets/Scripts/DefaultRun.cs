using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DefaultRun : MonoBehaviour
{
    private float speed = 0f;
    private float maxspeed = 4f;
    private Animator animator;
    private bool start = false;
    private bool end = false;
    float initTime= 3;
    [SerializeField] TextMeshProUGUI countDownText;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        initTime -= Time.deltaTime;
        if (initTime <= 1 && !start){
            start = true;
            speed = 2f;
        }

        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

        if (speed > 0){
            animator.SetFloat("Speed", 1);
        } else {
            animator.SetFloat("Speed", 0);
        }

        if (speed < maxspeed && start && !end){
            // Aumentar la velocidad cada segundo
            speed += 0.5f * Time.deltaTime;
            print(speed);
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Finish"){
            speed = 0;
            end = true;
        }
    }
}
