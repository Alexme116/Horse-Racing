using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FinishGUIManager : MonoBehaviour
{
    [SerializeField]    private TMP_Text _top1Name; 
    [SerializeField]    private TMP_Text _top2Name;
    [SerializeField]    private TMP_Text _top3Name;
    public GameObject LeaderBoard;
    public GameObject GameOver;


    public static FinishGUIManager Instance {
        get;
        private set;
    }

    void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    public void SetTop1Name(string text) {
        if (_top1Name.text == "") {
            _top1Name.text = text;
        }
    }

    public void SetTop2Name(string text) {
        if (_top2Name.text == "") {
            _top2Name.text = text;
        }
    }

    public void SetTop3Name(string text) {
        if (_top3Name.text == "") {
            _top3Name.text = text;
        }
    }

    public void ShowLeaderBoard() {
        LeaderBoard.SetActive(true);
    }

    public void HideLeaderBoard() {
        LeaderBoard.SetActive(false);
    }

    public void ShowGameOver() {
        GameOver.SetActive(true);
    }

    public void HideGameOver() {
        GameOver.SetActive(false);
    }
}
