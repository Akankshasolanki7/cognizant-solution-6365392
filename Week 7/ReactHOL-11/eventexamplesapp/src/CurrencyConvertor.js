import React, { Component } from 'react';

class CurrencyConvertor extends Component {
constructor(props) {
super(props);
this.state = {
rupees: '',
euro: '',
direction: 'INRtoEURO'
};
}

handleInputChange = (e) => {
this.setState({ [e.target.name]: e.target.value });
};

handleDirectionChange = (e) => {
this.setState({ direction: e.target.value, rupees: '', euro: '' });
};

handleSubmit = (e) => {
e.preventDefault(); // Synthetic event
const { rupees, euro, direction } = this.state;
if (direction === 'INRtoEURO' && rupees) {
// Example: 1 Euro = 90 INR
this.setState({ euro: (parseFloat(rupees) / 90).toFixed(2) });
} else if (direction === 'EUROtoINR' && euro) {
this.setState({ rupees: (parseFloat(euro) * 90).toFixed(2) });
}
};

render() {
const { rupees, euro, direction } = this.state;
return (
<div style={{ marginTop: 30 }}>
<h3>Currency Convertor</h3>
<form onSubmit={this.handleSubmit}>
<div>
<label>
<input
type="radio"
value="INRtoEURO"
checked={direction === "INRtoEURO"}
onChange={this.handleDirectionChange}
/>
Rupees to Euro
</label>
<label style={{ marginLeft: 10 }}>
<input
type="radio"
value="EUROtoINR"
checked={direction === "EUROtoINR"}
onChange={this.handleDirectionChange}
/>
Euro to Rupees
</label>
</div>
{direction === "INRtoEURO" ? (
<input
type="number"
name="rupees"
placeholder="Enter Rupees"
value={rupees}
onChange={this.handleInputChange}
required
style={{ marginTop: 10 }}
/>
) : (
<input
type="number"
name="euro"
placeholder="Enter Euro"
value={euro}
onChange={this.handleInputChange}
required
style={{ marginTop: 10 }}
/>
)}
<button type="submit" style={{ marginLeft: 10 }}>Convert</button>
</form>
<div style={{ marginTop: 10 }}>
{direction === "INRtoEURO" && euro && (
<span>{rupees} INR = {euro} Euro</span>
)}
{direction === "EUROtoINR" && rupees && (
<span>{euro} Euro = {rupees} INR</span>
)}
</div>
</div>
);
}
}
export default CurrencyConvertor;