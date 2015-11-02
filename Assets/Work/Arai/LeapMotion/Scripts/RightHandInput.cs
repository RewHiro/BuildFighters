using UnityEngine;
using System.Collections;
using Leap;

public class RightHandInput : MonoBehaviour
{

    float ratio_ = 0.01f;

    float reference_point_ = -100.0f;

    [SerializeField]
    float REACTION_VALUE = 0.1f;

    [SerializeField]
    float REACTION_GRAB_VALUE = 0.5f;

    public float getHorizaontalValue
    {
        get
        {
            var point = reference_point_ + hand_model_.GetLeapHand().PalmPosition.x;
            point *= ratio_;
            point = Mathf.Clamp(point, -1.0f, 1.0f);
            if (REACTION_VALUE > point && -REACTION_VALUE < point) return 0.0f;
            return point;
        }
    }

    public float getVerticalValue
    {
        get
        {
            var point = -hand_model_.GetLeapHand().PalmPosition.z * ratio_;
            point = Mathf.Clamp(point, -1.0f, 1.0f);
            if (REACTION_VALUE > point && -REACTION_VALUE < point) return 0.0f;
            return point;
        }
    }

    public bool isFront
    {
        get
        {
            return getVerticalValue > 0.0f;
        }
    }

    public bool isBack
    {
        get
        {
            return getVerticalValue < 0.0f;
        }
    }

    public bool isRight
    {
        get
        {
            return getHorizaontalValue > 0.0f;
        }
    }

    public bool isLeft
    {
        get
        {
            return getHorizaontalValue < 0.0f;
        }
    }

    public bool isNeutral
    {
        get
        {
            return getHorizaontalValue == 0.0f &&
                getVerticalValue == 0.0f; 
        }
    }

    public bool isGrabed
    {
        get
        {
            return hand_model_.GetLeapHand().GrabStrength > REACTION_GRAB_VALUE;
        }
    }

    void Start()
    {
        hand_model_ = GetComponent<HandModel>();
        FindObjectOfType<PlayerController>().SetRightHandInput(this);
    }

    HandModel hand_model_ = null;
}
