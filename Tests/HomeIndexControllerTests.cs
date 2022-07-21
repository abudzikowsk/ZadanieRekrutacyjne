using Zadanie_rekrutacyjne_Aleksandra_Budzikowska.Controllers;
using Zadanie_rekrutacyjne_Aleksandra_Budzikowska.Models;

namespace Tests;

public class HomeIndexControllerTests
{
    [Test]
    public void Test1()
    {
        //Arange
        var controller = new HomeController();
        var viewModel = new HomeViewModel();

        //Act
        viewModel.Input = "[1,2,3,4,5,1,1]";
        controller.Index(viewModel);

        //Assert
        Assert.That(viewModel.Output, Is.EqualTo("[1]"));
    }

    [Test]
    public void Test2()
    {
        //Arange
        var controller = new HomeController();
        var viewModel = new HomeViewModel();

        //Act
        viewModel.Input = "[9,3,3,2,1,1,1,2,9,9,9]";
        controller.Index(viewModel);

        //Assert
        Assert.That(viewModel.Output, Is.EqualTo("[9,1]"));
    }

    [Test]
    public void Test3()
    {
        //Arange
        var controller = new HomeController();
        var viewModel = new HomeViewModel();

        //Act
        viewModel.Input = "[1,1,1,1,3,3,3,3,2,1,2,9,9,9]";
        controller.Index(viewModel);

        //Assert
        Assert.That(viewModel.Output, Is.EqualTo("[9,3,1]"));
    }

    [Test]
    public void Test4()
    {
        //Arange
        var controller = new HomeController();
        var viewModel = new HomeViewModel();

        //Act
        viewModel.Input = "[1,2,3,2,1,9,9,8]";
        controller.Index(viewModel);

        //Assert
        Assert.That(viewModel.Output, Is.EqualTo("[]"));
    }

    [Test]
    public void Test5()
    {
        //Arange
        var controller = new HomeController();
        var viewModel = new HomeViewModel();

        //Act
        viewModel.Input = "[112, he3,2,1,9,9,8]";
        controller.Index(viewModel);

        //Assert
        Assert.That(viewModel.Output, Is.EqualTo("Error"));
    }
}
