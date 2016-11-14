using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using MenuItem = ExternalLogin.Models.MenuModel;

namespace ExternalLogin.Pages.Master
{
    public class MenuListView : ListView
    {
        public MenuListView()
        {
            List<MenuItem> data = new MenuListData();

            ItemsSource = data;
            VerticalOptions = LayoutOptions.FillAndExpand;
            BackgroundColor = Color.Transparent;
            SeparatorColor = Color.Gray;

            var cell = new DataTemplate(typeof(MenuCell));
            cell.SetBinding(MenuCell.TextProperty, "Title");

            ItemTemplate = cell;
        }
    }
    public class MenuCell : ImageCell
    {
        public MenuCell()
            : base()
        {
            this.TextColor = Color.Black;
        }
    }
    public class MenuListData : List<MenuItem>
    {
        public MenuListData()
        {
            this.Add(new MenuItem()
            {
                Title = "Logout",
                IconSource = "LogOut.png",
            });
        }
    }
}