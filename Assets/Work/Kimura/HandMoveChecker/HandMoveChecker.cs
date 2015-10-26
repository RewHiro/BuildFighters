using UnityEngine;
using System.Collections;

public class HandMoveChecker : MonoBehaviour
{


    public enum MoveType
    {
        ADVANCE,
        BACKWARD,
        STOP
    }

    HandController hand_controller_ = null;

    SkeletalHand skeleta_hand_;

    IsHandExist is_hand_exist_;

    MoveType move_type_;

    Vector3 hand_pos_;

    Vector3 hand_old_pos_;

    bool once_position_unification_;

    Vector3 distance_difference_;


    [SerializeField, TooltipAttribute("1フレームで動かして判定する距離")]
    Vector3 one_frame_move_distance_ = new Vector3(0.4f,0,0.4f);


    void Start()
    {
        hand_controller_ = FindObjectOfType<HandController>();
        skeleta_hand_ = GetComponent<SkeletalHand>();
        is_hand_exist_ = GetComponentInParent<IsHandExist>();

        move_type_ = MoveType.STOP;
        hand_pos_ = skeleta_hand_.GetPalmPosition();
        hand_old_pos_ = hand_pos_;
        once_position_unification_ = false;
        distance_difference_ = new Vector3(0.0f,0.0f,0.0f);
    }


    void Update()
    {
        HandPositionManager();
    }

    void HandPositionManager()
    {
        HandAppearOrVanish();
        HandMoveCheck();
    }


    void HandAppearOrVanish()
    {
        if (is_hand_exist_.IsExistence() == true
            && once_position_unification_ == false)
        {
            hand_old_pos_ = hand_pos_;

            once_position_unification_ = true;
        }
        else
        if (is_hand_exist_.IsExistence() == false
            && once_position_unification_ == true)
        {
            hand_old_pos_ = hand_pos_;

            once_position_unification_ = false;
        }

    }


    public Vector3 HandMoveCheck()
    {

        hand_pos_ = skeleta_hand_.GetPalmPosition();

        distance_difference_.z = (hand_pos_.z - hand_old_pos_.z) / one_frame_move_distance_.z;

        if (distance_difference_.z > 1)
        {
            distance_difference_.z = 1;
        }
        else
        if (distance_difference_.z < -1)
        {
            distance_difference_.z = -1;
        }
        else
        {
            hand_old_pos_.z = hand_pos_.z;
        }

        distance_difference_.x = (hand_pos_.x - hand_old_pos_.x) / one_frame_move_distance_.x;

        if (distance_difference_.x > 1)
        {
            distance_difference_.x = 1;
        }
        else
        if (distance_difference_.x < -1)
        {
            distance_difference_.x = -1;
        }
        else
        {
            hand_old_pos_.x = hand_pos_.x;
        }


        return distance_difference_;
    }

    //public MoveType HandMoveCheck()
    //{

    //    hand_pos_ = skeleta_hand_.GetPalmPosition();

    //    if(is_hand_exist_.HandAppearOrVanish() ==  true)
    //    {
    //        hand_old_pos_ = hand_pos_;
    //    }
    //    else
    //    if(is_hand_exist_.HandAppearOrVanish() == false)
    //    {
    //        hand_old_pos_ = hand_pos_;
    //    }


    //    if (hand_pos_.z > hand_old_pos_.z + one_frame_move_distance_.z)
    //    {
    //        move_type_ = MoveType.ADVANCE;

    //    }
    //    else
    //    if (hand_pos_.z < hand_old_pos_.z - one_frame_move_distance_.z)
    //    {
    //        move_type_ = MoveType.BACKWARD;

    //    }
    //    else
    //    {
    //        move_type_ = MoveType.STOP;
    //        hand_old_pos_ = hand_pos_;

    //    }

    //    return move_type_;

    //}


}
