using System;
using UnityEngine;
using Random = UnityEngine.Random;


public class DungeonManager : MonoBehaviour
{
    public GameObject wallPrefab;
    public GameObject floorPrefab;
    public GameObject tilesSpawnPrefab;
    
    public float maxX;
    public float maxY;
    public float minX;
    public float minY;

    private void Start()
    {
        RandomWalker();
    }

    private void RandomWalker()
    {
        Vector3 currentPos = Vector3.zero;
        // set floor tile at currentPos

        while (true)
        {
            switch (Random.Range(1, 5))
            {
                case 1:
                    currentPos += Vector3.up; 
                    break;
                case 2:
                    currentPos += Vector3.down;
                    break;
                case 3:
                    currentPos += Vector3.left;
                    break;
                case 4:
                    currentPos += Vector3.right;
                    break;
            }
        }   

    }
}
