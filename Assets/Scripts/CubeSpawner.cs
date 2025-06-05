using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class CubeSpawner : MonoBehaviour
{
    [SerializeField] public GameObject follow;
    //[SerializeField] public GameObject score;
    [SerializeField]private MovingCube cubePrefab;
    [SerializeField]
    private MoveDirection moveDirection;
    

    public void Start()
    {

    }
    public void SpawnCube() { 
        var cube = Instantiate<MovingCube>(cubePrefab);
        cube.gameObject.SetActive(true);
        if (MovingCube.LastCube != null && MovingCube.LastCube.gameObject != GameObject.Find("Start"))
        {
            float x = moveDirection == MoveDirection.X ? transform.position.x : MovingCube.LastCube.transform.position.x;
            float z = moveDirection == MoveDirection.Z ? transform.position.z : MovingCube.LastCube.transform.position.z;
            cube.transform.position = new Vector3(x, MovingCube.LastCube.transform.position.y + cubePrefab.transform.localScale.y, z);
            follow.transform.position = new Vector3(0, MovingCube.LastCube.transform.position.y, 0);
            
        }
        else {
            cube.transform.position = transform.position;
        }
        cube.MoveDirection = moveDirection;
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireCube(transform.position, cubePrefab.transform.localScale);
    }
    
}
