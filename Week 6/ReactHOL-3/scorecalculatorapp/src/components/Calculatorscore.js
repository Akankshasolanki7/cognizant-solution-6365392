import React, { useState } from "react";
import "../Stylesheets/mystyle.css";

function Calculatorscore() {
  const [name, setName] = useState("");
  const [school, setSchool] = useState("");
  const [total, setTotal] = useState("");
  const [goal, setGoal] = useState("");
  const [average, setAverage] = useState(null);

  const handleSubmit = (e) => {
    e.preventDefault();
    if (total && goal) {
      setAverage(((parseFloat(total) + parseFloat(goal)) / 2).toFixed(2));
    }
  };

  return (
    <div className="score-container">
      <h2>Student Score Calculator</h2>
      <form onSubmit={handleSubmit}>
        <input
          type="text"
          placeholder="Name"
          value={name}
          onChange={(e) => setName(e.target.value)}
          required
        />
        <input
          type="text"
          placeholder="School"
          value={school}
          onChange={(e) => setSchool(e.target.value)}
          required
        />
        <input
          type="number"
          placeholder="Total"
          value={total}
          onChange={(e) => setTotal(e.target.value)}
          required
        />
        <input
          type="number"
          placeholder="Goal"
          value={goal}
          onChange={(e) => setGoal(e.target.value)}
          required
        />
        <button type="submit">Calculate Average</button>
      </form>
      {average && (
        <div className="result">
          <p>
            {name} from {school} has an average score of {average}.
          </p>
        </div>
      )}
    </div>
  );
}
export default Calculatorscore;