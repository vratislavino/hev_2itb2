using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Fool : MonoBehaviour
{
    [SerializeField]
    protected float speed = 1;

    protected float currentAngle;

    Color originColor;
    MeshRenderer meshRenderer;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        meshRenderer = GetComponentInChildren<MeshRenderer>();
        originColor = meshRenderer.material.color;
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
        meshRenderer.material.color = Color.red;
        LeanTween.color(meshRenderer.gameObject, originColor, 0.25f);
    }

}
