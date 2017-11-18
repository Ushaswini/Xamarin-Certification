using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;

using Xamarin.Forms;

namespace FormsPractice
{
    public class GridPage : ContentPage
    {

        Label _number;
        public GridPage()
        {

            /*NUMBER
             * 7 8 9
             * 4 5 6
             * 1 2 3
             * --0--
             * 
             * */
            var grid = new Grid
            {
                RowDefinitions =
                {
                    new RowDefinition
                    {
                        Height = new GridLength(1.4,GridUnitType.Star)
                    },
                    new RowDefinition
                    {
                        Height = new GridLength(1,GridUnitType.Star)
                    },
                    new RowDefinition
                    {
                        Height = new GridLength(1,GridUnitType.Star)
                    },
                    new RowDefinition
                    {
                        Height = new GridLength(1,GridUnitType.Star)
                    },
                    new RowDefinition
                    {
                        Height = new GridLength(1,GridUnitType.Star)
                    }

                },
                ColumnDefinitions =
                {
                    new ColumnDefinition
                    {
                        Width=new GridLength(1,GridUnitType.Star)
                    },
                     new ColumnDefinition
                    {
                        Width=new GridLength(1,GridUnitType.Star)
                    },
                      new ColumnDefinition
                    {
                        Width=new GridLength(1,GridUnitType.Star)
                    }
                }

            };

           _number = new Label
            {
                BackgroundColor = Color.Black,
                TextColor = Color.White,
                FontSize = 60
            };
            //right:what is excluded or not included
            grid.Children.Add(_number, left:0,right:3,top:0,bottom:1);

            grid.Children.Add(CreateButton("7"), left:0, top:1);
            grid.Children.Add(CreateButton("8"), left: 1, top: 1);
            grid.Children.Add(CreateButton("9"), left: 2, top: 1);

            grid.Children.Add(CreateButton("4"), left: 0, top: 2);
            grid.Children.Add(CreateButton("5"), left: 1, top: 2);
            grid.Children.Add(CreateButton("6"), left: 2, top: 2);

            grid.Children.Add(CreateButton("1"), left: 0, top: 3);
            grid.Children.Add(CreateButton("2"), left: 1, top: 3);
            grid.Children.Add(CreateButton("3"), left: 2, top: 3);

            var buttonZero = CreateButton("0");
            Grid.SetColumn(buttonZero, 0);
            Grid.SetRow(buttonZero, 4);
            Grid.SetColumnSpan(buttonZero, 3);

            grid.Children.Add(buttonZero);

            Content = grid;
        }

        private View CreateButton(string text)
        {
            var btn = new Button
            {
                Text=text,
                BackgroundColor=Color.Blue,
                TextColor=Color.Yellow,
                Font=Font.SystemFontOfSize(30,FontAttributes.Bold)
            };

            btn.Clicked += (sender, args) => { _number.Text += ((Button)sender).Text; };

            return btn;
        }
    }
}