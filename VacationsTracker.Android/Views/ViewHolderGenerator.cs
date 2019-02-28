﻿// <auto-generated />
// ReSharper disable All
using System;
using Android.App;
using Android.Support.V7.Widget;
using Android.Views;
using Android.Widget;
using Android.Support.Design.Widget;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V4.Widget;
using Android.Support.V4.View;
using Android.Support.Constraints;

namespace VacationsTracker.Android.Views
{
    public partial class DetailActivityViewHolder
    {
         private readonly Activity activity;

         private AppBarLayout pageAppbar;
         private Toolbar pageToolbar;
         private Button backButton;
         private Button saveButton;
         private ProgressBar horizontalProgressBar;
         private ViewPager vacationPager;
         private TabLayout dotTabLayout;
         private View separatorDateFirst;
         private LargeDateLayoutViewHolder dateFromViewHolder;
         private LargeDateLayoutViewHolder dateToViewHolder;
         private View separatorDateSecond;
         private RadioGroup statusRadioGroup;
         private RadioButton approvedRadio;
         private RadioButton closedRadio;
         private View separatorThird;
         private FloatingActionButton fabSaveButton;

        public DetailActivityViewHolder( Activity activity)
        {
            if (activity == null) throw new ArgumentNullException(nameof(activity));

            this.activity = activity;
        }

        
        public AppBarLayout PageAppbar =>
            pageAppbar ?? (pageAppbar = activity.FindViewById<AppBarLayout>(Resource.Id.page_appbar));

        
        public Toolbar PageToolbar =>
            pageToolbar ?? (pageToolbar = activity.FindViewById<Toolbar>(Resource.Id.page_toolbar));

        
        public Button BackButton =>
            backButton ?? (backButton = activity.FindViewById<Button>(Resource.Id.back_button));

        
        public Button SaveButton =>
            saveButton ?? (saveButton = activity.FindViewById<Button>(Resource.Id.save_button));

        
        public ProgressBar HorizontalProgressBar =>
            horizontalProgressBar ?? (horizontalProgressBar = activity.FindViewById<ProgressBar>(Resource.Id.horizontal_progress_bar));

        
        public ViewPager VacationPager =>
            vacationPager ?? (vacationPager = activity.FindViewById<ViewPager>(Resource.Id.vacation_pager));

        
        public TabLayout DotTabLayout =>
            dotTabLayout ?? (dotTabLayout = activity.FindViewById<TabLayout>(Resource.Id.dot_tab_layout));

        
        public View SeparatorDateFirst =>
            separatorDateFirst ?? (separatorDateFirst = activity.FindViewById<View>(Resource.Id.separator_date_first));

        
        public LargeDateLayoutViewHolder DateFromViewHolder =>
            dateFromViewHolder ?? (dateFromViewHolder = new LargeDateLayoutViewHolder(activity.FindViewById<ConstraintLayout>(Resource.Id.date_from)));

        
        public LargeDateLayoutViewHolder DateToViewHolder =>
            dateToViewHolder ?? (dateToViewHolder = new LargeDateLayoutViewHolder(activity.FindViewById<ConstraintLayout>(Resource.Id.date_to)));

        
        public View SeparatorDateSecond =>
            separatorDateSecond ?? (separatorDateSecond = activity.FindViewById<View>(Resource.Id.separator_date_second));

        
        public RadioGroup StatusRadioGroup =>
            statusRadioGroup ?? (statusRadioGroup = activity.FindViewById<RadioGroup>(Resource.Id.status_radio_group));

        
        public RadioButton ApprovedRadio =>
            approvedRadio ?? (approvedRadio = activity.FindViewById<RadioButton>(Resource.Id.approved_radio));

        
        public RadioButton ClosedRadio =>
            closedRadio ?? (closedRadio = activity.FindViewById<RadioButton>(Resource.Id.closed_radio));

        
        public View SeparatorThird =>
            separatorThird ?? (separatorThird = activity.FindViewById<View>(Resource.Id.separator_third));

        
        public FloatingActionButton FabSaveButton =>
            fabSaveButton ?? (fabSaveButton = activity.FindViewById<FloatingActionButton>(Resource.Id.fab_save_button));
    }

    public partial class HomeActivityViewHolder
    {
         private readonly Activity activity;

         private SwipeRefreshLayout swipeRefresh;
         private RecyclerView vacationsRecyclerView;
         private FloatingActionButton addVacationButton;
         private Toolbar homeToolbar;
         private Button logoutButton;

        public HomeActivityViewHolder( Activity activity)
        {
            if (activity == null) throw new ArgumentNullException(nameof(activity));

            this.activity = activity;
        }

        
        public SwipeRefreshLayout SwipeRefresh =>
            swipeRefresh ?? (swipeRefresh = activity.FindViewById<SwipeRefreshLayout>(Resource.Id.swipe_refresh));

        
        public RecyclerView VacationsRecyclerView =>
            vacationsRecyclerView ?? (vacationsRecyclerView = activity.FindViewById<RecyclerView>(Resource.Id.vacations_recycler_view));

        
        public FloatingActionButton AddVacationButton =>
            addVacationButton ?? (addVacationButton = activity.FindViewById<FloatingActionButton>(Resource.Id.add_vacation_button));

        
        public Toolbar HomeToolbar =>
            homeToolbar ?? (homeToolbar = activity.FindViewById<Toolbar>(Resource.Id.home_toolbar));

        
        public Button LogoutButton =>
            logoutButton ?? (logoutButton = activity.FindViewById<Button>(Resource.Id.logout_button));
    }

