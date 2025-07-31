
function UserPage({ onBook }) {
return (
<div>
<h2>Welcome, User!</h2>
<p>You can book tickets for the following flights:</p>
<ul>
<li>
Flight AI-101: Delhi → Mumbai, 10:00 AM
<button onClick={() => onBook("AI-101")}>Book</button>
</li>
<li>
Flight AI-202: Mumbai → Bangalore, 2:00 PM
<button onClick={() => onBook("AI-202")}>Book</button>
</li>
<li>
Flight AI-303: Bangalore → Chennai, 6:00 PM
<button onClick={() => onBook("AI-303")}>Book</button>
</li>
</ul>
</div>
);
}

export default UserPage;