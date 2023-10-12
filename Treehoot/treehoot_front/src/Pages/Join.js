import React from "react";
import { Link } from "react-router-dom";
import "../styles.css";
import { useState } from "react";
import { useEffect } from "react";

export default function Join() {
  const [game, setGame] = useState();

  const fetchGame = async () => {
    const response = await fetch("https://localhost:7219/api/Quiz");
    const data = await response.json();
    const quizIds = data.stages;
    setGame(quizIds);
  };

  useEffect(() => {
    fetchGame();
  }, []);
  return (
    <div className=" d-flex flex-column align-items-center justify-content-center vh-100">
      <div>
        <input placeHolder=" Enter game code" className="input-box" />
      </div>
      <div>
        <Link
          quizId={game}
          to="/question_preview"
          className="home-page-buttons btn btn-outline-primary fs-2 mt-5"
        >
          Confirm
        </Link>
      </div>
    </div>
  );
}
