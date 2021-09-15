using System.Collections;
using UnityEngine;

public class EnemySpawnController : MonoBehaviour
{
    [SerializeField] private float cooldown;
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private int needToSpawn;
    [SerializeField] private BaseParams baseParams;

    private int enemyCount;
    private float timer;
    private GameObject[] enemyes;

    private void Start()
    {
        StartCoroutine(CountEnemyes());
    }

    private void Update()
    {
        enemyes = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private IEnumerator CountEnemyes()
    {
        while (true)
        {
            if (enemyCount == needToSpawn && enemyes.Length == 0 && baseParams.health > 0)
            {
                Debug.Log("Победа");
            }
            yield return null;
        }
    }
    
    private void FixedUpdate()
    {
        
        if (timer > 0)
        {
            timer -= Time.fixedDeltaTime;
        }
        else
        {
            if(enemyCount < needToSpawn)
            {
                Instantiate(enemyPrefab, transform.position, Quaternion.Euler(Vector3.zero));
                timer = cooldown;
                enemyCount++;
            }
        }
        
    }
}
