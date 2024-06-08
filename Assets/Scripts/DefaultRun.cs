using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


public class DefaultRun : MonoBehaviour
{
    private float speed = 0f;
    private float maxspeed = 8f;
    private Animator animator;
    private bool start = false;
    private bool end = false;
    float initTime= 3;
    public static List<string> winners = new List<string>();
    public GameObject controladorDatosJuego;

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
            speed = 8f;
        }

        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

        if (speed > 0){
            animator.SetFloat("Speed", 1);
        } else {
            animator.SetFloat("Speed", 0);
        }

        if (speed < maxspeed && start && !end){
            speed += 0.5f * Time.deltaTime;
        }
    }

    void OnCollisionEnter2D(Collision2D collision){
        if (collision.gameObject.tag == "Finish"){
            speed = 0;
            end = true;
            winners.Add(gameObject.name);
            if (winners.Count == 3){
                FinishGUIManager.Instance.SetTop1Name(winners[0]);
                FinishGUIManager.Instance.SetTop2Name(winners[1]);
                FinishGUIManager.Instance.SetTop3Name(winners[2]);
                StartCoroutine(Finish());
            }
        }
        // 
        if (collision.gameObject.tag == "Valla"){
            speed = 6f;
            VallaComportamiento.Instance.moverValla(collision.gameObject, gameObject);
        }
    }

    IEnumerator Finish(){
        if (winners.Contains("Your Horse")){
            FinishGUIManager.Instance.ShowLeaderBoard();
            yield return new WaitForSeconds(3);
            
            int horseTop = winners.IndexOf("Your Horse");
            if (horseTop == 0){
                PlayerData.Instance.AddCoins(50);
            } else if (horseTop == 1){
                PlayerData.Instance.AddCoins(30);
            } else if (horseTop == 2){
                PlayerData.Instance.AddCoins(15);
            }

            yield return new WaitForSeconds(3);
            FinishGUIManager.Instance.HideLeaderBoard();
        } else {
            FinishGUIManager.Instance.ShowGameOver();
            yield return new WaitForSeconds(3);
            FinishGUIManager.Instance.HideGameOver();
        }
        winners.Clear();
        controladorDatosJuego.GetComponent<ControladorDatosJuego>().GuardarDatos();
        SceneManager.LoadSceneAsync(0);
    }

    public float GetSpeed(){
        return speed;
    }
}
