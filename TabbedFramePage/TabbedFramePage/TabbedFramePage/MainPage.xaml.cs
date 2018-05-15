using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace TabbedFramePage
{
	public partial class MainPage : ContentPage
	{
        // The outline color for each tab
        private Color OutlineColor = Color.LimeGreen;

		public MainPage()
		{
			InitializeComponent();
            InitializeElements();
		}

        private void InitializeElements()
        {
            
        }

        private void TabX_Frame_Tapped(object sender, EventArgs e)
        {
            /*
             *  To Highlight A Tab
             *  ------------------
             *  - Turn all other tab frame border colors to transparent
             *  - Turn all other tab background colors to transparent
             *  - Turn selected tabs border color to desired color
             *  - Turn selected tabs background color to desired color
             *  
             *  SelectedTab_Frame_Outline.BackgroundColor = Color.DesiredColor
             *  SelectedTab_Frame_Outline.BorderColor = Color.DesiredColor
             *  
             *  OtherTab_Frame_Outline.BackgroundColor = Color.Transparent
             *  OtherTab_Frame_Outline.BorderColor = Color.Transparent
             *  
             *  ...
             */
        }

        private void Tab_Frame_Tapped(object sender, EventArgs e)
        {
            Frame SelectedFrame = sender as Frame;
            SelectedFrame.BackgroundColor = OutlineColor;
            SelectedFrame.BorderColor = OutlineColor;
            
            foreach(Frame item in TabHolder.Children.Where(x => x.GetType() == typeof(Frame)))
            {
                if(item.ClassId == "Outline" && item != SelectedFrame)
                {
                    item.BackgroundColor = Color.Transparent;
                    item.BorderColor = Color.Transparent;
                }
            }   
        }
    }
}
