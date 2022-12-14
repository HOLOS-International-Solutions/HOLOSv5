﻿using H.Infrastructure;

namespace H.Core.Models
{
    public abstract class StorageTankBase : ModelBase
    {
        #region Fields
        
        private double _volumeRemainingInTank;
        private double _volumeOfManureAvailableForLandApplication;
        private double _totalOrganicNitrogenAvailableForLandApplication;
        private double _totalTanAvailableForLandApplication;
        private double _totalAmountOfCarbonInStoredManure;
        private double _totalAvailableManureNitrogenAvailableForLandApplication;
        private double _totalAvailableManureNitrogenAvailableForLandApplicationAfterAllLandApplications;
        private double _nitrogenSumOfAllManureApplicationsMade;
        private double _volumeSumOfAllManureApplicationsMade;

        #endregion

        #region Properties

        /// <summary>
        /// When user defines multiple years for a field history, there will need to be a tank for each year of the history
        /// </summary>
        public int Year { get; set; }

        /// <summary>
        /// The volume of manure or digestate remaining in the storage tank
        ///
        /// (1000 kg wet weight for solid manure, 1000 L for liquid manure)
        /// </summary>
        public double VolumeRemainingInTank
        {
            get => _volumeRemainingInTank;
            set => SetProperty(ref _volumeRemainingInTank, value);
        }

        public double TotalOrganicNitrogenAvailableForLandApplication
        {
            get => _totalOrganicNitrogenAvailableForLandApplication;
            set => SetProperty(ref _totalOrganicNitrogenAvailableForLandApplication, value);
        }

        public double TotalTanAvailableForLandApplication
        {
            get => _totalTanAvailableForLandApplication;
            set => SetProperty(ref _totalTanAvailableForLandApplication, value);
        }

        public double TotalAmountOfCarbonInStoredManure
        {
            get => _totalAmountOfCarbonInStoredManure;
            set => SetProperty(ref _totalAmountOfCarbonInStoredManure, value);
        }

        public double TotalAvailableManureNitrogenAvailableForLandApplication
        {
            get => _totalAvailableManureNitrogenAvailableForLandApplication;
            set => SetProperty(ref _totalAvailableManureNitrogenAvailableForLandApplication, value);
        }

        public double TotalAvailableManureNitrogenAvailableForLandApplicationAfterAllLandApplications
        {
            get => _totalAvailableManureNitrogenAvailableForLandApplicationAfterAllLandApplications;
            set => SetProperty(ref _totalAvailableManureNitrogenAvailableForLandApplicationAfterAllLandApplications, value);
        }

        public double NitrogenSumOfAllManureApplicationsMade
        {
            get => _nitrogenSumOfAllManureApplicationsMade;
            set => SetProperty(ref _nitrogenSumOfAllManureApplicationsMade, value, OnSumOfAllManureApplicationsMade);
        }

        public double VolumeSumOfAllManureApplicationsMade
        {
            get => _volumeSumOfAllManureApplicationsMade;
            set => SetProperty(ref _volumeSumOfAllManureApplicationsMade, value, OnVolumeSumOfAllManureApplicationsMade);
        }

        public double VolumeOfManureAvailableForLandApplication
        {
            get => _volumeOfManureAvailableForLandApplication;
            set => SetProperty(ref _volumeOfManureAvailableForLandApplication, value);
        }

        #endregion

        #region Public Methods

        public void ResetTank()
        {
            this.VolumeRemainingInTank = 0;
            this.TotalOrganicNitrogenAvailableForLandApplication = 0;
            this.TotalTanAvailableForLandApplication = 0;
            this.TotalAmountOfCarbonInStoredManure = 0;
            this.TotalAvailableManureNitrogenAvailableForLandApplication = 0;
            this.TotalAvailableManureNitrogenAvailableForLandApplicationAfterAllLandApplications = 0;
            this.NitrogenSumOfAllManureApplicationsMade = 0;
            this.VolumeSumOfAllManureApplicationsMade = 0;
            this.VolumeOfManureAvailableForLandApplication = 0;
        }

        #endregion

        #region Private Methods
        
        private void OnSumOfAllManureApplicationsMade()
        {
            this.TotalAvailableManureNitrogenAvailableForLandApplicationAfterAllLandApplications = this.TotalAvailableManureNitrogenAvailableForLandApplication - this.NitrogenSumOfAllManureApplicationsMade;
        }

        private void OnVolumeSumOfAllManureApplicationsMade()
        {
            this.VolumeRemainingInTank = this.VolumeOfManureAvailableForLandApplication - this.VolumeSumOfAllManureApplicationsMade;
        } 

        #endregion
    }
}