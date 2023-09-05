using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Platformer.Mechanics
{
    public class PlayerDetection : MonoBehaviour
    {

        [field: SerializeField]
        public bool playerDetected { get; private set;}
        public Vector2 directionToTarget => target.transform.position - detectorOrigin.position;

        [Header("OverlapBox parameters")]
        [SerializeField]
        private Transform detectorOrigin;
        public Vector2 detectorSize = Vector2.one;
        public Vector2 detectorOriginOffset = Vector2.zero;

        public float detectionDelay = 0.3f;

        public LayerMask detectorLayerMask;
        public string enemiesTag;

        [Header("Gizmo Parameters")]
        public Color gizmoIdleColor = Color.green;
        public Color gizmoDetectedColor = Color.red;
        public bool showGizmo = true;

        private GameObject target;

        // Start is called before the first frame update
        void Start()
        {
            StartCoroutine(DetectionCoroutine());
        }

        IEnumerator DetectionCoroutine(){
            yield return new WaitForSeconds(detectionDelay);
            PerformDetection();
            StartCoroutine(DetectionCoroutine());
        }

        public void PerformDetection()
        {
            Collider2D collider = Physics2D.OverlapBox(
                (Vector2)detectorOrigin.position + detectorOriginOffset, detectorSize, 0, detectorLayerMask);
            if(collider != null){
                target = collider.gameObject;
                playerDetected = true;
                GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemiesTag);

                foreach (GameObject enemy in enemies){
                    enemy.GetComponent<Inimigo>().active = true;
                }
            }
            else
            {
                playerDetected = false;
                target = null;
            }
        }

        private void OnDrawGizmos()
        {
            if(showGizmo && detectorOrigin != null)
            {
                Gizmos.color = gizmoIdleColor;
                if(playerDetected) 
                    Gizmos.color = gizmoDetectedColor;
                Gizmos.DrawCube((Vector2)detectorOrigin.position + detectorOriginOffset, detectorSize);
            }
        }
    }
}
