using System;
using Android.Support.Annotation;
using Android.Support.V4.Widget;
using Android.Text;
using Android.Widget;
using FlexiMvvm;
using FlexiMvvm.Bindings;
using FlexiMvvm.Bindings.Custom;

namespace VacationsTracker.Android.Bindings
{
    internal static class SwipeRefreshLayoutBinding
    {
        [NonNull]
        public static TargetItemBinding<SwipeRefreshLayout, bool> RefreshingBinding(
            [NonNull] this IItemReference<SwipeRefreshLayout> swipeRefreshLayout)
        {
            if (swipeRefreshLayout == null)
            {
                throw new ArgumentNullException(nameof(swipeRefreshLayout));
            }

            return new TargetItemOneWayCustomBinding<SwipeRefreshLayout, bool>(
                swipeRefreshLayout,
                (refreshLayout, resourse) => refreshLayout.Refreshing = resourse,
                () => "Refreshing");
        }

        [NonNull]
        public static TargetItemBinding<SwipeRefreshLayout, bool> RefreshBinding(
            [NonNull] this IItemReference<SwipeRefreshLayout> swipeRefreshReference,
            bool trackCanExecuteCommandChanged = false)
        {
            if (swipeRefreshReference == null)
            {
                throw new ArgumentNullException(nameof(swipeRefreshReference));
            }

            return new TargetItemOneWayToSourceCustomBinding<SwipeRefreshLayout, bool>(
                swipeRefreshReference,
                (swipeRefresh, eventHandler) => swipeRefresh.NotNull().Refresh += eventHandler,
                (swipeRefresh, eventHandler) => swipeRefresh.NotNull().Refresh -= eventHandler,
                (swipeRefresh, canExecuteCommand) =>
                {
                    if (trackCanExecuteCommandChanged)
                    {
                        swipeRefresh.NotNull().Refreshing = canExecuteCommand;
                    }
                },
                (swipeRefresh) => swipeRefresh.NotNull().Refreshing,
                () => $"{nameof(SwipeRefreshLayout.Refresh)}");
        }
    }
}