import React from "react";

function UserPage() {
  return (
    <div>
      <h2>Flight Booking (User View)</h2>
      <ul>
        <li>
          Indigo 6E-123 | Delhi to Mumbai | 9:00 AM
          <button>Book Now</button>
        </li>
        <li>
          Air India AI-203 | Kolkata to Bangalore | 11:30 AM
          <button>Book Now</button>
        </li>
        <li>
          SpiceJet SG-505 | Chennai to Pune | 3:45 PM
          <button>Book Now</button>
        </li>
      </ul>
    </div>
  );
}

export default UserPage;
