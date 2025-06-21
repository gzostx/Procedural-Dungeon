using System;
using UnityEngine;

public class TilesSpawner : MonoBehaviour
{
    DungeonManager dgManager;

    private void Awake()
    {
        dgManager = FindAnyObjectByType<DungeonManager>();
        GameObject goFloor = Instantiate(dgManager.floorPrefab, transform.position, Quaternion.identity) as GameObject;
        goFloor.name = dgManager.floorPrefab.name;
        goFloor.transform.SetParent(dgManager.transform);

        if (transform.position.x > dgManager.maxX)
        {
            dgManager.maxX = transform.position.x;
        }

        if (transform.position.x < dgManager.minX)
        {
            dgManager.minX = transform.position.x;
        }
        if (transform.position.y > dgManager.maxY)
        {
            dgManager.maxY = transform.position.y;
        }

        if (transform.position.y < dgManager.minY)
        {
            dgManager.minY = transform.position.y;
        }
    }

    private void Start()
    {
        LayerMask lm = LayerMask.GetMask("Floor", "Wall");
        for (int x = -1; x <= 1; x++)
        {
            for (int y = -1; y <= 1; y++)
            {
                Vector2 targetPos = new Vector2(transform.position.x + x, transform.position.y + y);
                Collider2D hit = Physics2D.OverlapBox(targetPos, Vector2.one * 0.8f, 0, lm);
                if (!hit)
                {
                    // add a wall
                    GameObject goWall = Instantiate(dgManager.wallPrefab, targetPos, Quaternion.identity) as GameObject;
                    goWall.name = dgManager.floorPrefab.name;
                    goWall.transform.SetParent(dgManager.transform);
                }
            }
        }

        Destroy(gameObject);
        
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawCube(transform.position, Vector3.one);
    }
}
