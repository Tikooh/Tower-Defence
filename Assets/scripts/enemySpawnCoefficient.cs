using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ProportionalRandomSelector<T>
{
    
    public readonly Dictionary<T, int> percentageItemsDict;  //T is a generic type parameter which guarantees type safety  
    public ProportionalRandomSelector() => percentageItemsDict = new();
    //function to add an item to dictionary
    public void AddPercentageItem(T item, int percentage) => percentageItemsDict.Add(item, percentage); 

    public T SelectItem() 
    {
        // Calculate the summa of all portions.
        int poolSize = 0;
        foreach (int i in percentageItemsDict.Values) {
            poolSize += i;
        }

        // Get a random integer from 1 to PoolSize.
        int randomNumber = Random.Range(1, poolSize);

        // Detect the item, which corresponds to current random number.
        int accumulatedProbability = 0;
        foreach (KeyValuePair<T, int> pair in percentageItemsDict) { //iterates through dictionary and returns key value pairs of the type T, int
            accumulatedProbability += pair.Value; //current value to the accumulated probability
            if (randomNumber <= accumulatedProbability) // if random number falls within that region e.g. a probability coefficient of 30% might trigger between 0-30
                return pair.Key; //return the string part of key
        }
        
        return default;

    }
}
public class enemySpawnCoefficient : MonoBehaviour
{
    ProportionalRandomSelector<enemyType> randomSelector = new();
    public waveScriptableObject[] waveSO;

    public enemyScriptableObject[] enemySO;
    public enemyCreditScriptableObject creditSO;
    public GameObject[] enemyPrefab;
    private int credit;
    private GameObject enemy;
    private float spawnInterval;
    // Start is called before the first frame update

    public enum enemyType
    {
        minion,
        shield,
        deflector,
        thrower
    }
    void spawn()
    {
        enemyType result = randomSelector.SelectItem();
        switch (result)
        {
            case enemyType.minion:
                enemy = Instantiate(enemyPrefab[(int) enemyType.minion], transform.position, Quaternion.Euler(0,180f,0));
                enemy.GetComponent<enemyController>().enemySO = enemySO[(int) enemyType.minion];
                credit -= creditSO.minionCredit;
                break;

            case enemyType.shield:
                enemy = Instantiate(enemyPrefab[(int) enemyType.shield], transform.position, Quaternion.Euler(0,180f,0));
                enemy.GetComponent<enemyController>().enemySO = enemySO[(int) enemyType.shield];
                credit -= creditSO.shieldCredit;
                break;

            case enemyType.deflector:
                enemy = Instantiate(enemyPrefab[(int) enemyType.deflector], transform.position, Quaternion.Euler(0,180f,0));
                enemy.GetComponent<enemyController>().enemySO = enemySO[(int) enemyType.deflector];
                credit -= creditSO.deflectorCredit;
                break;

            case enemyType.thrower:
                enemy = Instantiate(enemyPrefab[(int) enemyType.thrower], transform.position, Quaternion.Euler(0,180f,0));
                enemy.GetComponent<enemyController>().enemySO = enemySO[(int) enemyType.thrower];
                credit -= creditSO.throwerCredit;
                break;


        }
        // return credit;
        // switch(result)
        // {
        //     case enemyType.minion:
                
                

            
        // }
    }
    void Start()
    {
        foreach (waveScriptableObject i in waveSO)
        {
            randomSelector.AddPercentageItem(enemyType.minion, i.minionSpawnCoefficient);
            randomSelector.AddPercentageItem(enemyType.shield, i.shieldSpawnCoefficient);
            randomSelector.AddPercentageItem(enemyType.deflector, i.deflectorSpawnCoefficient);
            randomSelector.AddPercentageItem(enemyType.thrower, i.throwerSpawnCoefficient);
            credit = i.credit;
            while (credit >= 0)
            {
                spawnInterval -= Time.deltaTime;
                if (spawnInterval <= 0)
                {
                    spawnInterval = Random.Range(1f,2f);
                    spawn();
                }
            }
            randomSelector.percentageItemsDict.Clear();
            Debug.Log("switching wave");
        }
    }
}
