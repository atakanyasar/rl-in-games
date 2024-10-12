using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControllerScript : MonoBehaviour
{   
    public float AirFriction = 0.002f;

    public float ForwardMovementSpeed = 0;
    public float SideMovementSpeed = 0;
    public float VerticalMovementSpeed = 0;
    public float SpeedDelta = 0.02f;
    public float MaxSpeed = 5f;

    public float YawRotationSpeed = 0;
    public float PitchRotationSpeed = 0;
    public float RollRotationSpeed = 0;
    public float RotationSpeedDelta = 0.5f;
    public float MaxRotationSpeed = 90.0f;

    public Rigidbody rb;

    private Dictionary<string, KeyCode> movementKeyBindings = new Dictionary<string, KeyCode>()
    {
        { "FORWARD", KeyCode.W },
        { "BACKWARD", KeyCode.S },
        { "LEFT", KeyCode.A },
        { "RIGHT", KeyCode.D },
        { "UP", KeyCode.Space },
        { "DOWN", KeyCode.LeftShift },
        { "YAW_LEFT", KeyCode.Q },
        { "YAW_RIGHT", KeyCode.E },
        { "PITCH_UP", KeyCode.R },
        { "PITCH_DOWN", KeyCode.F },
        { "ROLL_LEFT", KeyCode.Z },
        { "ROLL_RIGHT", KeyCode.C }
    };

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        foreach (KeyValuePair<string, KeyCode> entry in movementKeyBindings)
        {
            if (Input.GetKey(entry.Value))
            {
                switch (entry.Key)
                {
                    case "FORWARD":
                        ForwardMovementSpeed += SpeedDelta;
                        break;
                    case "BACKWARD":
                        ForwardMovementSpeed -= SpeedDelta;
                        break;
                    case "LEFT":
                        SideMovementSpeed -= SpeedDelta;
                        break;
                    case "RIGHT":
                        SideMovementSpeed += SpeedDelta;
                        break;
                    case "UP":
                        VerticalMovementSpeed += SpeedDelta;
                        break;
                    case "DOWN":
                        VerticalMovementSpeed -= SpeedDelta;
                        break;
                    case "YAW_LEFT":
                        YawRotationSpeed -= RotationSpeedDelta;
                        break;
                    case "YAW_RIGHT":
                        YawRotationSpeed += RotationSpeedDelta;
                        break;
                    case "PITCH_UP":
                        PitchRotationSpeed -= RotationSpeedDelta;
                        break;
                    case "PITCH_DOWN":
                        PitchRotationSpeed += RotationSpeedDelta;
                        break;
                    case "ROLL_LEFT":
                        RollRotationSpeed += RotationSpeedDelta;
                        break;
                    case "ROLL_RIGHT":
                        RollRotationSpeed -= RotationSpeedDelta;
                        break;
                        
                }
            }
        }

        ForwardMovementSpeed = Mathf.Lerp(ForwardMovementSpeed, 0, AirFriction);
        SideMovementSpeed = Mathf.Lerp(SideMovementSpeed, 0, AirFriction);
        VerticalMovementSpeed = Mathf.Lerp(VerticalMovementSpeed, 0, AirFriction);
        YawRotationSpeed = Mathf.Lerp(YawRotationSpeed, 0, AirFriction);
        PitchRotationSpeed = Mathf.Lerp(PitchRotationSpeed, 0, AirFriction);
        RollRotationSpeed = Mathf.Lerp(RollRotationSpeed, 0, AirFriction);


        ForwardMovementSpeed = Mathf.Clamp(ForwardMovementSpeed, -MaxSpeed, MaxSpeed);
        SideMovementSpeed = Mathf.Clamp(SideMovementSpeed, -MaxSpeed, MaxSpeed);
        VerticalMovementSpeed = Mathf.Clamp(VerticalMovementSpeed, -MaxSpeed, MaxSpeed);

        YawRotationSpeed = Mathf.Clamp(YawRotationSpeed, -MaxRotationSpeed, MaxRotationSpeed);
        PitchRotationSpeed = Mathf.Clamp(PitchRotationSpeed, -MaxRotationSpeed, MaxRotationSpeed);
        RollRotationSpeed = Mathf.Clamp(RollRotationSpeed, -MaxRotationSpeed, MaxRotationSpeed);

        rb.velocity = transform.forward * ForwardMovementSpeed + transform.right * SideMovementSpeed + transform.up * VerticalMovementSpeed;
        rb.angularVelocity = transform.localRotation * new Vector3(PitchRotationSpeed, YawRotationSpeed, RollRotationSpeed) * Mathf.Deg2Rad;

    }
}
