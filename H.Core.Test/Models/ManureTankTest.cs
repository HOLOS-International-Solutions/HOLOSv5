﻿using System;
using H.Core.Converters;
using H.Core.Emissions.Results;
using H.Core.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace H.Core.Test.Models
{
    [TestClass]
    public class ManureTankTest : UnitTestBase
    {
        #region Fields

        private ManureTank _sut;

        #endregion

        #region Initialization

        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
        }

        [TestInitialize]
        public void TestInitialize()
        {
            _sut = new ManureTank();
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }

        #endregion

        #region Tests

        [TestMethod]
        public void GetVolumeCreatedOnDateTest()
        {

        }

        [TestMethod]
        public void AddDailyResultToTankTest()
        {
            var groupEmissionsByDay = base.GetGroupEmissionsByDay();

            var targetDate = new DateTime(DateTime.Now.Year, 5, 1);
            groupEmissionsByDay.DateTime = targetDate;

            _sut.AddDailyResultToTank(groupEmissionsByDay);

            var result = _sut.GetVolumeCreatedOnDate(targetDate);

            Assert.AreEqual(100 * 1000, result);
        }

        #endregion
    }
}