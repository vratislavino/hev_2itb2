using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest2D : MonoBehaviour
{
    private SpriteRenderer rend;

    [SerializeField]
    private Sprite closedChest;
    [SerializeField]
    private Sprite openedChest;

    bool isPlayerPresent = false;

    [SerializeField]
    private string levelToLoad;

    private void Start() {
        rend = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        rend.sprite = openedChest;
        isPlayerPresent = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        rend.sprite = closedChest;
        isPlayerPresent = false;
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.E)) {
            if(isPlayerPresent) {
                StartLevel(levelToLoad);
            }
        }
    }

    private void StartLevel(string level) {
        SceneManager.LoadScene(level);
    }
}
