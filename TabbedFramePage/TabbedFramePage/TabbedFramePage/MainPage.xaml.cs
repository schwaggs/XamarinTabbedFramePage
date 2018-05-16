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
        private TabWatcher Selected_Tab { get; set; }

		public MainPage()
		{
			InitializeComponent();
            InitializeElements();
		}

        private void InitializeElements()
        {
            Selected_Tab = new TabWatcher(TabType.TAB1);
            Selected_Tab.Element_Changed_Event += Selected_Tab_Changed;
        }

        private void Selected_Tab_Changed(object sender, EventArgs e)
        {
            DisplayAlert("Tab Changed", Selected_Tab.Element.ToString() + " selected.", "Ok");
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

            if(SelectedFrame == Tab1_Frame_Outline)
            {
                Selected_Tab.Element = TabType.TAB1;
            }

            else if(SelectedFrame == Tab2_Frame_Outline)
            {
                Selected_Tab.Element = TabType.TAB2;
            }
        }
    }

    #region Tab Watcher and Type Enumeration

    public enum TabType
    {
        TAB1,
        TAB2
    }

    public class TabWatcher
    {
        private TabType _Element { get; set; }
        private object Lock { get; set; }

        public TabWatcher(TabType Default_Element)
        {
            _Element = Default_Element;
            Lock = new object();
        }

        public TabType Element
        {
            get
            {
                return _Element;
            }

            set
            {
                lock (Lock)
                {
                    _Element = value;
                    OnElementChanged(EventArgs.Empty);
                }
            }
        }

        protected virtual void OnElementChanged(EventArgs e)
        {
            EventHandler handler = Element_Changed_Event;
            handler(this, e);
        }

        public event EventHandler Element_Changed_Event;
    }

    #endregion TabEventDelegate
}
