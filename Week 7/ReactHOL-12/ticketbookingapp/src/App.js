import React, { useState } from 'react';
import GuestPage from './Component/GuestPage';
import UserPage from './Component/UserPage';

function App() {
const [isLoggedIn, setIsLoggedIn] = useState(false);
const [bookingMsg, setBookingMsg] = useState('');


let AuthButton;
if (isLoggedIn) {
AuthButton = <button onClick={() => setIsLoggedIn(false)}>Logout</button>;
} else {
AuthButton = <button onClick={() => setIsLoggedIn(true)}>Login</button>;
}


const handleBook = (flight) => {
setBookingMsg(`Ticket booked for flight ${flight}!`);
setTimeout(() => setBookingMsg(''), 2000);
};

return (
<div style={{ maxWidth: 500, margin: "40px auto", padding: 20, border: "1px solid #ccc", borderRadius: 10 }}>
<h1>Ticket Booking App</h1>
{AuthButton}
<hr />
{isLoggedIn ? <UserPage onBook={handleBook} /> : <GuestPage />}
{bookingMsg && <div style={{ color: "green", marginTop: 20 }}>{bookingMsg}</div>}
</div>
);
}

export default App;