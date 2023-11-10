// Muffled is an open-source cosmos window manager that's made to sound similiar
// and behave similiar to Cinnamon's Mutter window manager on linux and this
// window manager is made to do the same thing on Cinnamomum in Lynox/other
// independent projects that use Cinnamomum.
using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Runtime.Remoting;
using Cinnamomum.CinnamomumDE.AppKit;

namespace Cinnamomum.CinnamomumDE
{
    public struct MuffledWidgets
    {

    }

    public enum MuffleTheme
    {
        DefaultCinnamomum = 0
    }

    public static class MuffleThemeHandler
    {
        
        public static void handleTheme(MuffleTheme theme, windowObject obj)
        {
            switch (theme)
            {
                case MuffleTheme.DefaultCinnamomum:
                    var defaultCinnamomumRadius = 10;
                    var color = 30;
                    CinaDrawLib.DrawFilledCircle(Color.FromArgb(color, color, color), 2 + obj.x + defaultCinnamomumRadius, 2 + obj.y + defaultCinnamomumRadius, defaultCinnamomumRadius);
                    CinaDrawLib.DrawFilledRectangle(Color.FromArgb(color, color, color), 2 + obj.x, 2 + obj.y + (defaultCinnamomumRadius / 2), obj.w + 3, obj.h);
                    CinaDrawLib.DrawFilledCircle(Color.FromArgb(color, color, color), 2 + obj.x + defaultCinnamomumRadius + obj.w, 2 + obj.y + defaultCinnamomumRadius, defaultCinnamomumRadius);
                    CinaDrawLib.DrawFilledRectangle(Color.FromArgb(color, color, color), 2 + obj.x + obj.w + 1, 2 + obj.y + (defaultCinnamomumRadius), defaultCinnamomumRadius * 2, 2 + obj.h);
                    CinaDrawLib.DrawFilledRectangle(Color.FromArgb(color, color, color), 2 + obj.x + (defaultCinnamomumRadius / 2), obj.y, 2 + obj.w - (defaultCinnamomumRadius / 4) + 5, defaultCinnamomumRadius);
                    CinaDrawLib.DrawFilledRectangle(Color.FromArgb(color, color, color), 2 + obj.x, 2 + obj.y + obj.h, 2 + obj.w + 5 + defaultCinnamomumRadius, defaultCinnamomumRadius * 2);

                    color = 204;
                    CinaDrawLib.DrawFilledCircle(Color.FromArgb(color, color, color), obj.x + defaultCinnamomumRadius, obj.y + defaultCinnamomumRadius, defaultCinnamomumRadius);
                    CinaDrawLib.DrawFilledRectangle(Color.FromArgb(color, color, color), obj.x, obj.y + (defaultCinnamomumRadius / 2), obj.w + 3, obj.h);
                    CinaDrawLib.DrawFilledCircle(Color.FromArgb(color, color, color), obj.x + defaultCinnamomumRadius + obj.w, obj.y + defaultCinnamomumRadius, defaultCinnamomumRadius);
                    CinaDrawLib.DrawFilledRectangle(Color.FromArgb(color, color, color), obj.x + obj.w + 1, obj.y + (defaultCinnamomumRadius), defaultCinnamomumRadius * 2, obj.h);
                    CinaDrawLib.DrawFilledRectangle(Color.FromArgb(color, color, color), obj.x + (defaultCinnamomumRadius / 2), obj.y, obj.w - (defaultCinnamomumRadius / 4) + 5, defaultCinnamomumRadius);
                    CinaDrawLib.DrawFilledRectangle(Color.FromArgb(color, color, color), obj.x, obj.y + obj.h, obj.w + 2, defaultCinnamomumRadius);

                    CinaDrawLib.DrawFilledRectangle(Color.FromArgb(255, 255, 255), obj.x, obj.y + (defaultCinnamomumRadius * 2), obj.w + (defaultCinnamomumRadius * 2), obj.h);
                    return;
                default:
                    GlobalLog.AddLog("SEVERE", "Invalid Theme Request.");
                    return;
            }
        }

    }

    public struct windowObject
    {
        /// <summary>
        /// This might be a bit, but it's really simple, just put all parameters in and rest will be guided to you.
        /// </summary>
        /// <param name="execNum">Execution number can be any number as it is just use for identification for software by kernel if required.</param>
        /// <param name="X">X is x-axis coordinate of your window.</param>
        /// <param name="Y">Y is y-axis coordinate of your window.</param>
        /// <param name="W">W is x-axis size/the breadth of your window.</param>
        /// <param name="H">H is y-axis size/the length of your window.</param>
        /// <param name="title">Title is the name of your window.</param>
        /// <param name="allWidgets">This is a bit complex but you may need to make a separate variable for this widgets, insert all widgets you want in it, say a button that you put in the variable with all its coordinates and drawing information and put that entire widgets structure here so essentially specifying all your contents in the window.</param>
        /// <param name="themes">This involves also in making a separate variable for themes, selecting a theme via its specific documentation and then inserting that theme variable here to customize your window theme.</param>
        /// <param name="actionHandler">This parameter includes all possible interactions that can happen in a window, you must set it to all actions you want to happen in your window.</param>
        public windowObject(int execNum, int X, int Y, int W, int H, string title, MuffledWidgets allWidgets, MuffleTheme themes, MuffleAction actionHandler)
        {
            execNumber = execNum;
            x = X;
            y = Y;
            w = W;
            h = H;
            name = title;
            widgets = allWidgets;
            theme = themes;
            actionOnInteraction = actionHandler;
        }

