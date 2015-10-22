using UnityEngine;
using System.Collections;

public class HandMoveChecker : MonoBehaviour {

    HandController hand_controller_ = null;

    Vector3 hand_pos_;
    Vector3 hand_old_pos_;

    SkeletalHand skeleta_hand_;

    IsHandExist is_hand_exist_;

    bool once_position_unification_;

    public enum MoveType
    {
        ADVANCE,
        BACKWARD,
        STOP
    }

    MoveType movetype;

    void Start()
    {
        is_hand_exist_ = GetComponentInParent<IsHandExist>();
        once_position_unification_ = false;
        movetype = MoveType.STOP;
        hand_controller_ = FindObjectOfType<HandController>();
        skeleta_hand_ = GetComponent<SkeletalHand>();
        hand_old_pos_ = skeleta_hand_.GetPalmPosition();
        hand_pos_ = skeleta_hand_.GetPalmPosition();
    }


    void Update()
    {
        HandMoveCheck();
        Debug.Log(movetype);
    }

    void HandMoveCheck()
    {

        //foreach (var hand in FindObjectsOfType<SkeletalHand>())
        //{

        //    hand_pos_ = hand.GetPalmPosition();

        //    if (hand_pos_.z > hand_old_pos_.z + 0.3f)
        //    {

        //        transform.Translate(0, 0, 0.1f);
        //        return;
        //    }
        //    hand_old_pos_ = hand_pos_;
        //}

        hand_pos_ = skeleta_hand_.GetPalmPosition();


        if (is_hand_exist_.IsExistence() == true 
            && once_position_unification_ == false)
        {
            hand_old_pos_ = hand_pos_;
            once_position_unification_ = true;
        }

        if (is_hand_exist_.IsExistence() == false
            && once_position_unification_ == true)
        {
            hand_old_pos_ = hand_pos_;
            once_position_unification_ = false;
        }

        if (hand_pos_.z > hand_old_pos_.z + 0.4f)
        {
            movetype = MoveType.ADVANCE;

        }
        else
        if(hand_pos_.z < hand_old_pos_.z - 0.4f)
        {
            movetype = MoveType.BACKWARD;

        }else
        {
            movetype = MoveType.STOP;
            hand_old_pos_ = hand_pos_;

        }


    }

}
