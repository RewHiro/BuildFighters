using UnityEngine;
using System.Collections;

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
>>>>>>> 78d4c541c4e330f3c961aff46eadae90b1a125e2
    }

    #endregion

}
