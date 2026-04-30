using UnityEngine;
using UnityEngine.UI;

namespace Project.Code.UI.Menu.BaseMenu
{
    public abstract class MenuBehaviour : MonoBehaviour
    {
        [SerializeField] protected Button _openButton;
        [SerializeField] protected Button _closeButton;
        [SerializeField] protected CanvasGroup _canvasGroup;
        
        protected CanvasGroupMenu _menu;

        private void Awake()
        {
            _menu = CreateMenu();
        }

        private void OnEnable()
        {
            _openButton.onClick.AddListener(_menu.Open);
            _closeButton.onClick.AddListener(_menu.Close);
        }

        private void OnDisable()
        {
            _openButton.onClick.RemoveListener(_menu.Open);
            _closeButton.onClick.RemoveListener(_menu.Close);
        }

        protected abstract CanvasGroupMenu CreateMenu();
    }
}