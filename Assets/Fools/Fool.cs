using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fool : MonoBehaviour
{
    [SerializeField]
    protected float speed = 1;

    protected float currentAngle;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        ResetFool();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    protected abstract void Move();

    protected abstract void ReactToHit();

    private void GenerateAngle() {
        currentAngle = Random.Range(0, 360);
        transform.rotation = Quaternion.Euler(Vector3.up * currentAngle);
    }
    
    protected void ResetFool() {
        GenerateAngle();
        transform.position = Vector3.zero;
    }

    public void OnClicked() {
        Hit();
        ReactToHit();
    }

    private void Hit() {
        GetComponentInChildren<MeshRenderer>().material.color = Color.red;
    }

}
