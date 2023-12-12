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

  const activateGame = async (id) => {
    console.log(id);

    if (!(id in activeGameIds)) {
      setActiveGameIds([
        ...activeGameIds,
        id
      ]);
    }

    const response = await postMessage("https://localhost:7219/api/Quiz") ;

    console.log(response);
  };

  return (
    <div className="d-flex flex-column vh-100 justify-content-center align-items-center">
      <div className="text fs-3 mb-3">Select your game:</div>
      <div className="scroll-box">
        {game.map((quiz) => (
          <div
            key={quiz.id}
            className="d-flex"
          >
            <div>
              <div className="fs-3">{quiz.name}</div>
              <div className="d-flex flex-row align-items-start fs-6 mb-3">
                {quiz.description}
              </div>
            </div>
          ))}
            </div>
            {quiz.id in activeGameIds ? (
              <Button className="active-label" variant="success">
                Active
              </Button>
            ) : (
              <Button onClick={() => activateGame(quiz.id)} variant="secondary">
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
