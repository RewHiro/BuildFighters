using UnityEngine;
using System.Collections;
using Leap;
using System;

public class LeftHandInput : MonoBehaviour
{

    float ratio_ = 0.01f;

    float reference_point_ = 100.0f;

    float reaction_value = 0.1f;

    public float getHorizaontalValue
    {
        get
        {
            var point = reference_point_ + hand_model_.GetLeapHand().PalmPosition.x;
            point *= ratio_;
            point = Mathf.Clamp(point, -1.0f, 1.0f);
            if (reaction_value > point && -reaction_value < point) return 0.0f;
            return point;
        }
    }

    public float getVerticalValue
    {
        get
        {
            var point = -hand_model_.GetLeapHand().PalmPosition.z * ratio_;
            point = Mathf.Clamp(point, -1.0f, 1.0f);
            if (reaction_value > point && -reaction_value < point) return 0.0f;
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
            return hand_model_.GetLeapHand().GrabStrength > 0.5f;
        }
    }

    void Start()
    {
        hand_model_ = GetComponent<HandModel>();
        FindObjectOfType<PlayerController>().SetLeftHandInput(this);
    }

    HandModel hand_model_ = null;
}
