using UnityEngine;
using Leap;

<<<<<<< HEAD
<<<<<<< HEAD
public class PlayerController : MonoBehaviour
{

    readonly int GROUND_TAG_HASH = "Ground".GetHashCode();

    void Start()
    {
        var air_frame_parameter = FindObjectOfType<AirFrameParameter>();
        var id = GetComponent<Identificationer>().id;

        rigidbody_ = GetComponent<Rigidbody>();
        //rigidbody_.mass = air_frame_parameter.GetMass(id);
        //rigidbody_.drag = air_frame_parameter.GetDrag(id);

        move_speed_ = air_frame_parameter.GetMoveSpeed(id);
        swing_speed_ = air_frame_parameter.GetSwingSpeed(id);
        jump_power_ = air_frame_parameter.GetJumpPower(id);
    }

    void Update()
    {

        DebugMove();
        DebugRotate();

        if (Input.GetMouseButton(0))
        {
            //　左武装攻撃
        }

        if (Input.GetMouseButton(1))
        {
            //　右武装攻撃
        }
    }

    void FixedUpdate()
    {
        if (is_jump_) return;
        if (Input.GetAxis("Jump") != 1.0f) return;
        rigidbody_.AddForce(Vector3.up * jump_power_, ForceMode.Impulse);
        is_jump_ = true;

    }

    //　FixMe
    //　乗ったかどうか判定したい
    //　壁にあたったときもジャンプのフラグがoffになってしまう
    
