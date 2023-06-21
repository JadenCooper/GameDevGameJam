using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIData : MonoBehaviour
{
   public List<Transform> targets = null; // List of targets
   public Collider2D[] obstacles = null; // List of obstacles that the AI want to avoid 
   public Transform currentTarget; // The current target that the AI is chasing

   public int GetTargetsCount() => targets == null ? 0 : targets.Count; // Returns the number of targets in the list
}
