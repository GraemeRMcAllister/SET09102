// <copyright file="EmailMessageTest.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBMFS.Models;

namespace NBMFS.Models.Tests
{
    [TestClass]
    [PexClass(typeof(EmailMessage))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class EmailMessageTest
    {

        [PexMethod]
        internal EmailMessage Constructor(
            string id,
            string sender,
            string body
        )
        {
            EmailMessage target = new EmailMessage(id, sender, body);
            return target;
            // TODO: add assertions to method EmailMessageTest.Constructor(String, String, String)
        }
    }
}
