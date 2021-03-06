// <copyright file="MessageTest.cs">Copyright ©  2018</copyright>
using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBMFS.Models;

namespace NBMFS.Models.Tests
{
    /// <summary>This class contains parameterized unit tests for Message</summary>
    [PexClass(typeof(Message))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [TestClass]
    public partial class MessageTest
    {
    }
}
