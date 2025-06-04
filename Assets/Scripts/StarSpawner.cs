using UnityEngine;

public class StarSpawner : MonoBehaviour
{
    [SerializeField] private GameObject starPrefab;
    [SerializeField] private int starCount = 300;
    [SerializeField] private float spreadX = 10f;
    [SerializeField] private float spreadY = 20f;

    void Start()
    {
        for (int i = 0; i < starCount; i++)
        {
            Vector3 pos = new Vector3(Random.Range(-spreadX, spreadX), Random.Range(0, spreadY), 1f);
            Instantiate(starPrefab, pos, Quaternion.identity);
        }
    }
}
