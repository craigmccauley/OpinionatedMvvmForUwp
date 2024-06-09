using AutoFixture.Xunit2;
using FluentAssertions;
using MvvmApp.Core.Tests.TestHelpers;
using MvvmApp.Features.NavPage;
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
            [NoAutoProperties] MenuItem item1,
            [NoAutoProperties] MenuItem item2,
            [NoAutoProperties] NavPageViewModel vm,
            LoadedCommand sut)
        {
            //arrange
            vm.MenuItems = [item1, item2];

            //act
            sut.Execute(vm);

            //assert
            item1.IsSelected.Should().Be(true);
            item2.IsSelected.Should().Be(false);
        }
    }
}
