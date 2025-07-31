import React from 'react';

const players = [
{ name: "Rohit Sharma", score: 90 },
{ name: "Shubman Gill", score: 65 },
{ name: "Virat Kohli", score: 90 },
{ name: "Shreyas Iyer", score: 45 },
{ name: "KL Rahul", score: 55 },
{ name: "Hardik Pandya", score: 65 },
{ name: "Ravindra Jadeja", score: 80 },
{ name: "Kuldeep Yadav", score: 35 },
{ name: "Mohammed Shami", score: 25 },
{ name: "Jasprit Bumrah", score: 70 },
{ name: "Mohammed Siraj", score: 65 }
];

const PlayersList = () => {
const allPlayers = players.map((p, idx) => (
<li key={idx}>{p.name} - {p.score}</li>
));


const below70 = players.filter(p => p.score < 70);

return (
<div>
<h2>All Players</h2>
<ul>{allPlayers}</ul>
<h2>Players with Score Below 70</h2>
<ul>
{below70.map((p, idx) => (
<li key={idx}>{p.name} - {p.score}</li>
))}
</ul>
</div>
);
};

export default PlayersList;