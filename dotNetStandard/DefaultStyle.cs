using System;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace Atomus.Page.Style
{
    public class DefaultStyle : IAction
    {
        private AtomusPageEventHandler beforeActionEventHandler;
        private AtomusPageEventHandler afterActionEventHandler;

        #region Init
        public DefaultStyle()
        {
            Config.Client.SetAttribute("BackgroundColor", this.GetAttribute("BackgroundColor"));
            Config.Client.SetAttribute("BarBackgroundColor", this.GetAttribute("BarBackgroundColor"));
        }
        #endregion

        #region IO
        object IAction.ControlAction(ICore sender, AtomusPageArgs e)
        {
            try
            {
                this.beforeActionEventHandler?.Invoke(this, e);

                switch (e.Action)
                {
                    case "CreateStyle":
                        return this.CreateStyle();
                }

                return true;
            }
            finally
            {
                this.afterActionEventHandler?.Invoke(this, e);
            }
        }
        #endregion


        #region Event
        event AtomusPageEventHandler IAction.BeforeActionEventHandler
        {
            add
            {
                this.beforeActionEventHandler += value;
            }
            remove
            {
                this.beforeActionEventHandler -= value;
            }
        }
        event AtomusPageEventHandler IAction.AfterActionEventHandler
        {
            add
            {
                this.afterActionEventHandler += value;
            }
            remove
            {
                this.afterActionEventHandler -= value;
            }
        }
        #endregion

        #region Etc
        public ResourceDictionary CreateStyle()
        {
            ResourceDictionary resource;
            Color backgroundColor;
            Color textColor;
            Color placeholderColor;

            try
            {
                backgroundColor = ((string)Config.Client.GetAttribute("BackgroundColor")).ToColor();
                textColor = this.GetAttributeColor("Xamarin.Forms.Style.TextColor");
                placeholderColor = this.GetAttributeColor("Xamarin.Forms.Style.PlaceholderColor");

                resource = new ResourceDictionary();

                resource.Add(new Xamarin.Forms.Style(typeof(MasterDetailPage))
                {
                    Setters = { new Setter { Property = VisualElement.BackgroundColorProperty, Value = backgroundColor } }
                });

                resource.Add(new Xamarin.Forms.Style(typeof(NavigationPage))
                {
                    Setters = { new Setter { Property = VisualElement.BackgroundColorProperty, Value = backgroundColor } }
                });

                resource.Add(new Xamarin.Forms.Style(typeof(ContentPage))
                {
                    Setters = { new Setter { Property = VisualElement.BackgroundColorProperty, Value = backgroundColor } }
                });

                resource.Add(new Xamarin.Forms.Style(typeof(ScrollView))
                {
                    Setters = { new Setter { Property = View.MarginProperty, Value = this.GetAttributeInt("Xamarin.Forms.Style.ScrollView.MarginProperty") }
                                , new Setter { Property = ScrollView.PaddingProperty, Value = this.GetAttributeInt("Xamarin.Forms.Style.ScrollView.PaddingProperty") } }
                });

                resource.Add(new Xamarin.Forms.Style(typeof(ListView))
                {
                    Setters = { new Setter { Property = ListView.MarginProperty, Value = this.GetAttributeInt("Xamarin.Forms.Style.ListView.MarginProperty") }
                                , new Setter { Property = ListView.SeparatorColorProperty, Value = this.GetAttributeColor("Xamarin.Forms.Style.ListView.SeparatorColorProperty") }
                                , new Setter { Property = ListView.HasUnevenRowsProperty, Value = this.GetAttributeBool("Xamarin.Forms.Style.ListView.HasUnevenRowsProperty") } }
                });


                resource.Add(new Xamarin.Forms.Style(typeof(Label))
                {
                    Setters = { new Setter { Property = Label.MarginProperty, Value = this.GetAttributeInt("Xamarin.Forms.Style.Label.MarginProperty") }
                                , new Setter { Property = Label.TextColorProperty, Value = textColor } }
                });

                resource.Add(new Xamarin.Forms.Style(typeof(Entry))
                {
                    Setters = { new Setter { Property = Entry.MarginProperty, Value =  this.GetAttributeInt("Xamarin.Forms.Style.Entry.MarginProperty") }
                                , new Setter { Property = Entry.TextColorProperty, Value = textColor }
                                , new Setter { Property = Entry.PlaceholderColorProperty, Value = placeholderColor } }
                });

                resource.Add(new Xamarin.Forms.Style(typeof(Editor))
                {
                    Setters = { new Setter { Property = Editor.MarginProperty, Value =  this.GetAttributeInt("Xamarin.Forms.Style.Editor.MarginProperty") }
                                , new Setter { Property = Editor.TextColorProperty, Value = textColor }
                                , new Setter { Property = Editor.PlaceholderColorProperty, Value = placeholderColor } }
                });

                resource.Add(new Xamarin.Forms.Style(typeof(Button))
                {
                    Setters = { new Setter { Property = Button.MarginProperty, Value = this.GetAttributeInt("Xamarin.Forms.Style.Button.MarginProperty") }
                                , new Setter { Property = Button.PaddingProperty, Value = this.GetAttributeInt("Xamarin.Forms.Style.Button.PaddingProperty") }
                                , new Setter { Property = Button.CornerRadiusProperty, Value = this.GetAttributeInt("Xamarin.Forms.Style.Button.CornerRadiusProperty") }
                                , new Setter { Property = Button.BorderWidthProperty, Value = this.GetAttributeInt("Xamarin.Forms.Style.Button.BorderWidthProperty") } }
                });

                resource.Add(new Xamarin.Forms.Style(typeof(DatePicker))
                {
                    Setters = { new Setter { Property = DatePicker.MarginProperty, Value = this.GetAttributeInt("Xamarin.Forms.Style.DatePicker.MarginProperty") }
                                , new Setter { Property = DatePicker.TextColorProperty, Value = textColor } }
                });

                resource.Add(new Xamarin.Forms.Style(typeof(Grid))
                {
                    Setters = { new Setter { Property = Grid.MarginProperty, Value = this.GetAttributeInt("Xamarin.Forms.Style.Grid.MarginProperty") }
                                , new Setter { Property = Grid.PaddingProperty, Value = this.GetAttributeInt("Xamarin.Forms.Style.Grid.PaddingProperty") }
                                , new Setter { Property = Grid.ColumnSpacingProperty, Value = this.GetAttributeInt("Xamarin.Forms.Style.Grid.ColumnSpacingProperty") }
                                , new Setter { Property = Grid.RowSpacingProperty, Value = this.GetAttributeInt("Xamarin.Forms.Style.Grid.RowSpacingProperty") } }
                });
                //Resources.Add(new Style(typeof(RowDefinition)) { Setters = { new Setter { Property = RowDefinition.HeightProperty, Value = 24 } } });


                //var b = this.GetAttributeColor("Xamarin.Forms.Style.Picker.TitleColorProperty");
                //var c = "Blue".ToColor();
                //var d = this.GetAttribute("Xamarin.Forms.Style.Picker.TitleColorProperty");

                resource.Add(new Xamarin.Forms.Style(typeof(Picker))
                {
                    Setters = { new Setter { Property = Picker.MarginProperty, Value =  this.GetAttributeInt("Xamarin.Forms.Style.Picker.MarginProperty") }
                                , new Setter { Property = Picker.TitleColorProperty, Value =  this.GetAttributeColor("Xamarin.Forms.Style.Picker.TitleColorProperty") }
                                //, new Setter { Property = Picker.BackgroundColorProperty, Value =  this.GetAttributeColor("Xamarin.Forms.Style.Picker.BackgroundColorProperty") }
                                , new Setter { Property = Picker.TextColorProperty, Value = textColor } }
                });

                return resource;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DefaultStyle Exception : {0}", ex.ToString());

                return null;
            }
        }
        public ResourceDictionary CreateStyle_20200406()
        {
            ResourceDictionary resource;
            int fontSizePropertyValue;
            int correction;
            Color backgroundColor;
            Color textColor;
            Color placeholderColor;

            double metrics = DeviceDisplay.MainDisplayInfo.Width * DeviceDisplay.MainDisplayInfo.Height;

            try
            {
                fontSizePropertyValue = (int)Math.Ceiling(metrics / 100000);

                correction = (fontSizePropertyValue / 3);

                fontSizePropertyValue -= correction;

                backgroundColor = ((string)Config.Client.GetAttribute("BackgroundColor")).ToColor();
                textColor = this.GetAttributeColor("Xamarin.Forms.Style.TextColor");
                placeholderColor = this.GetAttributeColor("Xamarin.Forms.Style.PlaceholderColor");

                resource = new ResourceDictionary();

                resource.Add(new Xamarin.Forms.Style(typeof(MasterDetailPage))
                {
                    Setters = { new Setter { Property = VisualElement.BackgroundColorProperty, Value = backgroundColor } }
                });

                resource.Add(new Xamarin.Forms.Style(typeof(NavigationPage))
                {
                    Setters = { new Setter { Property = VisualElement.BackgroundColorProperty, Value = backgroundColor } }
                });

                resource.Add(new Xamarin.Forms.Style(typeof(ContentPage))
                {
                    Setters = { new Setter { Property = VisualElement.BackgroundColorProperty, Value = backgroundColor } }
                });

                resource.Add(new Xamarin.Forms.Style(typeof(ScrollView)) {
                    Setters = { new Setter { Property = View.MarginProperty, Value = this.GetAttributeInt("Xamarin.Forms.Style.ScrollView.MarginProperty") }
                                , new Setter { Property = ScrollView.PaddingProperty, Value = this.GetAttributeInt("Xamarin.Forms.Style.ScrollView.PaddingProperty") } } });

                resource.Add(new Xamarin.Forms.Style(typeof(ListView))
                {
                    Setters = { new Setter { Property = ListView.MarginProperty, Value = this.GetAttributeInt("Xamarin.Forms.Style.ListView.MarginProperty") }
                                , new Setter { Property = ListView.SeparatorColorProperty, Value = this.GetAttributeColor("Xamarin.Forms.Style.ListView.SeparatorColorProperty") }
                                , new Setter { Property = ListView.HasUnevenRowsProperty, Value = this.GetAttributeBool("Xamarin.Forms.Style.ListView.HasUnevenRowsProperty") } }
                });


                resource.Add(new Xamarin.Forms.Style(typeof(Label))
                {
                    Setters = { new Setter { Property = Label.FontSizeProperty, Value = fontSizePropertyValue }
                                , new Setter { Property = Label.MarginProperty, Value = this.GetAttributeInt("Xamarin.Forms.Style.Label.MarginProperty") }
                                , new Setter { Property = Label.TextColorProperty, Value = textColor } }
                });

                resource.Add(new Xamarin.Forms.Style(typeof(Entry))
                {
                    Setters = { new Setter { Property = Entry.FontSizeProperty, Value = fontSizePropertyValue }
                                , new Setter { Property = Entry.MarginProperty, Value =  this.GetAttributeInt("Xamarin.Forms.Style.Entry.MarginProperty") }
                                , new Setter { Property = Entry.TextColorProperty, Value = textColor }
                                , new Setter { Property = Entry.PlaceholderColorProperty, Value = placeholderColor } }
                });

                resource.Add(new Xamarin.Forms.Style(typeof(Editor))
                {
                    Setters = { new Setter { Property = Editor.FontSizeProperty, Value = fontSizePropertyValue }
                                , new Setter { Property = Editor.MarginProperty, Value =  this.GetAttributeInt("Xamarin.Forms.Style.Editor.MarginProperty") }
                                , new Setter { Property = Editor.TextColorProperty, Value = textColor }
                                , new Setter { Property = Editor.PlaceholderColorProperty, Value = placeholderColor } }
                });

                resource.Add(new Xamarin.Forms.Style(typeof(Button))
                {
                    Setters = { new Setter { Property = Button.FontSizeProperty, Value = fontSizePropertyValue }
                                , new Setter { Property = Button.MarginProperty, Value = this.GetAttributeInt("Xamarin.Forms.Style.Button.MarginProperty") }
                                , new Setter { Property = Button.PaddingProperty, Value = this.GetAttributeInt("Xamarin.Forms.Style.Button.PaddingProperty") }
                                , new Setter { Property = Button.CornerRadiusProperty, Value = this.GetAttributeInt("Xamarin.Forms.Style.Button.CornerRadiusProperty") }
                                , new Setter { Property = Button.BorderWidthProperty, Value = this.GetAttributeInt("Xamarin.Forms.Style.Button.BorderWidthProperty") } }
                });

                resource.Add(new Xamarin.Forms.Style(typeof(DatePicker))
                {
                    Setters = { new Setter { Property = DatePicker.FontSizeProperty, Value = fontSizePropertyValue }
                                , new Setter { Property = DatePicker.MarginProperty, Value = this.GetAttributeInt("Xamarin.Forms.Style.DatePicker.MarginProperty") }
                                , new Setter { Property = DatePicker.TextColorProperty, Value = textColor } }
                });

                resource.Add(new Xamarin.Forms.Style(typeof(Grid))
                {
                    Setters = { new Setter { Property = Grid.MarginProperty, Value = this.GetAttributeInt("Xamarin.Forms.Style.Grid.MarginProperty") }
                                , new Setter { Property = Grid.PaddingProperty, Value = this.GetAttributeInt("Xamarin.Forms.Style.Grid.PaddingProperty") }
                                , new Setter { Property = Grid.ColumnSpacingProperty, Value = this.GetAttributeInt("Xamarin.Forms.Style.Grid.ColumnSpacingProperty") }
                                , new Setter { Property = Grid.RowSpacingProperty, Value = this.GetAttributeInt("Xamarin.Forms.Style.Grid.RowSpacingProperty") } }
                });
                //Resources.Add(new Style(typeof(RowDefinition)) { Setters = { new Setter { Property = RowDefinition.HeightProperty, Value = 24 } } });


                //var b = this.GetAttributeColor("Xamarin.Forms.Style.Picker.TitleColorProperty");
                //var c = "Blue".ToColor();
                //var d = this.GetAttribute("Xamarin.Forms.Style.Picker.TitleColorProperty");

                resource.Add(new Xamarin.Forms.Style(typeof(Picker))
                {
                    Setters = { new Setter { Property = Picker.FontSizeProperty, Value = fontSizePropertyValue }
                                , new Setter { Property = Picker.MarginProperty, Value =  this.GetAttributeInt("Xamarin.Forms.Style.Picker.MarginProperty") }
                                , new Setter { Property = Picker.TitleColorProperty, Value =  this.GetAttributeColor("Xamarin.Forms.Style.Picker.TitleColorProperty") }
                                //, new Setter { Property = Picker.BackgroundColorProperty, Value =  this.GetAttributeColor("Xamarin.Forms.Style.Picker.BackgroundColorProperty") }
                                , new Setter { Property = Picker.TextColorProperty, Value = textColor } }
                });

                return resource;
            }
            catch (Exception ex)
            {
                Console.WriteLine("DefaultStyle Exception : {0}", ex.ToString());

                return null;
            }
        }
        #endregion
    }
}
