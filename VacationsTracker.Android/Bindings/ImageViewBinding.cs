using System;
using Android.Support.Annotation;
using Android.Widget;
using FlexiMvvm.Bindings;
using FlexiMvvm.Bindings.Custom;

namespace VacationsTracker.Android.Bindings
{
    internal static class ImageViewBinding
    {
        [NonNull]
        public static TargetItemBinding<ImageView, int> SetImageResourceBinding(
            [NonNull] this IItemReference<ImageView> imageViewReference)
        {
            if(imageViewReference == null)
            {
                throw new ArgumentNullException(nameof(imageViewReference));
            }

            return new TargetItemOneWayCustomBinding<ImageView, int>(
                imageViewReference,
                (imageView, resourse) => imageView.SetImageResource(resourse),
                () => "SetImageResource");
        }
    }
}