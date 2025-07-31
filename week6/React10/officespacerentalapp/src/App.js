import React from "react";
import "./App.css";

function App() {
  const heading = <h1>Office Space Rental Listings</h1>;

  const imageURL = "https://via.placeholder.com/600x300?text=Office+Space";

  const office = {
    name: "Tech Park Tower",
    rent: 75000,
    address: "Block 5, Sector 62, Noida"
  };

  const officeList = [
    {
      name: "Alpha Workspace",
      rent: 55000,
      address: "Salt Lake Sector V, Kolkata"
    },
    {
      name: "Beta Tech Hub",
      rent: 62000,
      address: "Manyata Tech Park, Bangalore"
    },
    {
      name: "Gamma Heights",
      rent: 48000,
      address: "Cyber City, Gurugram"
    }
  ];

  return (
    <div className="App">
      {heading}

      <img src={imageURL} alt="Office Space" style={{ width: "100%", height: "auto" }}
