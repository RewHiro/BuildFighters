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

    [SerializeField, TooltipAttribute("1フレームで動かして判定する距離")]
    float one_frame_move_distance_ = 0.4f;


    void Start()
    {
        hand_controller_ = FindObjectOfType<HandController>();
        skeleta_hand_ = GetComponent<SkeletalHand>();
        is_hand_exist_ = GetComponentInParent<IsHandExist>();

        once_position_unification_ = false;
        move_type_ = MoveType.STOP;
        hand_pos_ = skeleta_hand_.GetPalmPosition();
        hand_old_pos_ = hand_pos_;
    }


    void Update()
    {
        HandMoveCheck();
        Debug.Log(move_type_);
    }

    public MoveType HandMoveCheck()
    {

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

        if (hand_pos_.z > hand_old_pos_.z + one_frame_move_distance_)
        {
            move_type_ = MoveType.ADVANCE;

        }
        else
        if (hand_pos_.z < hand_old_pos_.z - one_frame_move_distance_)
        {
            move_type_ = MoveType.BACKWARD;

        }
        else
        {
            move_type_ = MoveType.STOP;
            hand_old_pos_ = hand_pos_;

        }

        return move_type_;

    }

}
