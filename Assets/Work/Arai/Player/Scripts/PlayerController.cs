using UnityEngine;
using Leap;

public class PlayerController : MonoBehaviour
{


    #region vertical property
    #region advance property
    public bool isInputForwardMovement
    {
        get
        {
            if (Input.GetAxis("Vertical") <= 0.0f) return false;
            return true;
        }
    }

    public bool IsInputForwardMovement(out float value)
    {
        value = Input.GetAxis("Vertical");
        if (value <= 0.0f) return false;
        return true;
    }
    #endregion

    #region reverse property
    public bool isInputBackwardMovement
    {
        get
        {
            if (Input.GetAxis("Vertical") >= 0.0f) return false;
            return true;
        }
    }

    public bool IsInputBackwardMovement(out float value)
    {
        value = Input.GetAxis("Vertical");
        if (value >= 0.0f) return false;
        return true;
    }
    #endregion

    public float getInputVerticalValue
    {
        get
        {
            if (left_hand_input_ == null ||
                right_hand_input_ == null)
                return 0.0f;

            if (leap_contoller_.IsConnected)
            {
                if (left_hand_input_.isFront && right_hand_input_.isFront)
                {
                    return Mathf.Max(left_hand_input_.getVerticalValue, right_hand_input_.getVerticalValue);
                }
                else if (left_hand_input_.isBack && right_hand_input_.isBack)
                {
                    return Mathf.Min(left_hand_input_.getVerticalValue, right_hand_input_.getVerticalValue);
                }
                else
                {
                    return 0.0f;
                }
            }
            else
            {
                return Input.GetAxis("Vertical");
            }
        }
    }
    #endregion

    #region horizontal property
    #region rightmove property
    public bool isInputRightMovement
    {
        get
        {
            if (Input.GetAxis("Horizontal") <= 0.0f) return false;
            return true;
        }
    }

    public bool IsInputRightMovement(out float value)
    {
        value = Input.GetAxis("Horizontal");
        if (value <= 0.0f) return false;
        return true;
    }
    #endregion

    #region reverse property
    public bool isInputLeftMovement
    {
        get
        {
            if (Input.GetAxis("Horizontal") <= 0.0f) return false;
            return true;
        }
    }

    public bool IsInputLeftMovement(out float value)
    {
        value = Input.GetAxis("Horizontal");
        if (value <= 0.0f) return false;
        return true;
    }
    #endregion

    public float getInputHorizontalValue
    {
        get
        {
            if (left_hand_input_ == null ||
                right_hand_input_ == null)
                return 0.0f;
            if (leap_contoller_.IsConnected)
            {
                if (left_hand_input_.isRight && right_hand_input_.isRight)
                {
                    return Mathf.Max(left_hand_input_.getHorizaontalValue, right_hand_input_.getHorizaontalValue);
                }
                else if (left_hand_input_.isLeft && right_hand_input_.isLeft)
                {
                    return Mathf.Min(left_hand_input_.getHorizaontalValue, right_hand_input_.getHorizaontalValue);
                }
                else
                {
                    return 0.0f;
                }
            }
            else
            {
                return Input.GetAxis("Horizontal");
            }
        }
    }
    #endregion

    #region rotate property

    public float getRotateValue
    {
        get
        {

            if (left_hand_input_ == null ||
                    right_hand_input_ == null)
                     return 0.0f;

            if (leap_contoller_.IsConnected)
            {
                if (left_hand_input_.isFront && right_hand_input_.isBack)
                {
                    return left_hand_input_.getVerticalValue;
                }
                else if (left_hand_input_.isBack && right_hand_input_.isFront)
                {
                    return -right_hand_input_.getVerticalValue;
                }
                else
                {
                    return 0.0f;
                }
            }
            else
            {
                return Input.GetAxis("Rotate");
            }
        }
    }

    #endregion

    #region jump property

    public bool isInputJump
    {
        get
        {
            if (right_hand_input_ == null ||
                left_hand_input_ == null)
                return false;
            if (leap_contoller_.IsConnected)
            {
                if (right_hand_input_.isRight && left_hand_input_.isLeft)
                {
                    if (right_hand_input_.getHorizaontalValue > 0.3f &&
                        left_hand_input_.getHorizaontalValue < -0.3f)
                    {

                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return Input.GetKeyDown(KeyCode.Space);
            }
        }
    }

    public float getJumpValue
    {
        get
        {
            return Input.GetAxis("Jump");
        }
    }

    #endregion

    #region fire property

    #region right

    public bool isInputRightAttack
    {
        get
        {
            if (right_hand_input_ == null)return false;
            if (leap_contoller_.IsConnected)
            {
                return right_hand_input_.isGrabed;
            }
            else
            {
                return Input.GetMouseButton(1);
            }
        }
    }

    #endregion

    #region left

    public bool isInputLeftAttack
    {
        get
        {
            if (left_hand_input_ == null) return false;
            if (leap_contoller_.IsConnected)
            {
                return left_hand_input_.isGrabed;
            }
            else
            {
                return Input.GetMouseButton(0);
            }
        }
    }

    #endregion

    #endregion

    #region boost property

    public bool isInputBoost
    {
        get
        {
            return Input.GetKey(KeyCode.LeftShift);
        }
    }

    #endregion


    public void SetLeftHandInput(LeftHandInput left_hand_input)
    {
        left_hand_input_ = left_hand_input;
    }

    public void SetRightHandInput(RightHandInput right_hand_input)
    {
        right_hand_input_ = right_hand_input;
    }

    void Start()
    {
        leap_contoller_ = FindObjectOfType<HandController>().GetLeapController();
    }

    Controller leap_contoller_ = null;
    LeftHandInput left_hand_input_ = null;
    RightHandInput right_hand_input_ = null;
}