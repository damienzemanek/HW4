using System;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PipeSpawner : MonoBehaviour
{
    public bool isDead = false;
    public Vector2 spawnRate = new Vector2(3, 4);
    public float pipesSpeed = 2f;
    public Transform spawnLoc;
    public GameObject pipePrefab;
    public Vector2 upDist = new Vector2(1, 2);
    public Vector2 downDist = new Vector2(1, 2);
    public Vector2 vertOffset = new Vector2(-3, 3);
    public List<GameObject> pipeDuos = new List<GameObject>();

    void Awake() => Locator.Instance.player.OnDeath += OnLose;

    public void Start() => InvokeRepeating(nameof(SpawnPipe), 1f, Random.Range(spawnRate.x, spawnRate.y));
    void FixedUpdate() => MoveAllSpawnedPipes();

    public void SpawnPipe()
    {
        var pipePos = spawnLoc.position;
        pipePos.y += Random.Range(vertOffset.x, vertOffset.y);
        var pipeDue = Instantiate(pipePrefab, pipePos, Quaternion.identity);
        var pipeTop = pipeDue.transform.GetChild(0);
        var pipeBottom = pipeDue.transform.GetChild(1);
        pipeTop.localPosition = new Vector2(pipeTop.localPosition.x, pipeTop.localPosition.y + Random.Range(upDist.x, upDist.y));
        pipeBottom.localPosition = new Vector2(pipeBottom.localPosition.x, pipeBottom.localPosition.y - Random.Range(downDist.x, downDist.y));
        pipeDuos.Add(pipeDue);
    }

    void MoveAllSpawnedPipes()
    {
        foreach (var pipeDuo in pipeDuos)
            if(!isDead) pipeDuo?.transform.Translate(Vector3.left * pipesSpeed);
    }

    void OnLose()
    {
        isDead = true;
        CancelInvoke(nameof(SpawnPipe));
    }
    
    
    
    
}
