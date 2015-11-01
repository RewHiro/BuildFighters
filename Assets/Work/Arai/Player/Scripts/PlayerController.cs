using UnityEngine;
using System.Collections;

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
            return Input.GetAxis("Vertical");
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
            return Input.GetAxis("Horizontal");
        }
    }
    #endregion

    #region rotate property

    public float getRotateValue
    {
        get
        {
            return Input.GetAxis("Rotate");
        }
    }

    #endregion

    #region jump property

    public bool isInputJump
    {
        get
        {
            return Input.GetKeyDown(KeyCode.Space);
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
            return Input.GetMouseButton(1);
        }
    }

    #endregion

    #region left

    public bool isInputLeftAttack
    {
        get
        {
            return Input.GetMouseButton(0);
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

}