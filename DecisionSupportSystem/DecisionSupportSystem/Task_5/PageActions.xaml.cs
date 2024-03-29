﻿using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Navigation;
using DecisionSupportSystem.MainClasses;
using DecisionSupportSystem.Task_4;
using DecisionSupportSystem.ViewModels;

namespace DecisionSupportSystem.Task_5
{
    public partial class PageActions : Page
    {
        private BaseLayer _baseLayer;
        private NavigationService _navigation;
        private ActionListViewModel _actionListViewModel;
        private EventsDependingActionListViewModel _eventsDependingActionListViewModel;

        #region Конструкторы

        private void BindElements()
        {
            _actionListViewModel = new ActionListViewModel(_baseLayer);
            ActionListControl.DataContext = _actionListViewModel;
            ActionControl.DataContext = new ActionViewModel(_actionListViewModel);
        }

        public PageActions()
        {
            InitializeComponent();
            _baseLayer = new BaseLayer();
            _eventsDependingActionListViewModel = new EventsDependingActionListViewModel(_baseLayer);
            ErrorCount.Reset();
        }

        public PageActions(BaseLayer baseLayer, EventsDependingActionListViewModel eventsDependingActionListViewModel)
        {
            InitializeComponent();
            _baseLayer = baseLayer;
            _eventsDependingActionListViewModel = eventsDependingActionListViewModel;
            BindElements();
            ErrorCount.Reset();
        }

        public void Show(object pageAction, string title, string taskuniq, BaseLayer baseLayer)
        {
            if (baseLayer != null) _baseLayer = baseLayer;
            _baseLayer.Task.TaskUniq = taskuniq;
            BindElements();
            _eventsDependingActionListViewModel.DependingActionListViewModel(_baseLayer);
            NavigationWindowShower.ShowNavigationWindows(new NavigationWindow(), pageAction, title, _baseLayer,
                new LocalTaskLayer(_baseLayer, _eventsDependingActionListViewModel));
        }
        #endregion

        private void PageActionsOnLoaded(object sender, RoutedEventArgs e)
        {
            _navigation = NavigationService.GetNavigationService(this);
        }

        #region Обработка событий Validation.Error

        public void NextPage_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            if (_actionListViewModel.ActionViewModels.Count > 0)
            {
                /*if (_eventsDependingActionListViewModel == null)
                    _eventsDependingActionListViewModel = new EventsDependingActionListViewModel(_baseLayer);
                else*/
                    _eventsDependingActionListViewModel.CheckUpdatingData(_baseLayer);
                _navigation.Navigate(new PageEvents(_baseLayer, _eventsDependingActionListViewModel));
                ErrorCount.EntityErrorCount = 0;
            }
        }

        private void NextPage_CanExecute(object sender, CanExecuteRoutedEventArgs e)
        {
            e.CanExecute = ErrorCount.EntityListErrorCount == 0;
            e.Handled = true;
        }
        #endregion


    }
}
