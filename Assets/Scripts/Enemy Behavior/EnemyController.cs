using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    [SerializeField] private GameObject target;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private BaseParams baseParams;

    private Vector2 unitPos;
    private Vector2 basePos;
    void Start()
    {
        target = GameObject.FindWithTag("Base");

        baseParams = target.GetComponent<BaseParams>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        agent.SetDestination(target.transform.position);
        basePos = target.transform.position; 
        
        Debug.Log(basePos);

        StartCoroutine(EnemyUpdate());
    }

    private IEnumerator EnemyUpdate()
    {
        while (true)
        {
            unitPos = new Vector2(transform.position.x, transform.position.y - 0.000001f);
            
            if (unitPos == basePos)
            {
                agent.isStopped = true;
                baseParams.health -= 1;
                Destroy(gameObject);
            }
            yield return null;
        }
    }
}
