using System;
using System.Windows;
using System.Windows.Threading;
using IGWebApiClient.Common;
using SampleWPFTrader.ViewModel;

namespace SampleWPFTrader.Common
{
    public class SmartDispatcher : PropertyEventDispatcher
    {
        private static readonly PropertyEventDispatcher __instance = new SmartDispatcher();

        private static readonly bool __designer = false;
        private static Dispatcher _instance;
        private ViewModelBase _viewModel;

        public static PropertyEventDispatcher GetInstance()
        {
            return __instance;
        }

        public void SetViewModel(ViewModelBase viewModel)
        {
            this._viewModel = viewModel;
        }

        public void addEventMessage(string message)
        {
            _viewModel.AddStatusMessage(message);
        }

        public void BeginInvoke(Action a)
        {
            BeginInvoke(a, false);
        }

        public void BeginInvoke(Action a, bool forceInvoke)
        {
            if (_instance == null)
            {
                RequireInstance();
            }

            // If the current thread is the user interface thread, skip the
            // dispatcher and directly invoke the Action.
            if (_instance != null)
            {
                if ((forceInvoke && _instance != null || !_instance.CheckAccess()) && !__designer)
                {
                    _instance.BeginInvoke(a);
                }
                else
                {
                    a();
                }
            }
            else
            {
                if (__designer || Application.Current == null)
                {
                    a();
                }
            }
        }

        private void RequireInstance()
        {
            // Design-time is more of a no-op, won't be able to resolve the
            // dispatcher if it isn't already set in these situations.
            if (__designer || Application.Current == null)
            {
                return;
            }

            // Attempt to use the RootVisual of the plugin to retrieve a
            // dispatcher instance. This call will only succeed if the current
            // thread is the UI thread.
            try
            {
                _instance = Application.Current.Dispatcher;
            }
            catch (Exception e)
            {
                throw new InvalidOperationException("The first time SmartDispatcher is used must be from a user interface thread. Consider having the application call Initialize, with or without an instance.", e);
            }

            if (_instance == null)
            {
                throw new InvalidOperationException("Unable to find a suitable Dispatcher instance.");
            }
        }

        /// <summary>
        /// Initializes the SmartDispatcher system with the dispatcher
        /// instance and logger
        /// </summary>
        /// <param name="dispatcher">The dispatcher instance.</param>
        public static void Initialize(Dispatcher dispatcher)
        {
            _instance = dispatcher ?? throw new ArgumentNullException(nameof(dispatcher));
        }
    }
}