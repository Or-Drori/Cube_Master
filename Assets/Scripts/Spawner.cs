using System.Collections.Generic;
using System.Linq;
using DefaultNamespace;
using UnityEngine;
using UnityEngine.Serialization;

public class    Spawner : MonoBehaviour
{
    [SerializeField] private int coinSpawnCount = 1; 
    [SerializeField] private int powerUpsSpawnCount = 1; 
    [SerializeField] private Renderer bboxRenderer;
    
    [SerializeField] private GenralFactory _genralFactory;
    
    private void Start()
    {
        Bounds bounds = bboxRenderer.bounds;
        SpawnObjects(SpawnableType.Coin,bounds,coinSpawnCount);
        SpawnObjects(SpawnableType.jumpPowerUp,bounds,powerUpsSpawnCount);
        SpawnObjects(SpawnableType.hulkPowerUp,bounds,powerUpsSpawnCount);
        SpawnObjects(SpawnableType.speedPowerUp,bounds,powerUpsSpawnCount);
    }

    private void SpawnObjects(SpawnableType spawnableType, Bounds bounds, int spawnCount)
    {
        for (int i = 0; i < spawnCount; i++)
        {
            Vector3 randomPosition = GetRandomPositionWithingBBox(transform.position, bounds);
            Vector3 spawnPosition = GetGroundPosition(randomPosition);
            _genralFactory.CreateByType(spawnableType, spawnPosition);
        }
    }

    private Vector3 GetRandomPositionWithingBBox(Vector3 center, Bounds bounds)
    {
        float randomPointX = Random.Range(bounds.min.x, bounds.max.x);
        float randomPointZ = Random.Range(bounds.min.z, bounds.max.z);
        return new Vector3(randomPointX, 1000, randomPointZ);
    }

    private Vector3 GetGroundPosition(Vector3 startPosition)
    {
        RaycastHit hit;
        if (Physics.Raycast(startPosition, Vector3.down, out hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Ground"))
            {
                return hit.point + Vector3.up * 0.5f; 
            }
        }
        return startPosition; 
    }
    
    
    
}