// <copyright file="SmsMessageTest.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBMFS.Models;

namespace NBMFS.Models.Tests
{
    [TestClass]
    [PexClass(typeof(SmsMessage))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class SmsMessageTest
    {

        [PexMethod]
        internal SmsMessage Constructor(
            string id,
            string sender,
            string body
        )
        {
            SmsMessage target = new SmsMessage(id, sender, body);
            return target;
            // TODO: add assertions to method SmsMessageTest.Constructor(String, String, String)
        }
    }
}
