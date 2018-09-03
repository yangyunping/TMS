using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using GoldenLady.Dress.Utils;
using GoldenLady.Dress.View.Template;
using GoldenLady.Standard.Dress;
using GoldenLady.Utility;

namespace GoldenLady.Dress.View
{
    public partial class FrmCrossReservation : Form
    {
        public FrmCrossReservation()
        {
            InitializeComponent();
            InitControl();
            BindEvents();
        }

        private readonly CrossReservation _crossReservationToNew = new CrossReservation();
        private CrossReservation _selectedCrossReservation;

        private CrossReservation SelectedCrossReservation
        {
            get { return _selectedCrossReservation; }
            set
            {
                _selectedCrossReservation = value;
                OnSelectedCrossReservationCahenged();
            }
        }

        private void OnSelectedCrossReservationCahenged()
        {
            btnDelete.Enabled = null != SelectedCrossReservation;
        }
        private void OnCrossReservationToNewChanged()
        {
            btnNew.Enabled = _crossReservationToNew.CrossVenueID > 0 && _crossReservationToNew.VenueID > 0;
        }

        private void BindEvents()
        {
            lstVenue.SelectedIndexChanged += (sender, args) =>
            {
                Venue venue = (Venue)lstVenue.SelectedItem;
                int venueID = null == venue ? 0 : venue.ID;
                _crossReservationToNew.VenueID = venueID;
                OnCrossReservationToNewChanged();
                LoadCrossVenue(venueID);
            };
            lstCrossVenue.SelectedIndexChanged += (sender, args) => SelectedCrossReservation = (CrossReservation)lstCrossVenue.SelectedItem;
            cmbVenue.SelectedIndexChanged += (sender, args) =>
            {
                Venue venue = (Venue)cmbVenue.SelectedItem;
                int venueID = null == venue ? 0 : venue.ID;
                string venueName = null == venue ? null : venue.Name;
                _crossReservationToNew.CrossVenueID = venueID;
                _crossReservationToNew.CrossVenue = venueName;
                OnCrossReservationToNewChanged();
            };
        }
        private void InitControl()
        {
            btnDelete.Enabled = false;
            btnNew.Enabled = false;
        }
        private void OnCmbVenueSelectedIndexChanged()
        {
            Venue venue = (Venue)cmbVenue.SelectedItem;
            int venueID = null == venue ? 0 : venue.ID;
            string venueName = null == venue ? null : venue.Name;
            _crossReservationToNew.CrossVenueID = venueID;
            _crossReservationToNew.CrossVenue = venueName;
            OnCrossReservationToNewChanged();
        }

        private void LoadCrossVenue(int venueID)
        {
            lstCrossVenue.DataSource = DressManager.GetCrossReservations(venueID).ToList();
            SelectedCrossReservation = (CrossReservation)lstCrossVenue.SelectedItem;
        }
        private void LoadVenue()
        {
            lstVenue.DataSource = DressManager.GetVenues().ToList();
            cmbVenue.DataSource = DressManager.GetVenues().ToList();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                DressManager.DeleteCrossReservation(SelectedCrossReservation);
                LoadCrossVenue(SelectedCrossReservation.VenueID);
            }
            catch(Exception ex)
            {
                MessageBoxEx.Error(ex.Message);
            }
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            try
            {
                DressManager.NewCrossReservation(_crossReservationToNew);
                LoadCrossVenue(_crossReservationToNew.VenueID);
            }
            catch(Exception ex)
            {
                MessageBoxEx.Error(ex.Message);
            }
        }
        private void FrmCrossReservation_Load(object sender, EventArgs e)
        {
            LoadVenue();
        }
    }
}