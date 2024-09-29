using System.Collections;
using System.Collections.Generic;
using TutorialAssets.Scripts;
using UnityEngine;

public class MonsterManager : MonoBehaviour
{
    [SerializeField] private int amountOfMonsters = 10;
    [SerializeField] private Transform m_monsterSpawnPortal;
    [SerializeField] private Transform m_monsterAttackSpot;
    [SerializeField] private Transform m_monsterQueueSpot;
    [SerializeField] private GameObject[] monsterPrefabs;
    [SerializeField] private float waveDifficulty;

    
    
    public List<GameObject> monsters;

    // Start is called before the first frame update
    void Start()
    {

        for (int i = 0; i < amountOfMonsters; i++)
        {
            InstantiateMonsters();
        }

        MonsterAttacks(0);
        MoveNextMonsterToQueue();

        waveDifficulty = CalculateWaveDifficulty();

        
    }

    

    private void InstantiateMonsters()
    {
        //Spawn Monsters and add each of them into a List
        int monsterIndex = Random.Range(0, monsterPrefabs.Length);
        GameObject singleMonster = Instantiate(monsterPrefabs[monsterIndex], m_monsterSpawnPortal.position, m_monsterSpawnPortal.rotation);
        monsters.Add(singleMonster);
    }

    float CalculateWaveDifficulty()
    {
        float difficulty = 0;
        foreach (GameObject singleMonster in monsters)
        {
            difficulty += singleMonster.GetComponent<Points>().points;
        }
        difficulty /= amountOfMonsters * 3;
        return difficulty;
    }

    public void MonsterAttacks(int monsterIndex)
    {
        //About: Get the spawned monster to the point or spot m_monsterAttackSpot where they can attack
        if (monsters.Count <= monsterIndex) return; //a way to guide against error. it escapes if the index is greater the size of the container list

        Transform monster = monsters[monsterIndex].transform;

        monster.GetComponent<MonsterController>().ChangeState(MonsterState.Attack);

        monster.position = m_monsterAttackSpot.position;
        monster.rotation = m_monsterAttackSpot.rotation;
    }

    public void MoveMonsterToQueue(int monsterIndex)
    {
        //Get the spawned monster to the point or spot m_monsterQueueSpot where they can queue
        if (monsters.Count <= monsterIndex) return; //a way to guide against error. it escapes if the index is greater the size of the container list

        Transform monster = monsters[monsterIndex].transform;

        monster.GetComponent<MonsterController>().ChangeState(MonsterState.Queue);

        monster.position = m_monsterQueueSpot.position;
        monster.rotation = m_monsterQueueSpot.rotation;
    }

    public void MoveNextMonsterToQueue()
        {
            MoveMonsterToQueue(1);
        }

    public void KillMonster(int monsterIndex)
    {
        Destroy(monsters[monsterIndex]);
        monsters.RemoveAt(monsterIndex); //We not only destroy the monster, we also remove it from it's collection list
    }


    // Update is called once per frame
    void Update()
    {
        
    }


}
