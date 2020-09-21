// 音效播放

using System;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager:MonoBehaviour
{
    private static GameAssets instance;
    private AudioSource peasantAxeHeavyImpact02;    
    public static GameAssets Instance {
        get {
            if (instance == null) instance = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return instance;
        }
    }

}