    //　Tagつけまだ全てやってない
    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag.GetHashCode() != GROUND_TAG_HASH) return;
        is_jump_ = false;
    }

    //　TODO
    //　アナログスティック風用
    void Move()
    {

    }

    void DebugMove()
    {
        var direction = gameObject.transform.forward;
        var cross = Vector3.Cross(direction, gameObject.transform.up).normalized;

        var z_axis = Input.GetAxis("Vertical");
        var x_axis = Input.GetAxis("Horizontal");

        direction = direction * z_axis;
        direction += -cross * x_axis;

        //　デバッグ用
        var slope = 0.0f;
        if (z_axis == 0.0f)
        {
            slope = Mathf.Abs(x_axis);
        }
        else if (x_axis == 0.0f)
        {
            slope = Mathf.Abs(z_axis);
        }
        else
        {
            slope = (Mathf.Abs(x_axis) + Mathf.Abs(z_axis)) * 0.5f;
        }

        gameObject.transform.localPosition +=
            direction.normalized * move_speed_ * slope;
    }

    void DebugRotate()
    {
        gameObject.transform.Rotate(gameObject.transform.up, Input.GetAxis("Rotate") * swing_speed_);
=======
public class PlayerController : MonoBehaviour
{

    #region vertical property
=======
public class PlayerController : MonoBehaviour
{


    #region vertical property
>>>>>>> 8c4070969c7a0800422d06fd765c81e3170defbd
    #region advance property
<<<<<<< HEAD
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
=======
    public bool isInputForwardMovement
    {
        get
        {
            if (leap_contoller_.IsConnected) return isBothHandsFront;
            return Input.GetAxis("Vertical") <= 0.0f;
        }
    }
>>>>>>> 56add7e2d97cdc9537aedeab3d31493295123132
    #endregion

    #region reverse property
<<<<<<< HEAD
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

=======
    public bool isInputBackwardMovement
    {
        get
        {
            if (leap_contoller_.IsConnected) return isBothHandsBack;
            return Input.GetAxis("Vertical") >= 0.0f;
        }
    }

    #endregion

    public float getInputVerticalValue
    {
        get
        {
            if (!leap_contoller_.IsConnected) return Input.GetAxis("Vertical");

            if (isBothHandsFront)
            {
                return Mathf.Max(left_hand_input_.getVerticalValue, right_hand_input_.getVerticalValue);
            }
            else if (isBothHandsBack)
            {
                return Mathf.Min(left_hand_input_.getVerticalValue, right_hand_input_.getVerticalValue);
            }
            else
            {
                return 0.0f;
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
            if (leap_contoller_.IsConnected) return isBothHandsRight;
            return Input.GetAxis("Horizontal") <= 0.0f;
        }
    }

    #endregion

    #region leftmove property
    public bool isInputLeftMovement
    {
        get
        {
            if (leap_contoller_.IsConnected) return isBothHandsLeft;
            return Input.GetAxis("Horizontal") <= 0.0f;
        }
    }

    #endregion

    public float getInputHorizontalValue
    {
        get
        {
            if (!leap_contoller_.IsConnected) return Input.GetAxis("Horizontal");

            if (isBothHandsRight)
            {
                return Mathf.Max(left_hand_input_.getHorizaontalValue, right_hand_input_.getHorizaontalValue);
            }
            else if (isBothHandsLeft)
            {
                return Mathf.Min(left_hand_input_.getHorizaontalValue, right_hand_input_.getHorizaontalValue);
            }
            else
            {
                return 0.0f;
            }
        }
    }
    #endregion

    #region rotate property

    public float getRotateValue
    {
        get
        {

            if (!leap_contoller_.IsConnected) return Input.GetAxis("Rotate");
            if (NullCheck()) return 0.0f;

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
    }

    #endregion

    #region jump property

    public bool isInputJump
    {
        get
        {

            if (!leap_contoller_.IsConnected) return Input.GetKeyDown(KeyCode.Space);
            if (NullCheck()) return false;
            if (!(right_hand_input_.isRight && left_hand_input_.isLeft)) return false;

            if (!(right_hand_input_.getHorizaontalValue > 0.3f &&
                left_hand_input_.getHorizaontalValue < -0.3f)) return false;
            return true;
        }
    }

    public float getJumpValue
    {
        get
        {
            return Input.GetAxis("Jump");
        }
    }

>>>>>>> 56add7e2d97cdc9537aedeab3d31493295123132
    #endregion

    #region fire property
<<<<<<< HEAD

    #region right

    public bool isInputRightAttack
    {
        get
        {
            return Input.GetMouseButton(1);
        }
    }

=======

    #region right

    public bool isInputRightAttack
    {
        get
        {
            if (!leap_contoller_.IsConnected) return Input.GetMouseButton(1);
            if (right_hand_input_ == null) return false;
            return right_hand_input_.isGrabed;
        }
    }

    #endregion

    #region left

    public bool isInputLeftAttack
    {
        get
        {
            if (!leap_contoller_.IsConnected) return Input.GetMouseButton(0);
            if (left_hand_input_ == null) return false;
            return left_hand_input_.isGrabed;
        }
    }

    #endregion

>>>>>>> 56add7e2d97cdc9537aedeab3d31493295123132
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
>>>>>>> 78d4c541c4e330f3c961aff46eadae90b1a125e2
    }

    #endregion

<<<<<<< HEAD
}
=======

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

    bool NullCheck()
    {
        return right_hand_input_ == null || left_hand_input_ == null;
    }

    bool isBothHandsFront
    {
        get
        {
            if (NullCheck()) return false;
            return left_hand_input_.isFront && right_hand_input_.isFront;
        }
    }

    bool isBothHandsBack
    {
        get
        {
            if (NullCheck()) return false;
            return left_hand_input_.isBack && right_hand_input_.isBack;
        }
    }

    bool isBothHandsRight
    {
        get
        {
            if (NullCheck()) return false;
            return left_hand_input_.isRight && right_hand_input_.isRight;
        }
    }

    bool isBothHandsLeft
    {
        get
        {
            if (NullCheck()) return false;
            return left_hand_input_.isLeft && right_hand_input_.isLeft;
        }
    }

    Controller leap_contoller_ = null;
    LeftHandInput left_hand_input_ = null;
    RightHandInput right_hand_input_ = null;
}
>>>>>>> 56add7e2d97cdc9537aedeab3d31493295123132
