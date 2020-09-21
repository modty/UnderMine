/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */

using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ContainRendererSorter : MonoBehaviour {

    private int sortingOrderBase = 500; // This number should be higher than what any of your sprites will be on the position.y
    private int offset = 3;
    private float timer;
    private float timerMax = .1f;
    [SerializeField]
    private bool runOnly=true;
    private Renderer[] renders;

    private float positionY ;

    private void Awake()
    {
        renders = GetComponentsInChildren<Renderer>();
    }

    private void LateUpdate() {
        timer -= Time.deltaTime;
        positionY = transform.position.y;
        if (timer <= 0f) {
            timer = timerMax;
            foreach (var render in renders)
            {
                render.sortingOrder = (int)(sortingOrderBase - positionY*5 - offset);
            }
            if (runOnly) {
                Destroy(this);
            }
        }
    }

}
