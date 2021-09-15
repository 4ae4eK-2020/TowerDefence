using UnityEngine;

public class BaseParams : MonoBehaviour
{
    public int health;

    private void Update()
    {
        if(health <= 0) Debug.Log("Поражение");
    }
}
