using System.Collections.Generic;
using UnityEngine;

public class SquadManager : MonoBehaviour
{
    public GameObject towerPrefab;

    public bool isEquiped;
    public List<SquadManager> SquadManagers;

    private RectTransform parent;
    private SquadManager currentSquadManager;
    
    public void Equip()
    {
        currentSquadManager = SquadManagers.Find(item => item.isEquiped == false);
        parent = currentSquadManager.GetComponent<RectTransform>();
        
        Instantiate(towerPrefab, parent.position, Quaternion.Euler(Vector3.zero), parent);
        currentSquadManager.isEquiped = true;

    }

    public void Remove()
    {
        isEquiped = false;
        Destroy(transform.GetChild(0).gameObject);
    }
}