    public partial class LoginActivityViewHolder
    {
         private readonly Activity activity;

         private TextView invalidCredentialLabel;
         private TextInputLayout loginTextInput;
         private TextInputLayout passwordTextInput;
         private Button loginButton;
         private ImageView progressRingSecond;

        public LoginActivityViewHolder( Activity activity)
        {
            if (activity == null) throw new ArgumentNullException(nameof(activity));

            this.activity = activity;
        }

        
        public TextView InvalidCredentialLabel =>
            invalidCredentialLabel ?? (invalidCredentialLabel = activity.FindViewById<TextView>(Resource.Id.invalidCredentialLabel));

        
        public TextInputLayout LoginTextInput =>
            loginTextInput ?? (loginTextInput = activity.FindViewById<TextInputLayout>(Resource.Id.loginTextInput));

        
        public TextInputLayout PasswordTextInput =>
            passwordTextInput ?? (passwordTextInput = activity.FindViewById<TextInputLayout>(Resource.Id.passwordTextInput));

        
        public Button LoginButton =>
            loginButton ?? (loginButton = activity.FindViewById<Button>(Resource.Id.loginButton));

        
        public ImageView ProgressRingSecond =>
            progressRingSecond ?? (progressRingSecond = activity.FindViewById<ImageView>(Resource.Id.progress_ring_second));
    }

    public partial class VacationHeaderCellViewHolder
    {
         private TextView lastUpdateTime;



        
        public TextView LastUpdateTime =>
            lastUpdateTime ?? (lastUpdateTime = ItemView.FindViewById<TextView>(Resource.Id.last_update_time));
    }

    public partial class VacationItemCellViewHolder
    {
         private ImageView vacationTypeImageView;
         private TextView vacationDurationTextView;
         private TextView vacationTypeTextView;
         private TextView vacationStatusTextView;



        
        public ImageView VacationTypeImageView =>
            vacationTypeImageView ?? (vacationTypeImageView = ItemView.FindViewById<ImageView>(Resource.Id.vacationTypeImageView));

        
        public TextView VacationDurationTextView =>
            vacationDurationTextView ?? (vacationDurationTextView = ItemView.FindViewById<TextView>(Resource.Id.vacationDurationTextView));

        
        public TextView VacationTypeTextView =>
            vacationTypeTextView ?? (vacationTypeTextView = ItemView.FindViewById<TextView>(Resource.Id.vacationTypeTextView));

        
        public TextView VacationStatusTextView =>
            vacationStatusTextView ?? (vacationStatusTextView = ItemView.FindViewById<TextView>(Resource.Id.vacationStatusTextView));
    }

    public partial class SnackbarFragmentViewHolder
    {
         private readonly View rootView;

         private TextView textSnackbar;

        public SnackbarFragmentViewHolder( View rootView)
        {
            if (rootView == null) throw new ArgumentNullException(nameof(rootView));

            this.rootView = rootView;
        }

        
        public TextView TextSnackbar =>
            textSnackbar ?? (textSnackbar = rootView.FindViewById<TextView>(Resource.Id.text_snackbar));
    }

    public partial class VacationTypeFragmentViewHolder
    {
         private readonly View rootView;

         private ImageView vacationTypeImageView;
         private TextView vacationTypeTextView;

        public VacationTypeFragmentViewHolder( View rootView)
        {
            if (rootView == null) throw new ArgumentNullException(nameof(rootView));

            this.rootView = rootView;
        }

        
        public ImageView VacationTypeImageView =>
            vacationTypeImageView ?? (vacationTypeImageView = rootView.FindViewById<ImageView>(Resource.Id.vacation_type_image_view));

        
        public TextView VacationTypeTextView =>
            vacationTypeTextView ?? (vacationTypeTextView = rootView.FindViewById<TextView>(Resource.Id.vacation_type_text_view));
    }

    public partial class LargeDateLayoutViewHolder
    {
         private readonly View rootView;

         private ConstraintLayout dateFrom;
         private View centerView;
         private TextView dayOfDate;
         private TextView monthOfDate;
         private TextView yearOfDate;

        public LargeDateLayoutViewHolder( View rootView)
        {
            if (rootView == null) throw new ArgumentNullException(nameof(rootView));

            this.rootView = rootView;
        }

        
        public ConstraintLayout DateFrom =>
            dateFrom ?? (dateFrom = (ConstraintLayout)rootView);

        
        public View CenterView =>
            centerView ?? (centerView = rootView.FindViewById<View>(Resource.Id.center_view));

        
        public TextView DayOfDate =>
            dayOfDate ?? (dayOfDate = rootView.FindViewById<TextView>(Resource.Id.day_of_date));

        
        public TextView MonthOfDate =>
            monthOfDate ?? (monthOfDate = rootView.FindViewById<TextView>(Resource.Id.month_of_date));

        
        public TextView YearOfDate =>
            yearOfDate ?? (yearOfDate = rootView.FindViewById<TextView>(Resource.Id.year_of_date));
    }

}
// ReSharper restore All
