﻿using System;
using H.Core.Emissions.Results;
using H.Core.Models;
using H.Core.Models.LandManagement.Fields;
using System.Collections.Generic;
using H.Core.Services.Animals;

namespace H.Core.Calculators.Carbon
{
    public abstract partial class CarbonCalculatorBase
    {
        #region Fields

        protected DigestateService _digestateService = new DigestateService();

        #endregion

        #region Constructors

        protected CarbonCalculatorBase()
        {
            this.AnimalComponentEmissionsResults = new List<AnimalComponentEmissionsResults>();
        }

        #endregion

        #region Properties

        public List<AnimalComponentEmissionsResults> AnimalComponentEmissionsResults { get; set; }

        #endregion

        #region Methods

        /// <summary>
        /// Equation 2.2.2-26
        /// 
        /// Calculate amount of carbon input from all manure applications in a year.
        /// </summary>
        /// <returns>The amount of carbon input during the year (kg C ha^-1)</returns>
        public double CalculateManureCarbonInputPerHectare(
            CropViewItem viewItem)
        {
            return viewItem.GetTotalCarbonFromAppliedManure() / viewItem.Area;
        }

        /// <summary>
        /// Equation 4.9.7-1
        /// Equation 4.9.7-2
        /// Equation 4.9.7-5
        /// 
        /// Calculate amount of carbon input from all digestate applications in a year.
        /// </summary>
        /// <returns>The amount of carbon input during the year (kg C ha^-1)</returns>
        public double CalculateDigestateCarbonInputPerHectare(
            CropViewItem viewItem,
            Farm farm)
        {
            var result = 0d;

            foreach (var digestateApplicationViewItem in viewItem.DigestateApplicationViewItems)
            {
                result += digestateApplicationViewItem.AmountOfCarbonAppliedPerHectare;
            }

            return result;
        }

        #endregion
    }
}