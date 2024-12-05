using System;
using System.Collections;
using CrazyGames;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public GameObject[] skins;

    [SerializeField] int attemptsCount;

    [SerializeField] int difficultyFactor = 0;
    public float timer = 0;
    public static GameManager instance;
    HudManager hud;
    public AdManager ad;
    SoundManager sm;
    bool paused = false;

    public int defaultVehicleScore;
    public int defaultDroneScore;
    public int defaultJetScore;
    [SerializeField] int vehicleScore;
    [SerializeField] int droneScore;
    [SerializeField] int jetScore;

    int numFighters = 0;
    int numDrones = 0;
    int numVehicles = 0;

    int score;
    int coins;

    public float scoreTimerSpeed;
    float scoreTimer;

    // Items
    public float itemSpawnChance;
    public GameObject heartPrefab;
    public GameObject coinPrefab;

    public FighterController playerJet;

    public static GameManager Instance
    {
        get
        {
            if (instance == null)
            {
                instance = new GameManager();
            }

            return instance;
        }
    }

   
    void Start()
    {
        jetScore = defaultJetScore;
        droneScore = defaultDroneScore;
        vehicleScore = defaultVehicleScore;
        hud = GetComponent<HudManager>();
        sm = GetComponent<SoundManager>();
        attemptsCount++;
        SaveAttemptsCount();
        ControlAttemptsNumber(); 
        CrazySDK.Game.GameplayStart();
    }

    public static bool IsTablet()
    {
        float ratio = (float)Screen.width / Screen.height;

        if (ratio <= 1.5) return true;
        return false;

    }
    public void Awake()
    {
        SelectPlayerSkin();
        ad = GetComponentInChildren<AdManager>();
        attemptsCount = CrazySDK.Data.GetInt("AttemptsCount");
    }

    public void RevivePlayer()
    {
        playerJet.currentHealth = playerJet.maxHealth;
        playerJet.gameObject.SetActive(true);
        StartCoroutine(playerJet.Revive());
        hud.CloseEndGameMenu();
        attemptsCount--;
        SaveAttemptsCount();
        sm.ResumeMusic();
        CrazySDK.Game.GameplayStart();
    }

    public void SelectPlayerSkin()
    {
        int selectedSkin = GameDataManager.GetSelectedJetIndex();
        playerJet = skins[selectedSkin].GetComponentInChildren<FighterController>();
        skins[selectedSkin].SetActive(true);
    }

    public void ControlAttemptsNumber()
    {
        if(attemptsCount >= 4)
        {
            CrazyScript.Instance.ShowInterstitialAd();  
        }
    }
    
    public void SaveAttemptsCount() => CrazySDK.Data.SetInt("AttemptsCount", attemptsCount);

    void Update()
    {
        timer += Time.deltaTime;
        scoreTimer += Time.deltaTime;

        
        if(scoreTimerSpeed == 0)
        {
            score += difficultyFactor / 10;
        }
        else if (scoreTimer >= scoreTimerSpeed)
        {
            score += 1;
            scoreTimer = 0;
        }

        if (timer > 10)
        {
            difficultyFactor += 1;
            jetScore = IncreaseOnKillScore(defaultJetScore, 1.3f);
            droneScore = IncreaseOnKillScore(defaultDroneScore, 1.5f);
            vehicleScore = IncreaseOnKillScore(defaultVehicleScore, 1.8f);
            IncreaseItemSpawnChance();
            IncreaseScoreAccural();
            timer = 0;
        }

        HandlePauseInput();
    }

    private void HandlePauseInput()
    {
        // Check for pause/unpause input
        if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && !paused)
        {
            paused = true;
            hud.OnPauseButtonClick();
        }
        else if ((Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.P)) && paused)
        {
            paused = false;
            hud.OnResumeGameButtonClick();
        }
    }

    public void IncreaseScoreAccural()
    {
        if (scoreTimerSpeed > 0f)
        {
            scoreTimerSpeed -= 0.01f;
        }
        else scoreTimerSpeed = 0f;
    }

    public void IncreaseItemSpawnChance()
    {
        if (itemSpawnChance + 1f <= 100) itemSpawnChance += 1f;  
    }
    
    public int IncreaseOnKillScore(float defaultScore, float coef)
    {
        return (int) (defaultScore + (difficultyFactor * 5 * coef));
    }

    public void OnDestroyItemGenerator(Vector3 spawnPos, bool x)
    {
        if(UnityEngine.Random.Range(0f, 101f) <= itemSpawnChance)
        {
            float spawnPercentage = UnityEngine.Random.Range(0, 101f);
            if (spawnPercentage >= 50f)
            {
                Instantiate(coinPrefab, spawnPos, Quaternion.identity).GetComponent<Item>().ChooseDirection(x);
            }
            else Instantiate(heartPrefab, spawnPos, Quaternion.identity).GetComponent<Item>().ChooseDirection(x);
        }
    }


    public void IncreaseDestroyedEnemy(string playerPref)
    {
        int destroyedEnemies = CrazySDK.Data.GetInt(playerPref);
        destroyedEnemies++;
        CrazySDK.Data.SetInt(playerPref, destroyedEnemies);
        Debug.Log(playerPref + " " + destroyedEnemies);
    } 

    public void RestartGame() => SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    public void GameEnd()
    {
        coins += score / 250;
        if (score > CrazySDK.Data.GetInt("score"))
        {
            CrazySDK.Data.SetInt("score", score);
            hud.ShowNewRecord();
            CrazySDK.Game.HappyTime();
        }
        GameDataManager.AddCoins(coins);
        hud.ShowEndGameMenu();
        attemptsCount++;
        SaveAttemptsCount();
        sm.PauseMusic();
    }

    public void DoubleCoins()
    {
        GameDataManager.AddCoins(coins);
        coins *= 2;
        hud.UpdateCoinTMP();
        Time.timeScale = 0;
    }

    public int NumFighters
    {
        get { return numFighters; }
        set { numFighters = value; }
    }

    public int DifficultyFactor
    {
        get { return difficultyFactor; }
        set { difficultyFactor = value; }
    }

    public int Score
    {
        get { return score; }
        set { score = value; }
    }

    public int NumDrones
    {
        get { return numDrones; } 
        set { numDrones = value; }
    }

    public int Coins
    {
        get { return coins; }
        set {  coins = value; }
    }

    public int NumVehicles
    {
        get { return numVehicles; }
        set { numVehicles = value; }
    }

    public int VehicleScore { get => vehicleScore; set => vehicleScore = value; }
    public int DroneScore { get => droneScore; set => droneScore = value; }
    public int JetScore { get => jetScore; set => jetScore = value; }
    public int AttemptsCount { get => attemptsCount; set => attemptsCount = value; }
}
