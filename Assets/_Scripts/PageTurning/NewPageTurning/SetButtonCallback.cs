using ThuisBijMuis.Games.PageSliding;
using UnityEngine;
using UnityEngine.UI;

namespace ThuisBijMuis.Games.PageSliding
{
    public class SetButtonCallback : MonoBehaviour
    {
        [SerializeField]
        private bool isNextButton;

        private void Awake()
        {
            if (isNextButton) GetComponent<Button>().onClick.AddListener(FindObjectOfType<PageSlider>().NextPageButton);
            else GetComponent<Button>().onClick.AddListener(FindObjectOfType<PageSlider>().PreviousPageButton);
        }
    } 
}
