using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyAI : MonoBehaviour
{
    [SerializeField]
    private List<SteeringBehaviour> steeringBehaviours;

    [SerializeField]
    private List<Detector> detectors;

    [SerializeField]
    private AIData aiData;

    [SerializeField]
    private ContextSolver contextSolver;

    [SerializeField]
    private float detectionDelay = 0.05f, aiUpdateDelay = 0.05f;

    [SerializeField]
    private float attackDelay = 1f, attackDistance = 1f;

    [SerializeField]
    private Vector2 movementInput;

    //Inputs sent from the Enemy AI to the Enemy controller
    public UnityEvent OnAttack;
    public UnityEvent<Vector2> OnMovementInput;

    bool following = false;

    private void Start()
    {
        // Detect the targets and obstacles
        InvokeRepeating("PerformDetection", 0f, detectionDelay);
    }

    private void PerformDetection()
    {
        foreach (Detector detector in detectors)
        {
            detector.Detect(aiData);
        }

        float[] danger = new float[8];
        float[] interest = new float[8];

        // Loop through each behaviour
        foreach (SteeringBehaviour behaviour in steeringBehaviours)
        {
            (danger, interest) = behaviour.GetSteering(danger, interest, aiData);
        }
    }

    private void Update()
    {
        // Enemy AI movement based on target availability
        if(aiData.currentTarget != null)
        {
            // Looking at the target
            Vector2 directionToTarget = aiData.currentTarget.position - transform.position;
            // transform.up = directionToTarget;
            if (following == false)
            {
                following = true;
                StartCoroutine(ChaseAndAttack());
            }
        }
        else if (aiData.GetTargetsCount() > 0)
        {
            // Target acquisition logic
            aiData.currentTarget = aiData.targets[0];
        }

        OnMovementInput?.Invoke(movementInput);
    }

    private IEnumerator ChaseAndAttack()
    {
        if(aiData.currentTarget == null)
        {
            Debug.Log("No target to chase");
            movementInput = Vector2.zero;
            following = false;
            yield return null;
        }
        else
        {
            float distance = Vector2.Distance(aiData.currentTarget.position, transform.position);

            if(distance <= attackDistance)
            {
                movementInput = Vector2.zero;
                CheckSide();
                // Attack the player
                Debug.Log("Attack");
                OnAttack?.Invoke();

                yield return new WaitForSeconds(attackDelay);
                StartCoroutine(ChaseAndAttack());
            }
            else
            {
                movementInput = contextSolver.GetDirectionToMove(steeringBehaviours, aiData);
                CheckSide();
                yield return new WaitForSeconds(aiUpdateDelay);
                StartCoroutine(ChaseAndAttack());
            }
        }
    }

    private void CheckSide()
    {
        if(aiData.currentTarget != null)
        {
            Vector2 movementVector = (aiData.currentTarget.position - transform.position).normalized;
            
            if (movementVector.x < 0)
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
            else
            {
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }
}
