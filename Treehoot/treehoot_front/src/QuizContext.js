import React, { createContext, useContext, useState, useEffect } from "react";
import { useNavigate } from "react-router-dom";

const QuizContext = createContext();

export function QuizProvider({ children }) {
  const [quizId, setQuizId] = useState(null);
  const [stageId, setStageId] = useState(5);
  const [currentStage, setCurrentStage] = useState(null);
  const [chosenQuestion, setChosenQuestion] = useState({ id: null, name: "" });
  const [currentIndex, setCurrentIndex] = useState(null);

  useEffect(() => {
    // Update local storage whenever any of the state variables change
    localStorage.setItem("quizId", JSON.stringify(quizId));
    localStorage.setItem("stageId", JSON.stringify(stageId));
    localStorage.setItem("currentStage", JSON.stringify(currentStage));
    localStorage.setItem("currentIndex", JSON.stringify(currentIndex));
  }, [quizId, stageId, currentStage, currentIndex]);

  const nextStage = () => {
    console.log("stageid", stageId);
    console.log("current index", currentIndex);
    // Ensure that stageId is an array before using findIndex
    if (currentIndex < stageId.length) {
      const nextStageId = stageId[currentIndex];
      setCurrentStage(nextStageId);
      return false;
    } else {
      return true;

      //133760
    }
  };

  return (
    <QuizContext.Provider
      value={{
        quizId,
        setQuizId,
        stageId,
        setStageId,
        currentStage,
        setCurrentStage,
        chosenQuestion,
        setChosenQuestion,
        nextStage,
        currentIndex,
        setCurrentIndex,
      }}
    >
      {children}
    </QuizContext.Provider>
  );
}

export function useQuiz() {
  return useContext(QuizContext);
}
