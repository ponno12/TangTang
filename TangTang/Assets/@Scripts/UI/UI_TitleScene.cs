using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Define;

public class UI_TitleScene : UI_Scene
{
    enum GameObjects
    {
        BG,
    }

    enum Texts
    {
        Title,
        Start
    }

    bool _isLoaded = false;

    public override bool Init()
    {
        if (base.Init() == false)
            return false;

        BindObject(typeof(GameObjects));
        BindText(typeof(Texts));
        

        GetObject((int)GameObjects.BG).BindEvent(OnClickBG);
        Managers.Sound.Play(Sound.Effect, "Sound_Opening");        

        return true;
    }
    
    public void ReadyToStart()
    {
        Debug.Log("ReadyToStarty call");
        _isLoaded = true;
        Debug.Log(_isLoaded);
        GetText((int)Texts.Start).enabled = true;
    }

    #region EventHandler
    void OnClickBG()
    {
        if(_isLoaded)
            Managers.Scene.ChangeScene(Define.SceneType.LobbyScene);

        Managers.Sound.Play(Sound.Effect, "Sound_ButtonMain");
    }
    #endregion
}
