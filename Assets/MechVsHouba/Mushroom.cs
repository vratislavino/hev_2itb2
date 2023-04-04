using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mushroom : MonoBehaviour
{
    public Mushroom prefab;

    public float timeToSpread = 3;
    public float minX = 6.7f;

    public float speed = 7;
    private Rigidbody2D rb;

    public bool isFirst = false;
    // Start is called before the first frame update
    void Start() {
        rb = GetComponent<Rigidbody2D>();
        if (isFirst) {
            StartCoroutine(Spread());
        }
    }

    private IEnumerator Spread() {
        while (true) {
            yield return new WaitForSeconds(timeToSpread);
            var mush = Instantiate(prefab, GetRandomPos(), Quaternion.identity);
            mush.isFirst = false;
        }
    }

    private Vector3 GetRandomPos() {
        return new Vector3(Random.Range(-minX, minX), -3.41f, 0);
    }

    // Update is called once per frame
    void Update()
    {
        float xMove = 0;

        if (Input.GetKey(KeyCode.A)) {
            xMove = -speed;
        }
        if (Input.GetKey(KeyCode.D)) {
            xMove = speed;
        }
        rb.velocity = new Vector2(xMove, rb.velocity.y);
    }
}
