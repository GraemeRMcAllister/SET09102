// <copyright file="SIREmailTest.cs">Copyright ©  2018</copyright>

using System;
using Microsoft.Pex.Framework;
using Microsoft.Pex.Framework.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using NBMFS.Models;

namespace NBMFS.Models.Tests
{
    [TestClass]
    [PexClass(typeof(SIREmail))]
    [PexAllowedExceptionFromTypeUnderTest(typeof(ArgumentException), AcceptExceptionSubtypes = true)]
    [PexAllowedExceptionFromTypeUnderTest(typeof(InvalidOperationException))]
    public partial class SIREmailTest
    {

        [PexMethod]
        [PexAllowedException(typeof(Exception))]
        internal SIREmail Constructor(
            string id,
            string sender,
            string subject,
            string noi,
            string sortcode,
            string body
        )
        {
            SIREmail target = new SIREmail(id, sender, subject, noi, sortcode, body);
            return target;
            // TODO: add assertions to method SIREmailTest.Constructor(String, String, String, String, String, String)
        }
    }
}
