using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleSceneGameManager : MonoBehaviour
{

    public static BattleSceneGameManager sharedInstance = null;

    void Awake() {
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

    // Update is called once per frame
    void Update()
    {
        
    }
}
