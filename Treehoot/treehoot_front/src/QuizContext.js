import React, { createContext, useContext, useState } from "react";

const QuizContext = createContext();

export function QuizProvider({ children }) {
  const [quizId, setQuizId] = useState(null);
  const [stageId, setStageId] = useState(null);
  const [currentStage, setCurrentStage] = useState(11);
  const [chosenQuestion, setChosenQuestion] = useState({ id: null, name: "" });

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
      }}
    >
      {children}
    </QuizContext.Provider>
  );
}

export function useQuiz() {
  return useContext(QuizContext);
}
