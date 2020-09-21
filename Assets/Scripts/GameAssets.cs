using System.Reflection;
using UnityEngine;

public class GameAssets: MonoBehaviour
{
    private static GameAssets instance;
    public static GameAssets Instance {
        get {
            if (instance == null) instance = Instantiate(Resources.Load<GameAssets>("GameAssets"));
            return instance;
        }
    }
    [SerializeField]
    private Sprite[] cPeonFemDead;
    [SerializeField]
    private Sprite[] cPeonFemWalkRight;
    [SerializeField]
    private Sprite[] cPeonFemWalkLeft;
    [SerializeField]
    private Sprite[] cPeonFemWalkBottom;
    [SerializeField]
    private Sprite[] cPeonFemWalkTop;
    [SerializeField]
    private Sprite[] cPeonFemDrink;
    [SerializeField]
    private Sprite[] cPeonFemHitFromRight;
    [SerializeField]
    private Sprite[] cPeonFemHitFromLeft;
    [SerializeField]
    private Sprite[] cPeonFemHitFromBottom;
    [SerializeField]
    private Sprite[] cPeonFemHitFromTop;
    [SerializeField]
    private Sprite[] cPeonFemIdleToRight;
    [SerializeField]
    private Sprite[] cPeonFemIdleToLeft;
    [SerializeField]
    private Sprite[] cPeonFemIdleToBottom;
    [SerializeField]
    private Sprite[] cPeonFemIdleToTop;
    [SerializeField]
    private Sprite[] cPeonFemItem;
    [SerializeField]
    private Sprite[] cPeonFemPray;
    [SerializeField]
    private Sprite[] cPeonFemSwingRight;
    [SerializeField]
    private Sprite[] cPeonFemSwingLeft;
    [SerializeField]
    private Sprite[] cPeonFemSwingBottom;
    [SerializeField]
    private Sprite[] cPeonFemSwingTop;
    [SerializeField]
    private Sprite[] cPeonFemSwipeRight;
    [SerializeField]
    private Sprite[] cPeonFemSwipeLeft;
    [SerializeField]
    private Sprite[] cPeonFemSwipeBottom;
    [SerializeField]
    private Sprite[] cPeonFemSwipeTop;
    [SerializeField]
    private Sprite[] cPeonFemThrowRight;
    [SerializeField]
    private Sprite[] cPeonFemThrowLeft;
    [SerializeField]
    private Sprite[] cPeonFemThrowBottom;
    [SerializeField]
    private Sprite[] cPeonFemThrowTop;
    public Sprite[] GetCPeonFemAnimationSprite(CPeonFem cPeonFem)
    {
        switch (cPeonFem)
        {
            case CPeonFem.Dead:
                return cPeonFemDead;
            case CPeonFem.WalkRight:
                return cPeonFemWalkRight;
            case CPeonFem.WalkLeft:
                return cPeonFemWalkLeft;
            case CPeonFem.WalkBottom:
                return cPeonFemWalkBottom;
            case CPeonFem.WalkTop:
                return cPeonFemWalkTop;
            case CPeonFem.Drink:
                return cPeonFemDrink;
            case CPeonFem.HitFromRight:
                return cPeonFemHitFromRight;
            case CPeonFem.HitFromLeft:
                return cPeonFemHitFromLeft;
            case CPeonFem.HitFromBottom:
                return cPeonFemHitFromBottom;
            case CPeonFem.HitFromTop:
                return cPeonFemHitFromTop;
            case CPeonFem.IdleToRight:
                return cPeonFemIdleToRight;
            case CPeonFem.IdleToLeft:
                return cPeonFemIdleToLeft;
            case CPeonFem.IdleToBottom:
                return cPeonFemIdleToBottom;
            case CPeonFem.IdleToTop:
                return cPeonFemIdleToTop;
            case CPeonFem.Item:
                return cPeonFemItem;
            case CPeonFem.Pray:
                return cPeonFemPray;
            case CPeonFem.SwingRight:
                return cPeonFemSwingRight;
            case CPeonFem.SwingLeft:
                return cPeonFemSwingLeft;
            case CPeonFem.SwingBottom:
                return cPeonFemSwingBottom;
            case CPeonFem.SwingTop:
                return cPeonFemSwingTop;
            case CPeonFem.SwipeRight:
                return cPeonFemSwipeRight;
            case CPeonFem.SwipeLeft:
                return cPeonFemSwipeLeft;
            case CPeonFem.SwipeBottom:
                return cPeonFemSwipeBottom;
            case CPeonFem.SwipeTop:
                return cPeonFemSwipeTop;
            case CPeonFem.ThrowRight:
                return cPeonFemThrowRight;
            case CPeonFem.ThrowLeft:
                return cPeonFemThrowLeft;
            case CPeonFem.ThrowBottom:
                return cPeonFemThrowBottom;
            case CPeonFem.ThrowTop:
                return cPeonFemThrowTop;
            default:
                return null;
        }
    }

}
