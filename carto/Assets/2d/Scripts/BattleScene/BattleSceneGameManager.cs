using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneGameManager : MonoBehaviour
{
    // *****************************************************
    // * 게임 오브젝트
    // *****************************************************
    // stage detail 정보
    private List<StageDetail> stageDetailList;

    // *****************************************************
    // * BattleSceneGameManager 싱글톤 인스턴스
    // *****************************************************
    public static BattleSceneGameManager sharedInstance = null;

    void Awake() 
    {
        if (sharedInstance != null &&  sharedInstance != this)
        {
            Destroy(gameObject);
        }
        else
        {
            sharedInstance = this;
        }
    }

    void Start()
    {
        SetupScene();
    }

    public void SetupScene()
    {
        // TODO
    }

    void Update()
    {
        
    }

}
