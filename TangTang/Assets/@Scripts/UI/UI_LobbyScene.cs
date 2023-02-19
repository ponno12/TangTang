using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class UI_LobbyScene : UI_Scene
{
    enum GameObjects
    {
        Stage
    }
    enum Texts
    {
        StageNum
    }

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindObject(typeof(GameObjects));
        BindText(typeof(Texts));

        GetObject((int)GameObjects.Stage).BindEvent(OnClickStage);


        return true;
    }


    #region EventHandler
    void OnClickStage()
    {
        
        Managers.Scene.ChangeScene(Define.SceneType.GameScene);

        Managers.Sound.Play(Sound.Effect, "Sound_ButtonMain");
    }
    #endregion
}
