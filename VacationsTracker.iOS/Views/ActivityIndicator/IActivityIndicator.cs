using CoreAnimation;
using CoreGraphics;
using UIKit;

namespace VacationsTracker.iOS.Views.ActivityIndicator
{
    public interface IActivityIndicator
    {
        void SetupAnimationInLayer(CALayer layer, CGSize size, UIColor tintColor);
    }
}