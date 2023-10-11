import React, { useEffect, useState } from "react";
import "../styles.css";
import { Link } from "react-router-dom";

export default function Host() {
  const [game, setGame] = useState([]);

  const fetchGame = async () => {
    const response = await fetch("https://localhost:7219/api/Quiz");
    const data = await response.json();
    setGame(data);
    console.log(data);
  };

  useEffect(() => {
    fetchGame();
  }, []);

  return (
    <div className="d-flex flex-column vh-100 justify-content-center align-items-center">
      <div className="text fs-3 mb-3">Select your game:</div>
      <div className="scroll-box">
        <div className="scroll-box-content">
          {game.map((quiz) => (
            <div key={quiz.id}>
              <div className="fs-3">{quiz.name}</div>
              <div className="d-flex flex-row align-items-start fs-6 mb-3">
                {quiz.description}
              </div>
            </div>
          ))}
        </div>
      </div>
      <div className="text fs-3 mt-1">Or</div>
      <div>
        <Link
          to="/new-game"
          className="new-game-button mt-3 btn btn-outline-primary fs-3 "
        >
          Create new Game
        </Link>
      </div>
    </div>
  );
}
