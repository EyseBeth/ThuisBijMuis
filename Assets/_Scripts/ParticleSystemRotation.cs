using ThuisBijMuis.Games.Interactables;
using UnityEngine;

namespace ThuisBijMuis.Games
{
#pragma warning disable 0649
    public class ParticleSystemRotation : MonoBehaviour, IInteractable
    {
        [SerializeField] private ParticleSystem particles;
        [SerializeField] private Axis axisToRotate;
        [SerializeField] private float maxRotation;
        [SerializeField] private float rotateStrength;

        private bool isDragging;
        private float lastPointerPosX;
        private float currentRotation;
        private ParticleSystem.ShapeModule shape;

        private void Start() => shape = particles.shape;

        // There is probably a more elegant way of doing this.
        private void FixedUpdate()
        {
            if (!isDragging)
                return;

            if (Input.mousePosition.x > lastPointerPosX && currentRotation < maxRotation)
            {
                // Check which axis we want to rotate on.
                switch (axisToRotate)
                {
                    // Add the rotation on the desired axis and take the minimum of the 2 numbers.
                    // This is so when we go over the max rotation we just take maxRotation.
                    case Axis.X:
                        shape.rotation = new Vector3(Mathf.Min(shape.rotation.x + (Time.fixedDeltaTime * rotateStrength), maxRotation),
                                                     shape.rotation.y,
                                                     shape.rotation.z);
                        break;
                    case Axis.Y:
                        shape.rotation = new Vector3(shape.rotation.x,
                                                     Mathf.Min(shape.rotation.y + (Time.fixedDeltaTime * rotateStrength), maxRotation),
                                                     shape.rotation.z);
                        break;
                    case Axis.Z:
                        shape.rotation = new Vector3(shape.rotation.x,
                                                     shape.rotation.y,
                                                     Mathf.Min(shape.rotation.z + (Time.fixedDeltaTime * rotateStrength), maxRotation));
                        break;
                }

                // We need to keep track of our current rotation.
                // Because of the option to rotate on 3 axis we can't directly take one.
                currentRotation = Mathf.Min(currentRotation + (Time.fixedDeltaTime * rotateStrength), maxRotation);
            }
            else if (Input.mousePosition.x < lastPointerPosX && currentRotation > -maxRotation)
            {
                // Same as above but reversed. Here we use Mathf.Max instead of Min because it's reversed.
                switch (axisToRotate)
                {
                    case Axis.X:
                        shape.rotation = new Vector3(Mathf.Max(shape.rotation.x + -(Time.fixedDeltaTime * rotateStrength), -maxRotation),
                                                     shape.rotation.y,
                                                     shape.rotation.z);
                        break;
                    case Axis.Y:
                        shape.rotation = new Vector3(shape.rotation.x,
                                                     Mathf.Max(shape.rotation.y + -(Time.fixedDeltaTime * rotateStrength), -maxRotation),
                                                     shape.rotation.z);
                        break;
                    case Axis.Z:
                        shape.rotation = new Vector3(shape.rotation.x,
                                                     shape.rotation.y,
                                                     Mathf.Max(shape.rotation.z + -(Time.fixedDeltaTime * rotateStrength), -maxRotation));
                        break;
                }

                currentRotation = Mathf.Max(currentRotation - (Time.fixedDeltaTime * rotateStrength), -maxRotation);
            }

            // Save the pointer position so we can compare next frame.
            lastPointerPosX = Input.mousePosition.x;
        }

        public void ActivateInteractable()
        {
            lastPointerPosX = Input.mousePosition.x;
            isDragging = true;
        }

        // Replace with IReleaseable.
        private void OnMouseUp()
        {
            isDragging = false;
        }
    }

    public enum Axis
    {
        X,
        Y,
        Z
    }
}
