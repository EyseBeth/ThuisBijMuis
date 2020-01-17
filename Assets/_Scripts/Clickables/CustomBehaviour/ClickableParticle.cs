using UnityEngine;

namespace ThuisBijMuis.Games.Interactables.CustomBehaviours
{
    public class ClickableParticle : MonoBehaviour, IClickable
    {
        [SerializeField] private ParticleSystem ps;

        public void ExecuteCustomBehaviour() => ps.Play();
    }
}
