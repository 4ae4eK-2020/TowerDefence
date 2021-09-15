using UnityEngine;

public class CostManager : MonoBehaviour
{
    public int money;

    [SerializeField] private float cooldown;
    [SerializeField] private float timer;
    
    private void FixedUpdate()
    {
        if (timer <= 0)
        {
            money++;
            timer = cooldown;
        }
        else
        {
            timer -= Time.deltaTime;
        }
    }
}
