using Project.Code.UI.Menu.BaseMenu;

namespace Project.Code.UI.Menu.SettingsMenu
{
    public class SettingsMenuBehaviour : MenuBehaviour
    {
        protected override BaseMenu.Menu CreateMenu()
        {
            return new SettingsMenu(_canvasGroup);
        }
    }
}
