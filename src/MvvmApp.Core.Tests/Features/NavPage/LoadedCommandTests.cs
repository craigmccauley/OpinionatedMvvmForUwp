using AutoFixture.Xunit2;
using FluentAssertions;
using MvvmApp.Core.Tests.TestHelpers;
using MvvmApp.Features.NavPage;
using MvvmApp.Infrastructure.Application;
using MvvmApp.Infrastructure.ViewModel;
using NSubstitute;
using System;
using System.Threading.Tasks;
using Xunit;

namespace MvvmApp.Core.Tests.Features.NavPage
{
    public class LoadedCommandTests
    {
        [Theory, AutoSubData]
        public void ExecuteCommand_WhenParameterIsNotNavPageViewModel_ShouldNotThrow(
            LoadedCommand sut)
        {
            //arrange

            //act
            var result = Record.Exception(() => sut.Execute(null));

            //assert
            result.Should().BeNull();
        }

        [Theory, AutoSubData]
        public void ExecuteCommand_WhenMenuItemsIsNull_ShouldNotThrow(
            [NoAutoProperties] NavPageViewModel vm,
            LoadedCommand sut)
        {
            //arrange

            //act
            var result = Record.Exception(() => sut.Execute(vm));

            //assert
            result.Should().BeNull();
        }

        [Theory, AutoSubData]
        public void ExecuteCommand_WhenMenuItemsIsEmpty_ShouldNotThrow(
            [NoAutoProperties] NavPageViewModel vm,
            LoadedCommand sut)
        {
            //arrange
            vm.MenuItems = [];

            //act
            var result = Record.Exception(() => sut.Execute(vm));

            //assert
            result.Should().BeNull();
        }

        [Theory, AutoSubData]
        public void ExecuteCommand_WhenParameterIsNavPageViewModel_ShouldSetFirstItemIsSelectedToTrue(
            [Frozen] IHooks hooks,
            [NoAutoProperties] MenuItem item1,
            [NoAutoProperties] MenuItem item2,
            [NoAutoProperties] NavPageViewModel vm,
            IPageViewModel destinationViewModel,
            LoadedCommand sut)
        {
            //arrange
            item1.NavDestination = Pages.All.PickRandom();
            vm.MenuItems = [item1, item2];

            hooks.GetPageViewModel(item1.NavDestination).Returns(destinationViewModel);
            hooks.RunOnUIThreadAsync(Arg.Any<Action>()).Returns(info =>
            {
                info.Arg<Action>()?.Invoke();
                return Task.CompletedTask;
            });

            sut.ExecuteCompleted += ExecuteCompleted;


            //act
            sut.Execute(vm);

            //assert
            void ExecuteCompleted(object sender, EventArgs e)
            {
                vm.SelectedView.Should().Be(destinationViewModel);
            }
        }
    }
}
