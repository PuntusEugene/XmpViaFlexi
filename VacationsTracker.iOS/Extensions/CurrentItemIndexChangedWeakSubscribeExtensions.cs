using System;
using FlexiMvvm.Collections;
using FlexiMvvm.Weak.Subscriptions;

namespace VacationsTracker.iOS.Extensions
{
    public static class CurrentItemIndexChangedWeakSubscribeExtensions
    {        
        public static IDisposable CurrentItemIndexChangedWeakSubscribe(
            this UIPageViewControllerObservableDataSource eventSource,
            EventHandler<IndexChangedEventArgs> eventHandler)
        {
            if (eventSource == null)
            {
                throw new ArgumentNullException(nameof(eventSource));
            }

            if (eventHandler == null)
            {
                throw new ArgumentNullException(nameof(eventHandler));
            }

            return new WeakEventSubscription<UIPageViewControllerObservableDataSource, IndexChangedEventArgs>(
                eventSource,
                (source, handler) => source.CurrentItemIndexChanged += handler,
                (source, handler) => source.CurrentItemIndexChanged -= handler,
                eventHandler);
        }
    }
}