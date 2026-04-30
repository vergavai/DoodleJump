using Project.Code.UI.Menu.BaseMenu;

namespace Project.Code.UI.Menu.SettingsMenu
{
    public class SettingsMenuBehaviour : MenuBehaviour
    {
        protected override BaseMenu.CanvasGroupMenu CreateMenu()
        {
            return new SettingsMenu(_canvasGroup);
        }
    }
}
