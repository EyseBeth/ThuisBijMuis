using UnityEngine;

namespace ThuisBijMuis.Games.Interactables.CustomBehaviours
{
    public class ObjectShake : MonoBehaviour, IClickable
    {
        private Vector3 originPosition;
        private Quaternion originRotation;

        private float shakeDecay = 0.002f;
        private float shakeIntensity = .3f;
        private float tempShakeIntensity = 0;

        private void Update()
        {
            if (tempShakeIntensity <= 0) return;

            transform.position = originPosition + Random.insideUnitSphere * tempShakeIntensity;
            transform.rotation = new Quaternion(originRotation.x + Random.Range(-tempShakeIntensity, tempShakeIntensity) * .2f,
                                                originRotation.y + Random.Range(-tempShakeIntensity, tempShakeIntensity) * .2f,
                                                originRotation.z + Random.Range(-tempShakeIntensity, tempShakeIntensity) * .2f,
                                                originRotation.w + Random.Range(-tempShakeIntensity, tempShakeIntensity) * .2f);
            tempShakeIntensity -= shakeDecay;
        }

        public void ExecuteCustomBehaviour()
        {
            originPosition = transform.position;
            originRotation = transform.rotation;
            tempShakeIntensity = shakeIntensity;
        }
    }
}
