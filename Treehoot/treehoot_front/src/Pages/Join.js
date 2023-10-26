import React from "react";
import { Link } from "react-router-dom";
import "../styles.css";
import { useState } from "react";
import { useEffect } from "react";
import { useQuiz } from "../QuizContext";

export default function Join() {
  const { setQuizId, setStageId } = useQuiz();

  const fetchGame = async () => {
    const response = await fetch("https://localhost:7219/api/Quiz/1");
    const data = await response.json();
    setQuizId(data.id);
    const stageResponse = await fetch(
      `https://localhost:7219/api/Stage/quizId/${data.id}`
    );
    const stageData = await stageResponse.json();
    setStageId(stageData.id);
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
          to="/question_preview"
          className="home-page-buttons btn btn-outline-primary fs-2 mt-5"
        >
          Confirm
        </Link>
      </div>
    </div>
  );
}
