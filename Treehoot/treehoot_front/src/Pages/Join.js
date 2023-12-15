import React from "react";
import { Link, useNavigate } from "react-router-dom";
import "../styles.css";
import { useState } from "react";
import { useEffect } from "react";
import { useQuiz } from "../QuizContext";

export default function Join() {
  const { setQuizId, setStageId, setCurrentStage, setCurrentIndex } = useQuiz();
  const [input, setInput] = useState("");
  const navigate = useNavigate();

  const fetchGame = async () => {
    try {
      const response = await fetch(
        `https://localhost:7219/api/Quiz/code/${input}`
      );

      if (response.ok) {
        const data = await response.json();
        setQuizId(data.id);
        const stageResponse = await fetch(
          `https://localhost:7219/api/Stage/quizId/${data.id}`
        );
        if (stageResponse.ok) {
          const stageData = await stageResponse.json();
          const idArray = stageData.map(({ id }) => id);
          setStageId(idArray);
          console.log("stage id array ", idArray);
          setCurrentStage(stageData[0].id);
          setCurrentIndex(1);
        } else {
          console.log("fetch request failed!");
        }
      } else {
        console.log("fetch request failed!");
      }
    } catch (error) {
      console.error(error);
    }
  };

  const handleClick = () => {
    fetchGame();
    navigate("/question_preview");
  };
  return (
    <div className=" d-flex flex-column align-items-center justify-content-center vh-100">
      <div>
        <input
          value={input}
          onChange={(e) => setInput(e.target.value)}
          placeholder="Enter game code"
          className="input-box"
        />
      </div>
      <div>
        <button
          onClick={handleClick}
          className="home-page-buttons btn btn-outline-primary fs-2 mt-5"
        >
          Confirm
        </button>
      </div>
    </div>
  );
}
