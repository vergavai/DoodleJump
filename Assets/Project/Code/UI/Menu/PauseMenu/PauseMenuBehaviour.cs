using Project.Code.UI.Menu.BaseMenu;

namespace Project.Code.UI.Menu.PauseMenu
{
    public class PauseMenuBehaviour : MenuBehaviour
    {
        protected override BaseMenu.CanvasGroupMenu CreateMenu()
        {
            return new PauseMenu(_canvasGroup);
        }
    }
}