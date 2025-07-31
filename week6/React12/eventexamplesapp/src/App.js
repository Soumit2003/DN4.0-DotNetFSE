import React, { useState } from "react";
import GuestPage from "./components/GuestPage";
import UserPage from "./components/UserPage";

function App() {
  const [isLoggedIn, setIsLoggedIn] = useState(false);

  // Element variable for view
  let content;
  if (isLoggedIn) {
    content = <UserPage />;
  } else {
    content = <GuestPage />;
  }

  return (
    <div className="App" style={{ padding: "20px" }}>
      <h1>✈️ Ticket Booking App</h1>
      <div>
        {isLoggedIn ? (
          <button onClick={() => setIsLoggedIn(false)}>Logout</button>
        ) : (
          <button onClick={() => setIsLoggedIn(true)}>Login</button>
        )}
      </div>
      <hr />
      {content}
    </div>
  );
}

export default App;
