using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlayerData : MonoBehaviour
{
    private int coins = 150;
    public TMP_Text _coins;

    public static PlayerData Instance {
        get;
        private set;
    }

    private void Awake() {
        if (Instance == null) {
            Instance = this;
        } else {
            Destroy(gameObject);
        }
    }

    private void Update() {
        _coins.text = coins.ToString();
    }

    public void AddCoins(int coinsToAdd) {
        coins += coinsToAdd;
    }

    public int GetCoins() {
        return coins;
    }

    public void SetCoins(int newCoins) {
        coins = newCoins;
    }
}
