using UnityEngine;

namespace Project.Code.UI.Menu.PauseMenu
{
    public class PauseMenu : BaseMenu.CanvasGroupMenu
    {
        public PauseMenu(CanvasGroup canvasGroup) : base(canvasGroup)
        {
        }

        public override void Open()
        {
            base.Open();
            Time.timeScale = 0;
        }

        public override void Close()
        {
            base.Close();
            Time.timeScale = 1;
        }
    }
}
