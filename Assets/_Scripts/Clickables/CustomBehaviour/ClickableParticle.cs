using UnityEngine;

namespace ThuisBijMuis.Games.Interactables.CustomBehaviours
{
#pragma warning disable 0649
    public class ClickableParticle : MonoBehaviour, IClickable
    {
        [SerializeField] private ParticleSystem ps;

        public void ExecuteCustomBehaviour() => ps.Play();
    }
}
