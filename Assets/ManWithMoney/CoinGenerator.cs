using UnityEngine;

public class CoinGenerator : MonoBehaviour
{
    [SerializeField]
    float interval = 0.5f;
    float currentCooldown;

    [SerializeField]
    GameObject coinPrefab;
    [SerializeField]
    GameObject nemecPrefab;

    void Start()
    {
        currentCooldown = interval;
    }

    void Update()
    {
        if(currentCooldown <= 0)
        {
            GenerateObject();
            currentCooldown = interval;
        } else
        {
            currentCooldown -= Time.deltaTime;
        }
    }

    void GenerateObject()
    {
        if(Random.Range(0,100) < 90)
        {
            Destroy(InstantiateObject(coinPrefab, Quaternion.Euler(-90, 0, 0)), 3f);
        } else
        {
            Destroy(InstantiateObject(nemecPrefab, Quaternion.identity), 3f);
        }
    }

    private GameObject InstantiateObject(GameObject prefab, Quaternion rot)
    {
        return Instantiate(prefab, new Vector3(
            Random.Range(-2.5f, 2.5f),
            transform.position.y,
            transform.position.z
        ), rot);
    }
}
