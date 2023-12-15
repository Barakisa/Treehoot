import React, { useEffect, useReducer, useState } from "react";
import Timer from "../components/Timer";
import {
  reducer,
  INITIAL_STATE,
} from "../components/Reducers/FetchDataReducer";
import LoadingCircle from "../components/LoadingCircle";
import { useQuiz } from "../QuizContext";
import { useNavigate } from "react-router-dom";
import { useUser } from "../UserContext";

const TIME_LEFT = 5;

export default function Question() {
  const [state, dispatch] = useReducer(reducer, INITIAL_STATE);
  const { chosenQuestion, nextStage, setCurrentIndex, currentIndex } =
    useQuiz();
  const { calculateScore } = useUser();
  const [isChosenAnswerCorrect, setIsChosenAnswerCorrect] = useState(false);
  const navigate = useNavigate();

  const fetchData = async () => {
    try {
      //dummy json data for testing purposes
      const url = `https://localhost:7219/api/Answer/questionId/${chosenQuestion.id}`;
      const response = await fetch(url);
      if (response.ok) {
        const responseData = await response.json();
        console.log(responseData);
        dispatch({ type: "SET_DATA", payload: responseData });
        dispatch({ type: "NOT_LOADING" });
      } else {
        dispatch({ type: "NOT_LOADING" });
        dispatch({ type: "SET_ERROR", payload: response });
      }
    } catch (error) {
      dispatch({ type: "SET_ERROR", payload: error });
      dispatch({ type: "NOT_LOADING" });
    }
  };

  useEffect(() => {
    fetchData();
    const timeoutId = setTimeout(() => {
      setCurrentIndex((prev) => prev + 1);
      const hasEnded = nextStage();
      if (hasEnded) {
        navigate("/score");
      } else {
        navigate("/question_preview");
      }
    }, TIME_LEFT * 1000 + 500);
    return () => {
      clearTimeout(timeoutId);
    };
  }, []);

  const handleSelectedAnswer = (e) => {
    const selectedAnswerId = e.target.id;

    const isCorrect = state.data.some(
      (answer) => answer.id == selectedAnswerId && answer.isCorrect === true
    );
    if (isCorrect) calculateScore(isCorrect);
    setIsChosenAnswerCorrect(isCorrect);
  };

  return (
    <div className="d-flex flex-row justify-content-center align-items-center border border-3 border-primary-subtle rounded-4 vh-100">
      {!state.isLoading ? (
        state.data ? (
          <div className="d-flex flex-column justify-content-between align-items-center">
            <div className="d-flex flex-row mb-3 mt-3">
              <Timer timeLeft={TIME_LEFT} />
            </div>
            <div className="d-flex flex-row mb-3 mt-3">
              <span className="fs-2">{chosenQuestion.name}</span>
            </div>
            <div className="d-flex flex-row mb-2 mt-2">
              {/* Display image from fetched data */}
              <img
                src="https://media.istockphoto.com/id/1486505577/photo/question-mark-on-green-background.webp?b=1&s=170667a&w=0&k=20&c=wWkJyJJ_cWmT5zeZ3VYMLXL1v0EoJK7DynrngmLjE0I="
                alt="Image for question"
                style={{ width: "35rem" }}
              />
            </div>
            <div className="d-flex flex-column justify-content-between align-items-start mb-3 mt-3">
              {state.data.map((button) => (
                <div key={button.id} className="d-flex flex-row">
                  <div className="d-flex form-check fs-4 p-1 align-items-center">
                    <input
                      className="form-check-input me-4"
                      type="radio"
                      name="answerRadio"
                      id={button.id}
                      style={{ cursor: "pointer" }}
                      onChange={(e) => handleSelectedAnswer(e)}
                    />
                    <label
                      className="form-check-label text-break text-start"
                      for={`answerRadio${button.id}`}
                      style={{ cursor: "pointer" }}
                    >
                      {button.text}
                    </label>
                  </div>
                </div>
              ))}
            </div>
          </div>
        ) : (
          <span className="fs-3">
            {state.errorMessage ? state.errorMessage : "An error has occured!"}
          </span>
        )
      ) : (
        <LoadingCircle />
      )}
    </div>
  );
}
