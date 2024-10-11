using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviourScript : MonoBehaviour
{   
    public float ForwardMovementSpeed = 0;
    public float SideMovementSpeed = 0;
    public float VerticalMovementSpeed = 0;
    public float SpeedDelta = 0.02f;
    public float MaxSpeed = 5f;

    public float YawRotationSpeed = 0;
    public float PitchRotationSpeed = 0;
    public float RollRotationSpeed = 0;
    public float RotationSpeedDelta = 0.1f;
    public float MaxRotationSpeed = 20.0f;

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

        ForwardMovementSpeed = Mathf.Clamp(ForwardMovementSpeed, -MaxSpeed, MaxSpeed);
        SideMovementSpeed = Mathf.Clamp(SideMovementSpeed, -MaxSpeed, MaxSpeed);
        VerticalMovementSpeed = Mathf.Clamp(VerticalMovementSpeed, -MaxSpeed, MaxSpeed);

        YawRotationSpeed = Mathf.Clamp(YawRotationSpeed, -MaxRotationSpeed, MaxRotationSpeed);
        PitchRotationSpeed = Mathf.Clamp(PitchRotationSpeed, -MaxRotationSpeed, MaxRotationSpeed);
        RollRotationSpeed = Mathf.Clamp(RollRotationSpeed, -MaxRotationSpeed, MaxRotationSpeed);

        float time = Time.deltaTime; 
        
        transform.Translate(transform.forward * ForwardMovementSpeed * time, Space.World);
        transform.Translate(transform.right * SideMovementSpeed * time, Space.World);
        transform.Translate(transform.up * VerticalMovementSpeed * time, Space.World);

        transform.Rotate(transform.up, YawRotationSpeed * time, Space.Self);
        transform.Rotate(transform.right, PitchRotationSpeed * time, Space.Self);
        transform.Rotate(transform.forward, RollRotationSpeed * time, Space.Self);

    }
}