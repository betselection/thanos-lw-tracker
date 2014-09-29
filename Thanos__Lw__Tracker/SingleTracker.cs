//  SingleTracker.cs
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
/// Single tracker.
/// </summary>
namespace Thanos__Lw__Tracker
{
    // Directives
    using System;

    /// <summary>
    /// Single tracker class.
    /// </summary>
    public class SingleTracker
    {
        /// <summary>
        /// The location.
        /// </summary>
        private string registry;

        /// <summary>
        /// Initializes a new instance of the <see cref="Thanos__Lw__Tracker.SingleTracker"/> class.
        /// </summary>
        /// <param name="registry">Passed registry.</param>
        public SingleTracker(string registry)
        {
            // Set location
            this.registry = registry;
        }

        /// <summary>
        /// Gets or sets the location.
        /// </summary>
        /// <value>The location.</value>
        public string Registry
        {
            get
            {
                return this.registry;
            }

            set
            {
                this.registry = value;
            }
        }
    }
}