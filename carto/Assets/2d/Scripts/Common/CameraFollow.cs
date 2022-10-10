using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    //let camera follow target
    public class CameraFollow : MonoBehaviour
    {
        public Transform target;

        public float lerpSpeed = 1.0f;
        public float height = -10.0f;

        private Vector3 offset;
        private Vector3 targetPos;

        private void Start()
        {
            if (target == null) return;

            // Camera Initial Position
            transform.position = target.position;
            offset = new Vector3(0.0f, 0.0f, height);
        }

        private void Update()
        {
            if (target == null) return;

            targetPos = target.position + offset;
            transform.position = Vector3.Lerp(transform.position, targetPos, lerpSpeed * Time.deltaTime);
        }

    }
}
