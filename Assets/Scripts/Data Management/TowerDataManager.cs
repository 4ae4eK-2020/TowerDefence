using System;
using System.Collections.Generic;
using UnityEngine;


public class TowerDataManager : MonoBehaviour
{
    [Serializable]
    public class Data
    {
        public string name;
        public int damage;
        public float attackSpeed;
        public int Id;
    }

    private GameObject prefab;

    [SerializeField] private SquadManager squadManager;
    [SerializeField] private SaveTowerParams saveTowerParams;
    [SerializeField] private LoadTowerParams loadTowerParams;
    [SerializeField] private Data data;
    [SerializeField] private List<GameObject> prefabs;
    [SerializeField] private string fileName;



    void Start()
    {
        data = loadTowerParams.Load(ref data, fileName);
        prefab = prefabs.Find(item => item.name == data.name);
        squadManager.towerPrefab = prefab;
        Invoke(nameof(LateStart), 0.02f);
    }

    void LateStart()
    {
        squadManager.Equip();
    }
    
    void OnDestroy()
    {
        saveTowerParams.Save(data, fileName);
    }

}
