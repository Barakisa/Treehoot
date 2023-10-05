import React, { useEffect, useState } from "react";
import "../styles.css";
import { Link } from "react-router-dom";

export default function Host() {
  const [game, setGame] = useState([]);

  const fetchGame = async () => {
    const data = [
      "viktorina1",
      "viktorina2",
      "viktorina3",
      "viktorina4",
      "viktorina5",
      "viktorina6",
    ];
    console.log(data);
    setGame(data);
  };

  useEffect(() => {
    fetchGame();
  }, []);

  return (
    <div className="d-flex flex-column vh-100 justify-content-center align-items-center">
      <div className="text fs-3 mb-3">Select your game:</div>
      <div className="scroll-box">
        <div className="scroll-box-content fs-3">
          {game.map((value, index) => (
            <div key={index}>{value}</div>
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
