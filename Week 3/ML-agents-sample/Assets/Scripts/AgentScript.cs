using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.MLAgents;
using Unity.MLAgents.Sensors;
using Unity.MLAgents.Actuators;

public class AgentScript : Agent
{

    public GameObject target;
    
    private Rigidbody agentRb;
    private float previousDistance = float.MaxValue;

    public override void Initialize()
    {
        agentRb = GetComponent<Rigidbody>();
    }

    public override void OnEpisodeBegin()
    {
        // Reset the target local position
        target.transform.localPosition = new Vector3(Random.Range(-4.5f, 4.5f), 0.5f, Random.Range(-4.5f, 4.5f));
        target.GetComponent<Rigidbody>().velocity = Vector3.zero;
        target.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        
        // Reset the agent position
        transform.localPosition = new Vector3(Random.Range(-4.5f, 4.5f), 0.5f, Random.Range(-4.5f, 4.5f));
        transform.localRotation = Quaternion.Euler(new Vector3(0, Random.Range(0, 360)));

        agentRb.velocity = Vector3.zero;
        agentRb.angularVelocity = Vector3.zero;

        previousDistance = Vector3.Distance(this.transform.localPosition, target.transform.localPosition);

    }

    public override void CollectObservations(VectorSensor sensor)
    {
        // Target and Agent positions
        sensor.AddObservation(target.transform.localPosition);
        sensor.AddObservation(this.transform.localPosition);
        sensor.AddObservation(this.transform.localRotation);
        
        // Agent velocity
        sensor.AddObservation(agentRb.velocity.x);
        sensor.AddObservation(agentRb.velocity.z);
        sensor.AddObservation(agentRb.angularVelocity);
    }

    public void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("target"))
        {
            SetReward(1.0f);
            EndEpisode();
        }
        else if (collision.gameObject.CompareTag("wall"))
        {
            SetReward(-1.0f);
            EndEpisode();
        }
    }

    public override void OnActionReceived(ActionBuffers actions)
    {
        // Actions, size = 2
        Vector3 controlSignal = Vector3.zero;
        controlSignal.x = actions.ContinuousActions[0];
        controlSignal.z = actions.ContinuousActions[1];
        agentRb.AddForce(controlSignal * 10);

        // Rewards
        float distanceToTarget = Vector3.Distance(this.transform.localPosition, target.transform.localPosition);
        AddReward((previousDistance - distanceToTarget) * 0.01f);
        // Debug.Log("Reward: " + (previousDistance - distanceToTarget) * 0.01f);
        previousDistance = distanceToTarget;
        

    }

    public override void Heuristic(in ActionBuffers actionsOut)
    {
        var continuousActionsOut = actionsOut.ContinuousActions;
        continuousActionsOut[0] = Input.GetAxis("Horizontal");
        continuousActionsOut[1] = Input.GetAxis("Vertical");
    }


}