        /// <summary>
        /// This just removes/dumps your window out of the window manager.
        /// </summary>
        public void Dump() => Muffled.DumpSpecificWindow(this);

        public int execNumber;
        public int x;
        public int y;
        public int w;
        public int h;
        public string name;
        public MuffledWidgets widgets;
        public MuffleTheme theme;
        public MuffleAction actionOnInteraction;
    }

    public struct MuffleAction
    {
        /// <summary>
        /// MuffleAction is a structure that helps you to basically handle any interaction done in a window object.
        /// </summary>
        /// <param name="buttonHover">They are just like their names, just make a function and tie it here.</param>
        /// <param name="buttonPressed">They are just like their names, just make a function and tie it here.</param>
        /// <param name="buttonReleased">They are just like their names, just make a function and tie it here.</param>
        /// <param name="textboxHover">They are just like their names, just make a function and tie it here.</param>
        /// <param name="textboxFocussed">They are just like their names, just make a function and tie it here.</param>
        /// <param name="textboxKeyPress">They are just like their names, just make a function and tie it here.</param>
        /// <param name="labelHover">They are just like their names, just make a function and tie it here.</param>
        /// <param name="labelPressed">They are just like their names, just make a function and tie it here.</param>
        /// <param name="labelReleased">They are just like their names, just make a function and tie it here.</param>
        /// <param name="windowHover">They are just like their names, just make a function and tie it here.</param>
        /// <param name="windowClicked">They are just like their names, just make a function and tie it here.</param>
        /// <param name="windowReleased">They are just like their names, just make a function and tie it here.</param>
        /// <param name="windowCreated">They are just like their names, just make a function and tie it here.</param>
        public MuffleAction(Action buttonHover      , Action buttonPressed      , Action buttonReleased     ,
                            Action textboxHover     , Action textboxFocussed    , Action textboxKeyPress    ,
                            Action labelHover       , Action labelPressed       , Action labelReleased      ,
                            Action windowHover      , Action windowClicked      , Action windowReleased     , Action windowCreated
                           )
        {
            this.buttonHover = buttonHover;
            this.buttonPressed = buttonPressed;
            this.buttonReleased = buttonReleased;

            this.textboxHover = textboxHover;
            this.textboxFocussed = textboxFocussed;
            this.textboxKeyPress = textboxKeyPress;

            this.labelHover = labelHover;
            this.labelPressed = labelPressed;
            this.labelReleased = labelReleased;

            this.windowHover = windowHover;
            this.windowClicked = windowClicked;
            this.windowReleased = windowReleased;
            this.windowCreated = windowCreated;
        }

        public Action buttonHover;
        public Action buttonPressed;
        public Action buttonReleased;

        public Action textboxHover;
        public Action textboxFocussed;
        public Action textboxKeyPress;

        public Action labelHover;
        public Action labelPressed;
        public Action labelReleased;

        public Action windowHover;
        public Action windowClicked;
        public Action windowReleased;
        public Action windowCreated;
    }

    public static class Muffled
    {
        private static List<windowObject> windows = new List<windowObject>();

        /// <summary>
        /// THIS FUNCTION IS FOR INTERNAL STRUCTURE OF CINNAMOMUM, PLEASE DO NOT EDIT/EXECUTE THROUGH KERNEL.
        /// </summary>
        public static void DrawAll()
        {
            windows = InternalUtilities.ConcatTwoWindowObjects(windows, AppMaker.GIVEALLAPPS());
            foreach (var winobj in windows)
            {
                MuffleThemeHandler.handleTheme(winobj.theme, winobj);
            }
        }

        /// <summary>
        /// THIS FUNCTION IS FOR INTERNAL STRUCTURE OF CINNAMOMUM, PLEASE DO NOT EDIT/EXECUTE THROUGH KERNEL.
        /// </summary>
        public static void DumpSpecificWindow(windowObject thatObject)
        {
            if (windows.Contains(thatObject))
            {
                windows.Remove(thatObject);
                DrawAll();
            }
        }

        /// <summary>
        /// This is an internal function but can be used in kernel code. (but not recommended as it may require some inner level knowledge and deep understanding of the Cinnamomum source code.)
        /// </summary>
        /// <param name="obj">This is a window object, make a separate variable for it and then put it here.</param>
        public static void MakeWindow(windowObject obj)
        {
            windows.Add(obj);
        }
    }
}
