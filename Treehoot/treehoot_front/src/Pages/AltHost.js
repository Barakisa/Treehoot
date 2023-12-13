import React, { useEffect, useState } from "react";
import "../styles.css";
import { Link } from "react-router-dom";
import { Button } from "react-bootstrap";


export default function AltHost() {
  const [game, setGame] = useState([]);
  const [activeGameIds, setActiveGameIds] = useState([]); // New state for active game

  const fetchGame = async () => {
    const response = await fetch("https://localhost:7219/api/Quiz");
    const data = await response.json();
    setGame(data);
    console.log(data);
  };

  useEffect(() => {
    fetchGame();
  }, []);

  const activateGame = (id) => {
    if (activeGameIds.includes(id)) {
      setActiveGameIds(activeGameIds.filter((gameId) => gameId !== id));
    } else {
      setActiveGameIds([...activeGameIds, id]);
    }

    console.log(activeGameIds);
    // Send the quiz ID to your API endpoint here
  };

  return (
    <div className="d-flex flex-column vh-100 justify-content-center align-items-center">
      <div className="text fs-3 mb-3">Select your game:</div>
      <div className="scroll-box">
        {game.map((quiz) => (
          <div
            key={quiz.id}
            className="d-flex justify-content-between"
          >
            <div>
              <div className="fs-3">{quiz.name}</div>
              <div className="d-flex flex-row align-items-start fs-6 mb-3">
                {quiz.description}
              </div>
            </div>
            {activeGameIds.includes(quiz.id) ? (
              <>
                <Button variant="danger" onClick={() => activateGame(quiz.id)}>
                  Deactivate
                </Button>
                <Button variant="success" disabled>
                  Active
                </Button>
              </>
            ) : (
              <Button variant="success" onClick={() => activateGame(quiz.id)}>
                Activate
              </Button>
            )}
          </div>
        ))}
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
