using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameScene : BaseScene
{
    public PlayerController playerController;
    public PoolManager poolManager;

    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        SceneType = Define.SceneType.GameScene;

        //Managers.UI.ShowSceneUI<UI_GameScene>(callback: (lobbyscenUI) =>
        //{

        //});

        Managers.Game._player = playerController;
        Managers.Game._poolManager = poolManager;
        return true;
    }
}
