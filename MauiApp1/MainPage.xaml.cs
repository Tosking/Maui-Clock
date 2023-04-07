using System.Drawing;
using Android.Util;
using AbsoluteLayout = Microsoft.Maui.Controls.AbsoluteLayout;
using Color = Microsoft.Maui.Graphics.Color;
using Microsoft.Maui.Layouts;

namespace MauiApp1;

public partial class MainPage : ContentPage
{
    private int[,] _number = 
    {
        {-20, 250, 43, 8},
        {-20, 250, 8, 43},
        {15, 250, 8, 43},
        {-20, 285, 43, 8},
        {-20, 285, 8, 43},
        {15, 285, 8, 43},
        {-20, 320, 43, 8}
    };

    private int[,] num_coords =
    {
        {0, 1, 2, 4, 5, 6, -1}, //0
        {2, 5, -1, -1, -1, -1, -1}, //1
        {0, 2, 3, 4, 6, -1, -1}, //2
        {0, 2, 3, 5, 6, -1, -1}, //3
        {1, 2, 3, 5, -1, -1, -1}, //4
        {0, 1, 3, 5, 6, -1, -1}, //5
        {0, 1, 4, 3, 5, 6, -1}, //6
        {0, 2, 5, -1, -1, -1, -1}, //7
        {0, 1, 2, 3, 4, 5, 6}, //8
        {0, 1, 2, 3, 5, 6, -1} //9
    };

    private BoxView[,] numbers = new BoxView[6,7];

    

    public MainPage()
	{
        
		InitializeComponent();
        InitNums();
        Device.StartTimer(TimeSpan.FromSeconds(1), OnTimer);
        OnTimer();
    }

    bool OnTimer()
    {
        DateTime dateTime = DateTime.Now;
        
        SetBox(0, dateTime.Hour / 10);
        SetBox(1, dateTime.Hour % 10);
        SetBox(2, dateTime.Minute / 10);
        SetBox(3, dateTime.Minute % 10);
        SetBox(4, dateTime.Second / 10);
        SetBox(5, dateTime.Second % 10);
        return true;
    }

    private void InitNums()
    {
        
        for (int k = 0; k < 6; k++)
        {
            for (int i = 0; i < 7; i++)
            {
                var x = new BoxView { Color = new Color(255, 0, 0) };
                absoluteLayout.Children.Add(x);
                var chapter = Math.Floor((double)(k / 2));
                if (k % 2 == 0 && k != 0 && i == 0)
                {
                    var dot1 = new BoxView { Color = new Color(0, 0, 0) };
                    var dot2 = new BoxView { Color = new Color(0, 0, 0) };
                    absoluteLayout.Children.Add(dot1);
                    absoluteLayout.Children.Add(dot2);
                    absoluteLayout.SetLayoutBounds(dot1, new Rect(_number[i, 0] + k * 63 + chapter * 10 - 16, 260, 8, 8));
                    absoluteLayout.SetLayoutBounds(dot2, new Rect(_number[i, 0] + k * 63 + chapter * 10 - 16, 310, 8, 8));
                }

                absoluteLayout.SetLayoutBounds(x, new Rect(_number[i, 0] + k * 63 + chapter * 10, _number[i, 1] ,_number[i, 2], _number[i, 3]));
                numbers[k, i] = x;
            }
        }
    }

    public void SetBox(int num, int time)
    {
        for (int i = 0; i < 7; i++)
        {
            numbers[num, i].Color = new Color(255, 255, 255, 1);
        }

        for (int i = 0; i < 7; i++)
        {
            if (num_coords[time, i] != -1)
            {
                numbers[num, num_coords[time, i]].Color = new Color(0, 0, 0);
            }
        }
    }

    }