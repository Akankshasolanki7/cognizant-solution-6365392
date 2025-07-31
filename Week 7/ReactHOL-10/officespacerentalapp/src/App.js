import React from 'react';


const offices = [
{
id: 1,
name: "Techno salt",
rent: 10000,
address: "123 Main Street, Bangalore",
image: "https://images.unsplash.com/photo-1506744038136-46273834b3fb?auto=format&fit=crop&w=400&q=80"
},
// {
// id: 2,
// name: "Business Land",
// rent: 9000,
// address: "456 Market Road, Mumbai",
// image: "https://images.unsplash.com/photo-1464983953574-0892a716854b?auto=format&fit=crop&w=400&q=80"
// },
{
id: 3,
name: "Startup Era",
rent: 11000,
address: "789 Tech Avenue, Hyderabad",
image: "https://images.unsplash.com/photo-1482062364825-616fd23b8fc1?auto=format&fit=crop&w=400&q=80"
}
];


const headingStyle = {
color: "#2c3e50",
textAlign: "center",
margin: "30px 0 20px 0"
};

function App() {
return (
<div>
{}
<h1 style={headingStyle}>Office Space Rental Portal</h1>

{}
<div style={{ display: "flex", justifyContent: "center", gap: "20px" }}>
{offices.map((office) => (
<div
key={office.id}
style={{
border: "1px solid #ccc",
borderRadius: "10px",
padding: "20px",
width: "250px",
boxShadow: "0 2px 8px rgba(0,0,0,0.1)"
}}
>
{}
<img
src={office.image}
alt={office.name}
style={{ width: "100%", borderRadius: "8px" }}
/>

{}
<h2>{office.name}</h2>
<p>
<strong>Rent:</strong>{" "}
<span
style={{
color: office.rent < 60000 ? "red" : "green",
fontWeight: "bold"
}}
>
₹{office.rent.toLocaleString()}
</span>
</p>
<p>
<strong>Address:</strong> {office.address}
</p>
</div>
))}
</div>
</div>
);
}

export default App;