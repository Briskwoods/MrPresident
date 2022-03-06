using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaffCharacter : MonoBehaviour
{
    public GameObject MaleStaff;
    public GameObject FemaleStaff;
    Animator ActiveAnimator;
    public CharacterBehaviourManager TheChar;
    bool Initialized;
    public float MoveSpeed = 2;
    public Transform TargetMovePos;
    public Transform ExitPos;
    Transform Target;
    public Transform ModelHolder;
    public bool Ready;
    public bool OverrideGender;
    public bool isMale;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (!Initialized)
        {
            if (TheChar.Initialized)
            {
                if (!OverrideGender)
                {
                    isMale = !TheChar.isMale;
                }
                else
                {
                   
                }

                if (isMale)
                {
                    ActiveAnimator = MaleStaff.GetComponent<Animator>();
                }
                else
                {
                    ActiveAnimator = FemaleStaff.GetComponent<Animator>();
                }
                MaleStaff.SetActive(isMale);
                FemaleStaff.SetActive(!isMale);
                Initialized = true;
                TheChar.SetAnimation("Idle");

            }
            return;

        }
        if (Target != null)
        {
           ModelHolder.position = Vector3.MoveTowards(ModelHolder.position, Target.position, MoveSpeed * Time.deltaTime);
            if (Vector3.Distance( ModelHolder.position, Target.position) < 0.01f)
            {
                ModelHolder.localEulerAngles = Vector3.zero;
               
                if (isMale)
                {
                    PlayAnimation("Talking");
                }
                else
                {
                    PlayAnimation("TalkingFemale");
                }
                Ready = true;
            }
            else
            {
                PlayAnimation("Walking");
                Ready = false;
            }
        }
        else
        {
            PlayAnimation("Idle");
            Ready = false;
        }
    }
    public void SetAnimationInt(string animation_name, int value)
    {
        ActiveAnimator.SetInteger(animation_name, value);
    }

    public void SetAnimationFloat(string animation_name, float value)
    {
        ActiveAnimator.SetFloat(animation_name, value);
    }

    public void PlayAnimation(string animation_name)
    {
        ActiveAnimator.Play(animation_name);
    }
    public void Enter()
    {
        Target = TargetMovePos;
        ModelHolder.localEulerAngles = Target.localEulerAngles;
    }
    public void Exit()
    {
        Target = ExitPos;
        ModelHolder.localEulerAngles = Target.localEulerAngles;

    }
}
