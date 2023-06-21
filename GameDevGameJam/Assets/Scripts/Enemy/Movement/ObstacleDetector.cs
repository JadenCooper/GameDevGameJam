using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleDetector : Detector
{
    [SerializeField]
    private float detectionRadius = 2f;

    [SerializeField]
    private LayerMask obstacleLayerMask;

    // Debugging purposes. It shows the detection radius in the editor
    [SerializeField]
    private bool showGizmos = true;

    Collider2D[] colliders;

    public override void Detect(AIData aiData)
    {
        // Get all the colliders that are within the detection radius and assgins them to the obstacles list in the AIData script
        colliders = Physics2D.OverlapCircleAll(transform.position, detectionRadius, obstacleLayerMask);
        aiData.obstacles = colliders;
    }

    // Draw the detection radius in the editor
    private void OnDrawGizmosSelected()
    {
        if(!showGizmos)
        {
            return;
        }

        if(Application.isPlaying && colliders != null)
        {
            Gizmos.color = Color.red;
            foreach(Collider2D collider in colliders)
            {
                Gizmos.DrawSphere(collider.transform.position, 0.2f);
            }
        } 
    }
}
