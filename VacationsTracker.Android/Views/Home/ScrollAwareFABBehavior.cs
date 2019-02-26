using Android.Content;
using Android.Graphics.Drawables;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using Android.Support.V4.View.Animation;
using Android.Util;
using Android.Views;
using Java.Lang;

namespace VacationsTracker.Android.Views.Home
{
    [Register("HideMyFab.ScrollAwareFABBehavior")]
    // ReSharper disable once InconsistentNaming
    public class ScrollAwareFABBehavior : CoordinatorLayout.Behavior
    {
        public ScrollAwareFABBehavior(Context context, IAttributeSet attrs) : base(context, attrs)
        {
        }

        public override bool OnStartNestedScroll(CoordinatorLayout coordinatorLayout, Object child, View directTargetChild, View target,
            int axes, int type)
        {
            return axes == ViewCompat.ScrollAxisVertical ||
                   base.OnStartNestedScroll(coordinatorLayout, child, directTargetChild, target, axes, type);
        }

        public override void OnNestedScroll(CoordinatorLayout coordinatorLayout, Object child, View target, int dxConsumed, int dyConsumed,
            int dxUnconsumed, int dyUnconsumed, int type)
        {
            base.OnNestedScroll(coordinatorLayout, child, target, dxConsumed, dyConsumed, dxUnconsumed, dyUnconsumed, type);

            var floatingActionButtonChild = child.JavaCast<FloatingActionButton>();

            if (dyConsumed > 0)
            {
                Hide(floatingActionButtonChild);
            }
            else if (dyConsumed < 0)
            {
                Show(floatingActionButtonChild);
            }
        }

        private void Hide(FloatingActionButton button)
        {
            ViewCompat.Animate(button).ScaleX(0F).ScaleY(0F).Alpha(1.0F)
                .SetInterpolator(new FastOutSlowInInterpolator()).WithLayer().SetListener(null)
                .WithStartAction(new AnimationDrawable())
                .WithEndAction(new Runnable(() => button.Visibility = ViewStates.Invisible));
        }

        private void Show(FloatingActionButton button)
        {
            ViewCompat.Animate(button).ScaleX(1.0F).ScaleY(1.0F).Alpha(1.0F)
                .SetInterpolator(new FastOutLinearInInterpolator()).WithLayer().SetListener(null)
                .WithStartAction(new Runnable(() => button.Visibility = ViewStates.Visible));
        }
    }
}