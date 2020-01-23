namespace ThuisBijMuis.Games.Interactables.CustomBehaviours
{
#pragma warning disable 0649
    /// <summary>
    /// Specifically for page 9, checks if there's been an ONTrigger enter before enabling sprite change on click.
    /// </summary>
    public class ChangeFlower : ChangeObject, IClickable
    {
        public override void ExecuteCustomBehaviour()
        {
            // Checks if the objects have already been switched, if it hasnt, it does so.
            if (objectsChanged == false)
            {
                objectsChanged = true;
                ChangeThem(false, true);
            }
        }
    }
}
