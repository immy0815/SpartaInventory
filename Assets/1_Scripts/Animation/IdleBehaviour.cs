using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleBehaviour : StateMachineBehaviour
{
    [SerializeField] private float timeUntilBored;
    [SerializeField] private int numberOfBoredAnims;
    [SerializeField] private int[] repeatCountOfBoredAnims;
    
    private bool isBored;
    private float idleTime;
    private int boredAnim;
    
    private int curLoopCount;
    private int prevLoopCount;
    
    // OnStateEnter is called when a transition starts and the state machine starts to evaluate this state
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        ResetIdle();
        timeUntilBored = 3;
    }

    // OnStateUpdate is called on each Update frame between OnStateEnter and OnStateExit callbacks
    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        if (!isBored)
        {
            idleTime += Time.deltaTime;
            if (idleTime > timeUntilBored 
                && stateInfo.normalizedTime % 1 < 0.05f)
            {
                isBored = true;
                boredAnim = Random.Range(1, numberOfBoredAnims + 1);
                timeUntilBored = Random.Range(3, 8);
            }
        }
        // State Info의 normalizedTime
        // 0일 때, 애니메이션 시작
        // 1일 때, 애니메이션 종료
        // 루프 애니메이션은 애니메이션이 종료될 때마다 2, 3, 4 점점 증가하게 됨.
        else if (stateInfo.normalizedTime % 1 > 0.98f)
        {
            int loopCount = Mathf.FloorToInt(stateInfo.normalizedTime);
            if (loopCount != prevLoopCount)
            {
                prevLoopCount = loopCount;
                curLoopCount++;
                if (curLoopCount >= repeatCountOfBoredAnims[boredAnim - 1])
                {
                    ResetIdle();
                }
            }
        }
        
        // dampTime
        // 이전값에서 value에 도달하는데 걸리는데 소요될것이라 가정하는 지연시간
        animator.SetFloat("BoredAnimation", boredAnim, 0.2f, Time.deltaTime);
    }

    private void ResetIdle()
    {
        isBored = false;
        idleTime = 0;
        boredAnim = 0;
        curLoopCount = 0;
        prevLoopCount = 0;
        
        repeatCountOfBoredAnims[0] = Random.Range(3, 6); // 0 = 달리기 모션
    }
}
