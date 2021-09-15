using System.Collections;
using UnityEngine;

public class ShootManager : MonoBehaviour
{
    [SerializeField] private int towerDamage;
    [SerializeField] private float towerCooldown, towerDistance;

    private GameObject enemy;
    private float timer;
    private bool canShoot;

    void Start()
    {
        StartCoroutine(TowerUpdate());
    }

    private IEnumerator TowerUpdate()
    {
        while (true)
        {
            enemy = GameObject.FindWithTag("Enemy");

            if (enemy)
            {
                Vector2 direction = enemy.transform.position - transform.position;

                float distanceToEnemy = Mathf.Sqrt(direction.sqrMagnitude);

                if (distanceToEnemy <= towerDistance && canShoot)
                {
                    RaycastHit2D[] hits = Physics2D.RaycastAll(transform.position, direction);

                    foreach (RaycastHit2D hit in hits)
                    {
                        if (hit.transform.CompareTag("Enemy"))
                        {
                            hit.transform.GetComponent<EnemyParams>().health -= towerDamage;
                        }
                    }
                }
            }

            yield return null;
        }
    }

    private void FixedUpdate()
    {
        if (timer > 0)
        {
            canShoot = false;
            timer -= Time.fixedDeltaTime;
        }
        else
        {
            canShoot = true;
            timer = towerCooldown;
        }
    }
}
