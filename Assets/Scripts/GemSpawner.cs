using UnityEngine;

public class GemSpawner : MonoBehaviour
{
    public GameObject gemPrefab;

    public Vector3 gem1 = new Vector3(-3.5f, -3.5f);
    public Vector3 gem2 = new Vector3(-0.5f, 10.5f);
    public Vector3 gem3 = new Vector3(-10.5f, 11.5f);
    public Vector3 gem4 = new Vector3(-3.5f, 12.5f);
    public Vector3 gem5 = new Vector3(-3.5f, 13.5f);
    void SpawnGems()
    {
        Instantiate(gemPrefab, gem1, Quaternion.identity);
        Instantiate(gemPrefab, gem2, Quaternion.identity);
        Instantiate(gemPrefab, gem3, Quaternion.identity);
        Instantiate(gemPrefab, gem4, Quaternion.identity);
        Instantiate(gemPrefab, gem5, Quaternion.identity);
    }
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        SpawnGems();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}