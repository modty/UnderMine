using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.WebCam;

public class SpriteAnimator : MonoBehaviour
{
   private GameAssets gameAssets;

   public event EventHandler OnAnimationLooped;
   public event EventHandler OnAnimationLoopedFirstTime;
   private Sprite[] frameArray;
   private int currentFrame;
   private float timer;
   private float frameRate = .1f;
   private SpriteRenderer spriteRenderer;
   private bool isPlaying = true;
   private static int loopCounter;

   private int preActiveAnimType=1;
   
   private bool reserve;
   // 指定播放次数
   private int times=-1;
   private void Awake()
   {
      spriteRenderer = gameObject.GetComponent<SpriteRenderer>();
      gameAssets=GameAssets.Instance;
      Idle(new Vector3(0,-1));
   }

   private void Update()
   {
//      HandleActrack();
      if(!isPlaying ||frameArray.Length==0) return;
      timer += Time.deltaTime;
      if (timer >= frameRate)
      {
         timer -= frameRate;
         currentFrame=(currentFrame+1)%frameArray.Length;
         if(reserve) spriteRenderer.sprite = frameArray[frameArray.Length-currentFrame-1];
         else spriteRenderer.sprite = frameArray[currentFrame];
         if (currentFrame == 0)
         {
//            Debug.Log("times:"+times+"  looperCounter:"+loopCounter);
            // 超过指定的播放次数
            if (times!=-1&&times == loopCounter)
            {
               StopPlaying();
               return;
            }
            loopCounter++;
            if (loopCounter==1)
            {
               OnAnimationLoopedFirstTime?.Invoke(this,EventArgs.Empty);
            }
            OnAnimationLooped?.Invoke(this,EventArgs.Empty);
         }
      }
   }

   private void handleAnim()
   {
      
      timer += Time.deltaTime;
      if (timer >= frameRate)
      {
         timer -= frameRate;
         currentFrame = (currentFrame + 1) % frameArray.Length;
         spriteRenderer.sprite = frameArray[frameArray.Length - currentFrame - 1];
      }
   }

   private void StopPlaying()
   {
      isPlaying = false;
   }

   /**
    * @mes 
    * @date 2020/9/8 17:51
    * @return 
    * @params frameArray:精灵帧，frameRate：帧数，times：播放次数，flip:翻转方向（0:不翻转，1：X，2:Y）
    * @author 点木
   */

   private CPeonFem activeCPeonFem;
   public void PlayAnimationCPeonFem(CPeonFem c,float frameRate,int times,int flip,bool goOn,bool reverse)
   {
      frameArray = gameAssets.GetCPeonFemAnimationSprite(c);
      loopCounter = 0;
      isPlaying = true;
      if (!goOn)
      {
//         Debug.Log("赋值为0");
         reserve = reverse;
         this.frameRate = frameRate;
         currentFrame = 0;
         timer = 0f;
         this.times = times;
         if(reverse) spriteRenderer.sprite = frameArray[frameArray.Length-currentFrame-1];
         else spriteRenderer.sprite = frameArray[currentFrame];
         //判断是否翻转
         if (flip==1) spriteRenderer.flipX = true;
         else if (flip == 2) spriteRenderer.flipY = true;
         else
         {
            spriteRenderer.flipX = false;
            spriteRenderer.flipY = false;
         }
      }
   }

   public void Attack(int attackType,Vector3 vector3)
   {
      int direction;
      bool goOn=preActiveAnimType == 3;
      swipeExchange = !goOn && swipeExchange;
      preActiveAnimType = 3;
      Vector3 face=new Vector3(0,0);
      face = (Camera.main.ScreenToWorldPoint(vector3) - transform.position).normalized;
      // 获取鼠标点击相对
      if (face.x > 0)
      {
         if (face.x > Math.Abs(face.y))
            direction = 3;
         else
         {
            if (face.y > 0)
            {
               direction = 0;
            }
            else
            {
               direction = 1;
            }
         }
      }
      else
      {
         if (Math.Abs(face.x) > Math.Abs(face.y))
         {
            direction = 2;
         }
         else
         {
            if (face.y > 0)
            {
               direction = 0;
            }
            else
            {
               direction = 1;
            }
         }
      }
//      Debug.Log("攻击="+direction+"----"+goOn);
      switch (attackType)
      {
         case 1:
            DoAttackSwipe(direction,goOn);
            break;
         case 2:
            DoAttackThrow(direction,goOn);
            break;
      }

      preDirection = direction;
   }

