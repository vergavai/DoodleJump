using UnityEngine;

namespace Project.Code.UI.Menu.BaseMenu
{
    public abstract class Menu
    {
        protected CanvasGroup _canvasGroup;

        public Menu(CanvasGroup canvasGroup)
        {
            _canvasGroup = canvasGroup;
        }

        public virtual void Open()
        {
            _canvasGroup.alpha = 1;
            _canvasGroup.interactable = true;
        }

        public virtual void Close()
        {
            _canvasGroup.alpha = 0;
            _canvasGroup.interactable = false;
        }
    }
}