import React, { useState } from 'react';
import PlayersList from './PLayersList';
import IndianPlayers from './IndianPlayers';

function App() {
const [flag, setFlag] = useState(true);

return (
<div>
<button onClick={() => setFlag(f => !f)}>
Toggle Component (Flag is {flag ? "true" : "false"})
</button>
{flag ? <PlayersList /> : <IndianPlayers />}
</div>
);
}

export default App;