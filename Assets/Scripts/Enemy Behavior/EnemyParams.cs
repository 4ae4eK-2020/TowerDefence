using UnityEngine;
public class EnemyParams : MonoBehaviour
{
    public int health;

    private void Update()
    {
        if(health <=0) Destroy(gameObject);
    }
}