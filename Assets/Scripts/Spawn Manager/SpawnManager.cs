using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{

    public List<Spawnpoint> jetSpawnpoints= new List<Spawnpoint>();
    public GameObject vehicleSpawnpoint;
    public GameObject jetPrefab;
    public GameObject dronePrefab;
    public GameObject passiveVehiclerefab;
    public GameObject activeVehiclePrefab;
    GameManager gm;

    public float defaultJetSpawnInterval;
    float jetSpawnInterval;
    bool canSpawnJet = false;
    bool canStartJetCoroutine;

    public float defaultDroneSpawnInterval;
    float droneSpawnInterval;
    bool canSpawnDrone = true;
    bool canStartSpawnDrone = false;

    public float defaultVehicleInterval;
    float vehicleSpawnInterval;
    bool canSpawnVehicle= true;
    bool canStartSpawnVehicle = false;


    void Start()
    {
        gm = GameObject.Find("Game Manager").GetComponent<GameManager>();
        vehicleSpawnInterval = defaultVehicleInterval;
        droneSpawnInterval = defaultDroneSpawnInterval;
        jetSpawnInterval = defaultJetSpawnInterval;
        StartCoroutine(SpawnJet());
        if(GameManager.IsTablet())
        {
            vehicleSpawnpoint.transform.position = new Vector2(vehicleSpawnpoint.transform.position.x, -17.6f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Ground Enemy

        if (gm.DifficultyFactor >= 10) canStartSpawnVehicle = true;

        if (vehicleSpawnInterval > 4) vehicleSpawnInterval = defaultVehicleInterval - (gm.DifficultyFactor / 2);
        else vehicleSpawnInterval = 4;

        if(canSpawnVehicle && canStartSpawnVehicle)
        {
            int vehicleType = (int) Random.Range(0, 101f); 
            if(vehicleType <= 33)
            {
                Instantiate(activeVehiclePrefab, vehicleSpawnpoint.transform.position, Quaternion.identity);
                canSpawnVehicle = false;
                StartCoroutine(SpawnVehicle());
            }
            else
            {
                Instantiate(passiveVehiclerefab, vehicleSpawnpoint.transform.position, Quaternion.identity);
                canSpawnVehicle = false;
                StartCoroutine(SpawnVehicle());
            }
        }

        //Drone
        if(gm.DifficultyFactor >= 6) canStartSpawnDrone = true;

        if (droneSpawnInterval > 3) droneSpawnInterval = defaultDroneSpawnInterval - (gm.DifficultyFactor / 2);
        else droneSpawnInterval = 3;

        if(gm.NumDrones < 2 && canSpawnDrone && canStartSpawnDrone)
        {
            float spawnpos = Random.Range(-Camera.main.orthographicSize + 10f, Camera.main.orthographicSize - 3f);
            Instantiate(dronePrefab, new Vector2(jetSpawnpoints[0].transform.position.x, spawnpos), Quaternion.identity);
            canSpawnDrone = false;
            StartCoroutine(SpawnDrone());
        }


        // Jet Spawner;
        if (jetSpawnInterval > 3) jetSpawnInterval = defaultJetSpawnInterval - (gm.DifficultyFactor / 2);
        else jetSpawnInterval = 3;

        if (gm.NumFighters == 6)
        {
            canSpawnJet = false;
            canStartJetCoroutine = true;
        }

        if(!canSpawnJet && canStartJetCoroutine && gm.NumFighters < 6)
        {
            StartCoroutine(SpawnJet());
            canStartJetCoroutine = false; 
        }

        if(canSpawnJet && gm.NumFighters < 6)
        {
            int spawnpos = Random.Range(0, 9);
            if (spawnpos > 0 && spawnpos < 9)
            {
                if (jetSpawnpoints[spawnpos - 1].IsAvailable && jetSpawnpoints[spawnpos].IsAvailable && jetSpawnpoints[spawnpos+1].IsAvailable) SpawnJet(spawnpos);
            } 
            else if (spawnpos == 0)
            {
                if (jetSpawnpoints[spawnpos].IsAvailable && jetSpawnpoints[spawnpos + 1].IsAvailable) SpawnJet(spawnpos);
            }
            else
            {
                if (jetSpawnpoints[spawnpos - 1].IsAvailable && jetSpawnpoints[spawnpos].IsAvailable) SpawnJet(spawnpos);
            }
        }
    }



    IEnumerator SpawnVehicle()
    {
        yield return new WaitForSeconds(vehicleSpawnInterval);
        canSpawnVehicle = true;
    }
    IEnumerator SpawnDrone()
    {
        yield return new WaitForSeconds(droneSpawnInterval);
        canSpawnDrone = true;
    }

    void SpawnJet(int spawnpos)
    {
        Instantiate(jetPrefab, jetSpawnpoints[spawnpos].transform.position, Quaternion.identity);
                    Debug.Log($"{jetSpawnpoints[spawnpos].name}: spawned a jet");
                    canSpawnJet = false;
                    StartCoroutine(SpawnJet());
    }
    IEnumerator SpawnJet()
    {
        yield return new WaitForSeconds(jetSpawnInterval);
        canSpawnJet = true;
    }


}   
