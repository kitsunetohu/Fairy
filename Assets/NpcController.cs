using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MonsterLove.StateMachine;
using UnityEngine.AI;

public class NpcController : MonoBehaviour
{
    public enum YukoState
    {
        sit,
        talking,
        walking,
    }
public Transform FinishPoint;
    Animator animator;
    StateMachine<YukoState> fsm;
    string defaultEm = "default";
    string smile = "smile";
    string confuse = "confuse";
    string surprise = "surprise";
    int surpriseNum=0;
    NavMeshAgent yukoNav;
    

    void Awake()
    {
        animator = GetComponent<Animator>();
        fsm = StateMachine<YukoState>.Initialize(this);
        fsm.ChangeState(YukoState.sit);
    }
    // Start is called before the first frame update
    void Start()
    {
        EventClasses.Instance.suprise.AddListener(Surprise);
        yukoNav=GetComponent<NavMeshAgent>();
    }

    void sit_Enter()
    {

        animator.CrossFade("Standing@loop", 0.1f, 0, 0);

    }

    void sit_Update()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            EventClasses.Instance.suprise.Invoke();
        }
        if (Input.GetKeyDown(KeyCode.W))
        {
            fsm.ChangeState(YukoState.walking);
        }
    }
    void walking_Enter()
    {
        animator.CrossFade("Walking@loop", 0.1f, 0, 0);
        yukoNav.destination=(FinishPoint.position);
         
    }
    void walking_Update()
    {
        //
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (fsm.State == YukoState.sit)
            {
                fsm.ChangeState(YukoState.walking);
            }
            else
            {
                fsm.ChangeState(YukoState.sit);
            }
        }
        Debug.Log(fsm.State);
    }

    public void Surprise()
    {
        if(surpriseNum==3){
            //話始まる
            fsm.ChangeState(YukoState.talking);
            Debug.Log("start talk");
        }
        //表情
        surpriseNum++;
        animator.CrossFade(surprise, 0.1f, 1, 0);
        StartCoroutine(wait2sAndChangeAnima(2,confuse,1));

        //動作 頭を上げる
    }

    IEnumerator wait2sAndChangeAnima(int waitTime,string animName,int animLayer)
    {
        yield return new WaitForSeconds(waitTime);
        animator.CrossFade(animName,0.1f,animLayer,0);
    }
}
