import React, { useEffect, useState } from "react";
import "../styles.css";
import { Link } from "react-router-dom";
import { Button } from "react-bootstrap";

export default function AltHost() {
  const [game, setGame] = useState([]);
  const [activeGameIdsAndCodes, setActiveGameIdsAndCodes] = useState([]); // New state for active game

  const fetchGame = async () => {
    const response = await fetch("https://localhost:7219/api/Quiz");
    const allQuizes = await response.json();
    setGame(allQuizes);
    console.log({ allQuizes });
  };

  useEffect(() => {
    fetchGame();
  }, []);

  const sendApiRequest = async (action, quizId) => {
    const requestBody = {
      code: 0, // Replace with the appropriate code
      id: quizId, // Replace with the appropriate ID
      action: action,
    };

    try {
      const response = await fetch("https://localhost:7219/api/Playground", {
        method: "PUT",
        headers: {
          "Content-Type": "application/json",
        },
        body: JSON.stringify(requestBody),
      });

      if (response.ok) {
        console.log(`Quiz ${action} successful.`);
      } else {
        console.error("Failed to update quiz.");
      }

      return response.json();
    } catch (error) {
      console.error("Error:", error);
    }
  };

  useEffect(() => {
    console.log({ activeGameIdsAndCodes });
  }, [activeGameIdsAndCodes]);

  const activateGame = async (id) => {
    const response = await sendApiRequest("Add", id);
    console.log({ response });
    if (response.success) {
      setActiveGameIdsAndCodes([
        ...activeGameIdsAndCodes,
        { id: response.id, code: response.code },
      ]);
    }
  };

  const deactivateGame = async (id) => {
    const response = await sendApiRequest("Remove", id);
    console.log({ response });
    if (response.success) {
      setActiveGameIdsAndCodes(
        activeGameIdsAndCodes.filter((game) => game.id !== id)
      );
    }
  };

  return (
    <div className="d-flex flex-column vh-100 justify-content-center align-items-center">
      <div className="text fs-3 mb-3">Select your game:</div>
      <div className="scroll-box">
        {game.map((quiz) => (
          <div key={quiz.id} className="d-flex justify-content-between p-2">
            <div>
              <div className="fs-3">{quiz.name}</div>
              <div className="d-flex flex-row align-items-start fs-6 mb-3">
                {quiz.description}
              </div>
            </div>
            <div className="d-flex flex-row justify-content-center align-items-center">
              {activeGameIdsAndCodes.some((item) => item.id === quiz.id) ? (
                <div className="d-flex flex-row justify-content-center align-items-center">
                  <Button
                    variant="danger"
                    onClick={() => deactivateGame(quiz.id)}
                  >
                    Deactivate
                  </Button>
                  <Button variant="primary" disabled>
                    Code:
                    <br />
                    <span style={{ userSelect: "text" }}>
                      {
                        activeGameIdsAndCodes.find(
                          (item) => item.id === quiz.id
                        )?.code
                      }
                    </span>
                  </Button>
                </div>
              ) : (
                <Button variant="success" onClick={() => activateGame(quiz.id)}>
                  Activate
                </Button>
              )}
            </div>
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
