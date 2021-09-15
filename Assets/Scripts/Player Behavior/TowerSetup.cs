using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class TowerSetup : MonoBehaviour
{
    [SerializeField] private Tilemap tilemap;
    [SerializeField] private GridLayout grid;
    public List<GameObject> towers;
    [SerializeField] private Camera cam;
    [SerializeField] private CostManager cost;
    [SerializeField] private int towerCost;

    [SerializeField] private GameObject tower;
    private Vector3 mousePos;
    private Vector3Int tilePos;
    private Vector3 towerPos;

    public List<Vector3> isSetuped;

    public void SetCurrentTower(string towerName)
    {
        Debug.Log("Нажато");
        tower = towers.Find(item => item.name == towerName);
    }
    
    void Start()
    {
        StartCoroutine(TowerUpdate());
    }

    private IEnumerator TowerUpdate()
    {
        while (true)
        {
            mousePos = cam.ScreenToWorldPoint(Input.mousePosition);
            tilePos = grid.WorldToCell(mousePos);
            towerPos = grid.CellToWorld(tilePos) + grid.cellSize/2;
            
            grid.CellToWorld(tilePos);
            if (Input.GetMouseButtonDown(1) && cost.money >= towerCost)
            {
                int index = isSetuped.FindIndex(item => item == towerPos);
                
                if(tilemap.GetTile(tilePos) != null && index == -1)
                {
                    SetTower();
                    cost.money -= towerCost;
                }
                else
                {
                    Debug.Log("Ошибка установки башни:\nВыбранная позиция находится за допустимыми пределами или не хватает средств для установки башни");
                }
            }
            
            yield return null;
        }
    }

    private void SetTower()
    {
        GameObject towerClone = Instantiate(tower, towerPos, Quaternion.Euler(Vector3.zero));
        isSetuped.Add(towerClone.transform.position);
    }
}