/* 
    ------------------- Code Monkey -------------------

    Thank you for downloading this package
    I hope you find it useful in your projects
    If you have any questions let me know
    Cheers!

               unitycodemonkey.com
    --------------------------------------------------
 */
 
using UnityEngine;

public class ItemRendererSorter : MonoBehaviour {

    private int sortingOrderBase = 500; // This number should be higher than what any of your sprites will be on the position.y
    private int offset = 3;
    private bool runOnlyOnce = true;

    private float timer;
    private float timerMax = .1f;
    private Renderer myRenderer;

    private void Awake() {
        myRenderer = gameObject.GetComponent<Renderer>();
    }

    private void LateUpdate() {
        timer -= Time.deltaTime;
        if (timer <= 0f) {
            timer = timerMax;
            myRenderer.sortingOrder = (int)(sortingOrderBase - transform.position.y - offset);
            if (runOnlyOnce) {
                Destroy(this);
            }
        }
    }

}
