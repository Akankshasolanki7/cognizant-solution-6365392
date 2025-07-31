import React from 'react';

const T20players = ["Rohit Sharma", "Virat Kohli", "Suryakumar Yadav", "Rishabh Pant"];
const RanjiTrophyPlayers = ["Cheteshwar Pujara", "Ajinkya Rahane", "Prithvi Shaw", "Hanuma Vihari"];


const mergedPlayers = [...T20players, ...RanjiTrophyPlayers];

const IndianPlayers = () => {

const oddTeam = mergedPlayers.filter((_, idx) => idx % 2 === 0);
const evenTeam = mergedPlayers.filter((_, idx) => idx % 2 !== 0);

return (
<div>
<h2>Merged Players</h2>
<ul>
{mergedPlayers.map((name, idx) => <li key={idx}>{name}</li>)}
</ul>
<h3>Odd Team Players (Destructured)</h3>
<ul>
{oddTeam.map((name, idx) => <li key={idx}>{name}</li>)}
</ul>
<h3>Even Team Players (Destructured)</h3>
<ul>
{evenTeam.map((name, idx) => <li key={idx}>{name}</li>)}
</ul>
</div>
);
};

export default IndianPlayers;