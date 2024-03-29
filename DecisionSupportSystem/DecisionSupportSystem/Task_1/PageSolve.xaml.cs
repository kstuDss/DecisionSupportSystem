﻿using System.Windows;
using System.Windows.Navigation;
using DecisionSupportSystem.MainClasses;

namespace DecisionSupportSystem.Task_1
{
    public partial class PageSolve
    {
        private BaseLayer _baseLayer;
        private NavigationService navigation;

        private void Init()
        {
            GrdSolutionLst.ItemsSource = _baseLayer.DssDbContext.Actions.Local;
            GrdTask.DataContext = _baseLayer.SolvedTaskView;
        }

        public PageSolve(BaseLayer baseLayer)
        {
            InitializeComponent();
            _baseLayer = baseLayer;
            Init();
        }

        private void BtnShowSolution_OnClick(object sender, RoutedEventArgs e)
        {
            _baseLayer.SolveThisTask(null);
            GrdSolutionLst.Items.Refresh();
        }

        private void BtnPrev_Click(object sender, RoutedEventArgs e)
        {
            navigation = NavigationService.GetNavigationService(this);
            navigation.Navigate(new PageCombinations(_baseLayer));
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            _baseLayer.Save();
        }
    }
}
