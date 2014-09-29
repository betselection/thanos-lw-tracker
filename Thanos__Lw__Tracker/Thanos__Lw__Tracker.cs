//  Thanos__Lw__Tracker.cs
//
//  Author:
//       Victor L. Senior (VLS) <betselection(&)gmail.com>
//
//  Web: 
//       http://betselection.cc/betsoftware/
//
//  Sources:
//       http://github.com/betselection/
//
//  Copyright (c) 2014 Victor L. Senior
//
//  This program is free software: you can redistribute it and/or modify
//  it under the terms of the GNU General Public License as published by
//  the Free Software Foundation, either version 3 of the License, or
//  (at your option) any later version.
//
//  This program is distributed in the hope that it will be useful,
//  but WITHOUT ANY WARRANTY; without even the implied warranty of
//  MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
//  GNU General Public License for more details.
//
//  You should have received a copy of the GNU General Public License
//  along with this program.  If not, see <http://www.gnu.org/licenses/>.

/// <summary>
/// Thanos Lw Tracker.
/// </summary>
namespace Thanos__Lw__Tracker
{
    // Directives
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>
    /// Thanos Lw Tracker class.
    /// </summary>
    public class Thanos__Lw__Tracker : Form
    {
        /// <summary>
        /// The tracker data grid view.
        /// </summary>
        private DataGridView trackerDataGridView;

        /// <summary>
        /// The roulette class instance.
        /// </summary>
        private Roulette roulette = new Roulette();

        /// <summary>
        /// The marshal object.
        /// </summary>
        private object marshal = null;

        /// <summary>
        /// The bet data grid view text box column.
        /// </summary>
        private DataGridViewTextBoxColumn registryDataGridViewTextBoxColumn;

        /// <summary>
        /// Set a bigger font for DataGrid rows
        /// </summary>
        private Font bigFont = new System.Drawing.Font(FontFamily.GenericMonospace, 15.75F, System.Drawing.FontStyle.Bold ^ FontStyle.Italic, System.Drawing.GraphicsUnit.Point, (byte)0);

        /// <summary>
        /// The thanos numbers list.
        /// </summary>
        private readonly List<int> thanosList = new List<int>() { 0, 1, 2, 3, 4, 5, 7, 8, 9, 10, 11, 12, 16, 17, 25, 26, 27, 28, 29, 30, 32, 33, 37 };

        /// <summary>
        /// The tracker history.
        /// </summary>
        private List<string> trackerHistory = new List<string>();

        /// <summary>
        /// Tracker as BindingList of SingleTracker (bound to DataGridView)
        /// </summary>
        private BindingList<SingleTracker> tracker = new BindingList<SingleTracker>();

        /// <summary>
        /// Initializes a new instance of the <see cref="Thanos__Lw__Tracker.Thanos__Lw__Tracker"/> class.
        /// </summary>
        public Thanos__Lw__Tracker()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            this.trackerDataGridView = new DataGridView();
            this.registryDataGridViewTextBoxColumn = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)this.trackerDataGridView).BeginInit();
            this.SuspendLayout();

            // trackerDataGridView
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.FromArgb(224, 224, 224);
            this.trackerDataGridView.AutoSize = true;
            this.trackerDataGridView.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.trackerDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.trackerDataGridView.Columns.AddRange(new DataGridViewColumn[]
                {
                    this.registryDataGridViewTextBoxColumn
                });
            this.trackerDataGridView.Dock = DockStyle.Fill;
            this.trackerDataGridView.Location = new System.Drawing.Point(0, 0);
            this.trackerDataGridView.Name = "trackerDataGridView";
            this.trackerDataGridView.RowHeadersVisible = false;
            this.trackerDataGridView.Size = new System.Drawing.Size(564, 40);
            this.trackerDataGridView.TabIndex = 0;

            // registryDataGridViewTextBoxColumn
            this.registryDataGridViewTextBoxColumn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            this.registryDataGridViewTextBoxColumn.HeaderText = "Registry";
            this.registryDataGridViewTextBoxColumn.Name = "registryDataGridViewTextBoxColumn";
            this.registryDataGridViewTextBoxColumn.DataPropertyName = "Registry";
            this.registryDataGridViewTextBoxColumn.ReadOnly = true;
            this.registryDataGridViewTextBoxColumn.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            this.registryDataGridViewTextBoxColumn.DefaultCellStyle.Font = this.bigFont;

            // ThanosLwTracker
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(564, 40);
            this.Controls.Add(this.trackerDataGridView);
            this.Name = "ThanosLwTracker";
            this.Text = "Thanos Lw Tracker";
            this.Load += new System.EventHandler(this.FormTracker_Load);
            ((System.ComponentModel.ISupportInitialize)this.trackerDataGridView).EndInit();
            this.ResumeLayout(false);

            // Set DataSource
            this.trackerDataGridView.DataSource = this.tracker;
        }

        /// <summary>
        /// Inits the instance.
        /// </summary>
        /// <param name="passedMarshal">Passed marshal.</param>
        public void Init(object passedMarshal)
        {
            // Set marshal
            this.marshal = passedMarshal;

            // Set icon
            this.Icon = (Icon)this.marshal.GetType().GetProperty("Icon").GetValue(this.marshal, null);

            // Show form
            this.Show();
        }

        /// <summary>
        /// Processes input.
        /// </summary>
        public void Input()
        {
            // Set last
            string last = (string)this.marshal.GetType().GetProperty("Last").GetValue(this.marshal, null);

            // Check for undo
            if (last == "-U")
            {
                /* Remove from Lw registry */ 

                // Remove last
                trackerHistory.RemoveAt(trackerHistory.Count - 1);

                // Update
                UpdateTrackerDataGridView();
            }
            else
            {
                /* Add current one */

                // Try to get roulette number
                int number = this.roulette.GetRouletteNumber(last);

                // Check it's good
                if (number > -1)
                {
                    // Compare against Thanos numbers
                    if (thanosList.Contains(number))
                    {
                        // Add w
                        trackerHistory.Add("w");
                    }
                    else
                    {
                        // Add L
                        trackerHistory.Add("L");
                    }
                }

                // Update
                UpdateTrackerDataGridView();
            }
        }

        /// <summary>
        /// Tracker form's entry point
        /// </summary>
        /// <param name="sender">Sender object.</param>
        /// <param name="e">Event arguments.</param>
        private void FormTracker_Load(object sender, EventArgs e)
        {
            // Populate tracker's base rows
            this.tracker.Add(new SingleTracker(string.Empty));
        }

        /// <summary>
        /// Updates the tracker data grid view.
        /// </summary>
        private void UpdateTrackerDataGridView()
        {
            // Update Lw tracker
            this.tracker[0].Registry = string.Join(string.Empty, this.trackerHistory.GetRange(this.trackerHistory.Count > 40 ? this.trackerHistory.Count - 40 : 0, this.trackerHistory.Count > 40 ? 40 : this.trackerHistory.Count).ToArray());

            // Refresh DataGridView
            this.trackerDataGridView.Refresh();
        }
    }
}