   private bool swipeExchange=false;
   private void DoAttackSwipe(int direction,bool goOn)
   {
      switch (direction)
      {
         case 0:
            PlayAnimationCPeonFem(CPeonFem.SwipeTop,.1f,1,0,goOn,swipeExchange);
            break;
         case 1:
            PlayAnimationCPeonFem(CPeonFem.SwipeBottom,.1f,1,0,goOn,swipeExchange);
            break;
         case 2:
            PlayAnimationCPeonFem(CPeonFem.SwipeLeft,.1f,1,1,goOn,swipeExchange);
            break;
         case 3:
            PlayAnimationCPeonFem(CPeonFem.SwipeRight,.1f,1,0,goOn,swipeExchange);
            break;
      }
      swipeExchange = !swipeExchange;
   }
   private void DoAttackThrow(int direction,bool goOn)
   {
      switch (direction)
      {
         case 0:
            PlayAnimationCPeonFem(CPeonFem.ThrowTop,.03f,1,0,goOn,true);
            break;
         case 1:
            PlayAnimationCPeonFem(CPeonFem.ThrowBottom,.03f,1,0,goOn,true);
            break;
         case 2:
            PlayAnimationCPeonFem(CPeonFem.ThrowLeft,.03f,1,1,goOn,true);
            break;
         case 3:
            PlayAnimationCPeonFem(CPeonFem.ThrowRight,.03f,1,0,goOn,false);
            break;
      }
   }
   private int preDirection=4;
   public void Idle(Vector3 vector3)
   {
      int direction = Direction(vector3);
      if (direction!=4)
      {
         preDirection = direction;
      }
      else
      {
         direction = preDirection;
      }
      bool goOn = preDirection == direction && preActiveAnimType == 1;
      preActiveAnimType = 1;
//      Debug.Log("静止="+preDirection+"--->"+direction+"----"+goOn);
      DoIdle(direction,goOn);
   }

   private void DoIdle(int direction,bool goOn)
   {
      switch (direction)
      {
         case 0:
            PlayAnimationCPeonFem(CPeonFem.IdleToTop,.1f,-1,0,goOn,false);
            break;
         case 1:
            PlayAnimationCPeonFem(CPeonFem.IdleToBottom,.1f,-1,0,goOn,false);
            break;
         case 2:
            PlayAnimationCPeonFem(CPeonFem.IdleToLeft,.1f,-1,1,goOn,false);
            break;
         case 3:
            PlayAnimationCPeonFem(CPeonFem.IdleToRight,.1f,-1,0,goOn,false);
            break;
      }
   }

   public void Move(Vector3 vector3)
   {
      
      int direction = Direction(vector3);
      bool goOn = preDirection == direction&&preActiveAnimType == 2;
      preActiveAnimType = 2;
      preDirection = direction;
//      Debug.Log("移动="+direction+"----"+goOn);
      switch (Direction(vector3))
      {
         case 0:
            PlayAnimationCPeonFem(CPeonFem.WalkTop,.1f,1,0,goOn,false);
            break;
         case 1:
            PlayAnimationCPeonFem(CPeonFem.WalkBottom,.1f,1,0,goOn,false);
            break;
         case 2:
            PlayAnimationCPeonFem(CPeonFem.WalkLeft,.1f,1,1,goOn,false);
            break;
         case 3:
            PlayAnimationCPeonFem(CPeonFem.WalkRight,.1f,1,0,goOn,false);
            break;
      }
   }

   private int Direction(Vector3 vector3)
   {
      float moveX = vector3.x;
      float moveY = vector3.y;
      if (1f == moveY) return 0;
      if (-1f == moveY) return 1;
      if (-1f == moveX) return 2;
      if (1f == moveX)return 3;
      return 4;
   }
}
