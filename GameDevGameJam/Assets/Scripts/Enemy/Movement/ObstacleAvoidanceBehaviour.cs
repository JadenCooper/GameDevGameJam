using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleAvoidanceBehaviour : SteeringBehaviour
{
   [SerializeField]
   private float radius = 2f, enemyColliderSize = 0.6f;

    [SerializeField]
    private bool showGizmos = true;

    // Gizmo parameters
    float[] dangersResultsTemp = null;

    public override (float[] danger, float[] interest) GetSteering(float[] danger, float[] interest, AIData aiData)
    {
        foreach(Collider2D obstacleCollider in aiData.obstacles)
        {
            // Calculate the distance between the obstacle and the enemy
            Vector2 directionToObstacle = obstacleCollider.ClosestPoint(transform.position) - (Vector2)transform.position;
            float distanceToObstacle = directionToObstacle.magnitude;

            // Calculate weight based on the distance between the obstacle and the enemy
            float weight = distanceToObstacle <= enemyColliderSize ? 1f : (radius - distanceToObstacle) / radius;

            Vector2 directionToObstacleNormalised = directionToObstacle.normalized;

            // Add obstacle parameters to the danger array
            for(int i =0; i < Directions.eightDirections.Count; i++)
            {
                // Calculate the dot product between the direction to the obstacle and the direction of the current direction
                float result = Vector2.Dot(directionToObstacleNormalised, Directions.eightDirections[i]);
                float valueToPutIn = result * weight;

                // override the value if it is greater than the current value
                if(valueToPutIn > danger[i])
                {
                    danger[i] = valueToPutIn;
                }
            }
        }
        dangersResultsTemp = danger;
        return (danger, interest);
    }
    private void OnDrawGizmos()
    {
        if (showGizmos == false)
        {
            return;
        }

        if (Application.isPlaying && dangersResultsTemp != null)
        {
            if (dangersResultsTemp != null)
            {
                Gizmos.color = Color.red;
                for (int i = 0; i < dangersResultsTemp.Length; i++)
                {
                    Gizmos.DrawRay(transform.position, Directions.eightDirections[i] * dangersResultsTemp[i] * 2);
                }
            }
        }
    }
}
