// src/CurrencyConvertor.js
import React, { Component } from "react";

class CurrencyConvertor extends Component {
  constructor(props) {
    super(props);
    this.state = {
      rupees: "",
      euro: null
    };
  }

  handleInputChange = (e) => {
    this.setState({ rupees: e.target.value });
  };

  handleSubmit = (e) => {
    e.preventDefault();
    const rupeeValue = parseFloat(this.state.rupees);
    if (!isNaN(rupeeValue)) {
      const euro = (rupeeValue / 90).toFixed(2); // assuming 1 Euro = 90 INR
      this.setState({ euro });
    }
  };

  render() {
    return (
      <div>
        <h2>Currency Convertor (INR ➡️ EUR)</h2>
        <form onSubmit={this.handleSubmit}>
          <input
            type="number"
            placeholder="Enter amount in INR"
            value={this.state.rupees}
            onChange={this.handleInputChange}
          />
          <button type="submit">Convert</button>
        </form>
        {this.state.euro && (
          <p>{this.state.rupees} INR = {this.state.euro} EUR</p>
        )}
      </div>
    );
  }
}

export default CurrencyConvertor;
