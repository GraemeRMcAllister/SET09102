// <copyright file="TweetMessageTest.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBMFS.Models;

namespace NBMFS.Models.Tests
{
    [TestClass]
    [PexClass(typeof(TweetMessage))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class TweetMessageTest
    {

        [PexMethod]
        internal TweetMessage Constructor(
            string id,
            string sender,
            string body
        )
        {
            TweetMessage target = new TweetMessage(id, sender, body);
            return target;
            // TODO: add assertions to method TweetMessageTest.Constructor(String, String, String)
        }
    }
}
