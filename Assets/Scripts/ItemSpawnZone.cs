using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawnZone : MonoBehaviour
{
    [SerializeField, Tooltip("Перфаб для создания" )]
    private GameObject _itemToSpawn;
    
    [SerializeField, Tooltip("Количество монет для создания")]
    private float _itemCount = 30;
    
    [SerializeField, Tooltip("Область для сщздания предметов")]
    private BoxCollider _spawnZone;


    void Start()
    {
        for (int i = 0; i < _itemCount; i++)
        {
            SpawnItemAtRandpmPosition();
        }
    }
    void SpawnItemAtRandpmPosition()
    {
        Vector3 randomPos;

        randomPos.x = Random.Range(_spawnZone.bounds.min.x, _spawnZone.bounds.max.x);
        randomPos.y = Random.Range(_spawnZone.bounds.min.y, _spawnZone.bounds.max.y);
        randomPos.z = Random.Range(_spawnZone.bounds.min.z, _spawnZone.bounds.max.z);

        Instantiate(_itemToSpawn, randomPos, Quaternion.identity);
    }

    void Update()
    {
        
    }
}
