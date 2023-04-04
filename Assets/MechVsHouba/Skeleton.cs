using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : MonoBehaviour
{
    List<Mushroom> ms = new List<Mushroom>();
    Moss moss;

    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collision) {
        var moss = collision.GetComponent<Moss>();
        if (moss != null) {
            this.moss = moss;
        }

        var msh = collision.GetComponent<Mushroom>();
        if (msh != null) {
            ms.Add(msh);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        var moss = collision.GetComponent<Moss>();
        if (moss != null) {
            this.moss = null;
        }
        var msh = collision.GetComponent<Mushroom>();
        if (msh != null) {
            ms.Remove(msh);
        }

    }

    private void Update() {
        if(Input.GetKeyDown(KeyCode.E)) {
            Counter.instance.AddMushrooms(ms.Count);
        }

        if (Input.GetKeyDown(KeyCode.RightControl)) {
            if(moss != null)
                Counter.instance.AddMoss();
        }

    }
}
