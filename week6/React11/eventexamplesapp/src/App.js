// src/App.js
import React, { Component } from "react";
import CurrencyConvertor from "./CurrencyConvertor";

class App extends Component {
  constructor(props) {
    super(props);
    this.state = {
      count: 0,
      message: "",
    };

    // Bind functions if needed
    this.handleDecrement = this.handleDecrement.bind(this);
    this.handleSyntheticEvent = this.handleSyntheticEvent.bind(this);
  }

  // Method 1: Increment counter
  handleIncrement = () => {
    this.setState({ count: this.state.count + 1 }, () => {
      this.sayHello();
    });
  };

  // Method 2: Say Hello
  sayHello = () => {
    this.setState({ message: "Hello! You clicked the Increment button." });
  };

  // Decrement counter
  handleDecrement() {
    this.setState({ count: this.state.count - 1, message: "" });
  }

  // Say welcome with argument
  sayWelcome = (msg) => {
    this.setState({ message: msg });
  };

  // Synthetic event
  handleSyntheticEvent(e) {
    e.preventDefault();
    this.setState({ message: "I was clicked" });
  }

  render() {
    return (
      <div className="App" style={{ padding: 20 }}>
        <h1>React Event Handling Example</h1>

        <h2>Counter: {this.state.count}</h2>
        <button onClick={this.handleIncrement}>Increment</button>
        <button onClick={this.handleDecrement}>Decrement</button>

        <br /><br />

        <button onClick={() => this.sayWelcome("Welcome to React!")}>
          Say Welcome
        </button>

        <br /><br />

        <button onClick={this.handleSyntheticEvent}>
          OnPress (Synthetic Event)
        </button>

        <p>{this.state.message}</p>

        <hr />
        <CurrencyConvertor />
      </div>
    );
  }
}

export default App;
