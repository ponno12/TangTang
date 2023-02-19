using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
//using static Define;

[Serializable]
public class GameData
{
    public int Chapter = 1;
    public int Stage = 1;

    public int Coin;
    public int Dia;

    public int SelectedChapter;
    public int SelectedStage;

    public bool BGMOn = true;
    public bool EffectSoundOn = true;

    //public int[] DailyQuestID = new int[DAILY_QUEST_COUNT];
    public int LastStoryID = -1;
}

public class GameManagerEx
{
    GameData _gameData = new GameData();
    public GameData SaveData { get { return _gameData; } set { _gameData = value; } }

    #region Stage
    public int HighestChapter
    {
        get { return _gameData.Chapter; }
        set { _gameData.Chapter = value; }
    }

    public int HighestStage
    {
        get { return _gameData.Stage; }
        set { _gameData.Stage = value; }
    }

    public int SelectedStage
    {
        get { return _gameData.SelectedStage; }
        set { _gameData.SelectedStage = value; }
    }

    #endregion

    #region Player

    public PlayerController _player = null;
    public PoolManager _poolManager = null;
    public int Coin
    {
        get { return _gameData.Coin; }
        set { _gameData.Coin = value; }
    }

    public int Dia
    {
        get { return _gameData.Dia; }
        set { _gameData.Dia = value; }
    }


    #endregion

    #region Weapon
    //public int[] WeaponLevel { get { return _gameData.WeaponLevel; } }
    //public int[] WeaponExp { get { return _gameData.WeaponExp; } }
    #endregion

    #region Util
    //public int[] DailyQuestID { get { return _gameData.DailyQuestID; } }
    #endregion

    #region Option
    public bool BGMOn
    {
        get { return _gameData.BGMOn; }
        set { _gameData.BGMOn = value; }
    }

    public bool EffectSoundOn
    {
        get { return _gameData.EffectSoundOn; }
        set { _gameData.EffectSoundOn = value; }
    }
    #endregion

    public int CurrentStageGetCoin { get; set; }
    

    public void GetStageCoin(int stageReward)
    {
        Coin += CurrentStageGetCoin + stageReward;
        CurrentStageGetCoin = 0;
        SaveGame();
    }

    public float ZRotation { get; set; }
    public bool IsLoaded = false;

    public void Init()
    {
        _path = Application.persistentDataPath + "/SaveData.json";
        if (LoadGame())
            return;

        //ShortRangeWeaponID = 1;
        //MiddleRangeWeaponID = 9;
        //LongRangeWeaponID = 11;

        //WeaponLevel[0] = 1;
        //WeaponLevel[8] = 1;
        //WeaponLevel[10] = 1;

        IsLoaded = true;

        SaveGame();
    }

    public event Action OnPlayerInput;
    public void PlayerInput()
    {
        OnPlayerInput?.Invoke();
    }

    public event Action OnPlayerAttack;

    public void PlayerAttack()
    {
        OnPlayerAttack?.Invoke();
    }

    //public event Action<MonsterController> OnMonsterDead;
    //public void MonsterDead(MonsterController mc)
    //{
    //	OnMonsterDead?.Invoke(mc);
    //}

    //void Clear()
    //{
    //	OnChangeWeapon = null;
    //	OnPlayerAttack = null;
    //	OnMonsterDead = null;
    //	OnPlayerInput = null;
    //}

    public bool CheckCoin(int coin)
    {
        if (Coin >= coin)
            return true;
        else
            return false;
    }

    

    public bool CheckDia(int dia)
    {
        if (Dia >= dia)
            return true;
        else
            return false;
    }

    #region Save&Load
    string _path;

    public void SaveGame()
    {
        string jsonStr = JsonUtility.ToJson(Managers.Game.SaveData);
        File.WriteAllText(_path, jsonStr);
    }

    public bool LoadGame()
    {
        if (File.Exists(_path) == false)
            return false;

        string fileStr = File.ReadAllText(_path);
        GameData data = JsonUtility.FromJson<GameData>(fileStr);
        if (data != null)
            Managers.Game.SaveData = data;

        IsLoaded = true;
        return true;
    }
    #endregion
}