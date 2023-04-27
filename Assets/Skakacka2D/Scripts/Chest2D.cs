using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Chest2D : MonoBehaviour
{
    private Animator chestAnimator;

    bool isPlayerPresent = false;

    [SerializeField]
    private string levelToLoad;

    private void Start() {
        chestAnimator = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        chestAnimator.SetTrigger("OpenChest");
        isPlayerPresent = true;
    }

    private void OnTriggerExit2D(Collider2D collision) {
        chestAnimator.SetTrigger("CloseChest");
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

        List<Zak> zaci = new List<Zak>();

        foreach(var zak in zaci) {
            zak.pva = new System.Random().Next(0, 1) == 0 ? 1 : 5;
        }

    }
    class Zak {
        public int pva;
    }
}
