import React, { Component } from 'react';
import CurrencyConvertor from './CurrencyConvertor';

class App extends Component {
constructor(props) {
super(props);
this.state = {
counter: 0,
message: ''
};

this.handleWelcome = this.handleWelcome.bind(this);
}

increment = () => {
this.setState(prevState => ({ counter: prevState.counter + 1 }));
this.sayHello();
this.sayMessage("Incremented!");
};

decrement = () => {
this.setState(prevState => ({ counter: prevState.counter - 1 }));
};

sayHello = () => {
this.setState({ message: "Hello! " });
};

sayMessage = (msg) => {
this.setState(prev => ({ message: (prev.message || "") + msg }));
};

handleWelcome(msg) {
alert(msg);
}

handleSyntheticEvent = (e) => {

alert("I was clicked");
};

render() {
return (
<div style={{ margin: 30 }}>
<h2>React Event Handling Examples</h2>
<div style={{ marginBottom: 20 }}>
<h3>Counter: {this.state.counter}</h3>
<button onClick={this.increment}>Increment</button>
<button onClick={this.decrement} style={{ marginLeft: 10 }}>Decrement</button>
<div style={{ marginTop: 10, color: 'green' }}>{this.state.message}</div>
</div>

<div style={{ marginBottom: 20 }}>
<button onClick={() => this.handleWelcome("welcome")}>Say Welcome</button>
</div>

<div style={{ marginBottom: 20 }}>
<button onClick={this.handleSyntheticEvent}>Synthetic Event: OnPress</button>
</div>

<CurrencyConvertor />
</div>
);
}
}

export default App;