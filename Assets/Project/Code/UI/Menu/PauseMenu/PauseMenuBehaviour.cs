using Project.Code.UI.Menu.BaseMenu;
using UnityEngine;

namespace Project.Code.UI.Menu.PauseMenu
{
    public class PauseMenuBehaviour : MenuBehaviour
    {
        protected override BaseMenu.Menu CreateMenu()
        {
            return new PauseMenu(_canvasGroup);
        }
    }
}