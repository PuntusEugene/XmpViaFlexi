using UIKit;

namespace VacationsTracker.iOS.Design
{
    public static class AppImages
    {
        public static UIImage Background => GetImage("Background");

        public static UIImage IconRequestBlue => GetImage("IconRequestBlue");

        public static UIImage IconRequestDark => GetImage("IconRequestDark");

        public static UIImage IconRequestGreen => GetImage("IconRequestGreen");

        public static UIImage IconRequestRed => GetImage("IconRequestRed");

        public static UIImage IconRequestGrey => GetImage("IconRequestGrey");

        public static UIImage IconRequestOrange => GetImage("IconRequestOrange");

        public static UIImage Plus => GetImage("Plus");

        public static UIImage RightArrow => GetImage("RightArrow");

        public static UIImage LeftArrowWhite => GetImage("LeftArrowWhite");


        private static UIImage GetImage(string name)
        {
            return UIImage.FromBundle(name);
        }
    }
}