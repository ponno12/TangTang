using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LobbyScene : BaseScene
{
    UI_LobbyScene _lobbySceneUI;

    protected override bool Init()
    {
        if (base.Init() == false)
            return false;

        SceneType = Define.SceneType.LobbyScene;

        Managers.UI.ShowSceneUI<UI_LobbyScene>(callback: (lobbyscenUI) =>
        {
            _lobbySceneUI = lobbyscenUI;
        });

        
        return true;
    }

    


}
